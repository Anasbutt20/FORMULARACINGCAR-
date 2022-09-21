using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{
    public static int currentCarIndex = 0;
    public GameObject[] carModels;
    public PlayerSelection[] cars;
    public Button buybutton;
    public GameObject carSelection;
   

    // Start is called before the first frame update
    void Start()
    {
      

        PlayerPrefs.SetInt("coins", 1000);
        foreach (PlayerSelection car in cars)
        {
            if(car.price == 0)
            {
                car.isunlocked = true;

                car.locked.gameObject.SetActive(false);
              
            }
            else
            {
               
                car.isunlocked = PlayerPrefs.GetInt(car.name, 0) == 0 ? false : true;
                car.locked.gameObject.SetActive(true);
            }
            currentCarIndex = PlayerPrefs.GetInt("selectedcar", 0);
            foreach (GameObject cars in carModels)
            carModels[currentCarIndex].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    //public void left()
    //{
    //    currentCarIndex = PlayerPrefs.GetInt("CurrentCar");
    //    if(currentCarIndex == 0)
    //    {
    //        carModels[cars.Length-1].SetActive(false);
    //    }
    //    else
    //    {
    //        carModels[currentCarIndex - 1].SetActive(false);
    //    }

    //    //cars[currentCarIndex].transform.rotation = spawnPoint.transform.rotation;
    //    //cars[currentCarIndex].transform.position = spawnPoint.transform.position;
    //    //cars[currentCarIndex].gameObject.SetActive(true);

    //    //playerCar = Instantiate(cars[currentCarIndex], spawnPoint.transform.position, spawnPoint.transform.rotation);
    //    if (currentCarIndex < cars.Length - 1)
    //    {
    //        currentCarIndex += 1;
    //    }
    //    else
    //    {
    //        currentCarIndex = 0;
    //    }
    //    PlayerPrefs.SetInt("CurrentCar", currentCarIndex);

   // }
    public void Right(int index)
    {
        currentCarIndex = index;
        //if (currentCarIndex == 0)
        //{
        foreach (var item in carModels)
        {
            item.SetActive(false);
        }
            carModels[currentCarIndex].SetActive(true);
        //}
        //else
        //{
        //    carModels[currentCarIndex - 1].SetActive(false);
        //}

        //cars[currentCarIndex].transform.rotation = spawnPoint.transform.rotation;
        //cars[currentCarIndex].transform.position = spawnPoint.transform.position;
        //cars[currentCarIndex].gameObject.SetActive(true);
        //playerCar = Instantiate(cars[currentCarIndex], spawnPoint.transform.position, spawnPoint.transform.rotation);
        //if (currentCarIndex < cars.Length - 1)
        //{
        //    currentCarIndex += 1;
        //}
        //else
        //{
        //    currentCarIndex = 0;
        //}
        //PlayerPrefs.SetInt("CurrentCar", currentCarIndex);
        updateui();
    }
    public void unlockedcar()
    {
        PlayerSelection c = cars[currentCarIndex];
        PlayerPrefs.SetInt(c.name, 1);
        PlayerPrefs.SetInt("selectedcar", currentCarIndex);
        c.isunlocked = true;
        c.locked.gameObject.SetActive(false);
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) - c.price);
        updateui();


    }
    public void updateui()
    {
        PlayerSelection c = cars[currentCarIndex];
        print("IsUnlocked: "+c.isunlocked);
        if (c.isunlocked)
        {
            carSelection.gameObject.SetActive(true);
            buybutton.gameObject.SetActive(false);
            c.locked.gameObject.SetActive(false);
        }
        else
        {
            carSelection.gameObject.SetActive(false);
            buybutton.gameObject.SetActive(true);
            c.locked.gameObject.SetActive(true);
            //buybutton.GetComponentInChildren<Text>().text = "buy" + c.price;
            if (c.price < PlayerPrefs.GetInt("coins", 0))
            {
                c.locked.gameObject.SetActive(false);
                buybutton.interactable = false;
                carSelection.GetComponent<Button>().interactable = false;
            }
            else
            {
                c.locked.gameObject.SetActive(true);
                buybutton.interactable = true;
                carSelection.GetComponent<Button>().interactable = true;
            }
        }
    }
   

}