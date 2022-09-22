using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditor : MonoBehaviour
{
    // Start is called before the first frame update
    public Levelmanger[] lvlManger;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
[System.Serializable]
public class Levelmanger
{
    public Transform playerPosition;
    public RCC_AIWaypointsContainer curreentWayPoint;
    public GameObject level;
    public int laps;
    public Enemies[] enemiesPosition;

}
[System.Serializable]
public class Enemies
{
    public Transform enemiesPos;
    
} 
