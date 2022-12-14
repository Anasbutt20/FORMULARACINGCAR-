using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VSX.UniversalVehicleCombat.Radar;

namespace VSX.UniversalVehicleCombat
{
    public class SpaceshipAttackBehaviour : AISpaceshipBehaviour
    {

        [Header("Primary Weapons")]

        [SerializeField]
        protected float minPrimaryFiringPeriod = 1;

        [SerializeField]
        protected float maxPrimaryFiringPeriod = 3;

        [SerializeField]
        protected float minPrimaryFiringPause = 0.5f;

        [SerializeField]
        protected float maxPrimaryFiringPause = 2;

        [SerializeField]
        protected float maxFiringAngle = 15f;

        [SerializeField]
        protected float maxFiringDistance = 600;

        protected float primaryWeaponActionStartTime = 0;
        protected float primaryWeaponActionPeriod = 0f;
        protected bool primaryWeaponFiring = false;

        [Header("Secondary Weapons")]

        [SerializeField]
        protected Vector2 minMaxSecondaryFiringInterval = new Vector2(10, 25);

        protected float secondaryWeaponActionStartTime = 0;
        protected float secondaryWeaponActionPeriod = 0f;
        protected bool secondaryWeaponFiring = false;

        protected Weapons weapons;
        protected TriggerablesManager triggerablesManager;
        protected VehicleEngines3D engines;
        protected Rigidbody rBody;
        

        protected override bool Initialize(Vehicle vehicle)
        {
            if (!base.Initialize(vehicle)) return false;

            weapons = vehicle.GetComponent<Weapons>();
            if (weapons == null) return false;
            
            triggerablesManager = vehicle.GetComponent<TriggerablesManager>();
            if (triggerablesManager == null) return false;

            engines = vehicle.GetComponent<VehicleEngines3D>();
            if (engines == null) return false;

            rBody = vehicle.GetComponent<Rigidbody>();
            if (rBody == null) return false;

            return true;

        }

        public override void StopBehaviour()
        {
            if (initialized) triggerablesManager.StopTriggeringAll();
        }
        
        protected virtual void SetPrimaryWeaponAction(bool fire)
        {
            if (fire)
            {
                triggerablesManager.StartTriggeringAtIndex(0);
                primaryWeaponFiring = true;

                primaryWeaponActionStartTime = Time.time;
                primaryWeaponActionPeriod = Random.Range(minPrimaryFiringPeriod, maxPrimaryFiringPeriod);
            }
            else
            {
                triggerablesManager.StopTriggeringAtIndex(0);
                primaryWeaponFiring = false;

                primaryWeaponActionStartTime = Time.time;
                primaryWeaponActionPeriod = Random.Range(minPrimaryFiringPause, maxPrimaryFiringPause);
            }
        }

        /// <summary>
        /// Update the behaviour.
        /// </summary>
        public override bool BehaviourUpdate()
        {

            if (!base.BehaviourUpdate()) return false;

            if (weapons.WeaponsTargetSelector == null || weapons.WeaponsTargetSelector.SelectedTarget == null)
            {
                return false;
            }

            Vector3 targetPos = weapons.WeaponsTargetSelector.SelectedTarget.transform.position;
            Vector3 toTargetVector = targetPos - vehicle.transform.position;

            // Do primary weapons
            bool canFirePrimary = Vector3.Angle(vehicle.transform.forward, toTargetVector) < maxFiringAngle && toTargetVector.magnitude < maxFiringDistance;
            if (canFirePrimary)
            {
                // Fire in bursts
                if (Time.time - primaryWeaponActionStartTime > primaryWeaponActionPeriod)
                {
                    SetPrimaryWeaponAction(!primaryWeaponFiring);
                }
            }
            else
            {
                SetPrimaryWeaponAction(false);
            }

            // Do the secondary weapons
            if (weapons.TargetLockers.Count > 0 && weapons.TargetLockers[0].LockState == LockState.Locked)
            {
                if (Time.time - secondaryWeaponActionStartTime > secondaryWeaponActionPeriod)
                {
                    triggerablesManager.TriggerOnce(1);
                    secondaryWeaponActionPeriod = Random.Range(minMaxSecondaryFiringInterval.x, minMaxSecondaryFiringInterval.y);
                    secondaryWeaponActionStartTime = Time.time;
                }
            }

            // Turn toward target
            Maneuvring.TurnToward(vehicle.transform, targetPos, maxRotationAngles, shipPIDController.steeringPIDController);
            engines.SetSteeringInputs(shipPIDController.steeringPIDController.GetControlValues());

            Maneuvring.TranslateToward(rBody, targetPos, shipPIDController.movementPIDController);
            engines.SetMovementInputs(shipPIDController.movementPIDController.GetControlValues());

            return true;

        }
    }
}