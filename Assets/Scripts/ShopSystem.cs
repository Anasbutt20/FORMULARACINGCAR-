using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{
    public int currentCarIndex = 0;
    public GameObject[] carModels;
    public PlayerSelection[] cars;
    public Button buybutton;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("coins", 10000);
        foreach (PlayerSelection car in cars)
        {
            if(car.price == 0)
            {
                car.isunlocked = true;
            }
            else
            {
                car.isunlocked = PlayerPrefs.GetInt(car.name, 0) == 0 ? false : true;
            }
            currentCarIndex = PlayerPrefs.GetInt("selectedcar", 0);
            foreach (GameObject cars in carModels)
            carModels[currentCarIndex].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        updateui();
    }

    public void left()
    {
        currentCarIndex = PlayerPrefs.GetInt("CurrentCar");
        if(currentCarIndex == 0)
        {
            carModels[cars.Length-1].SetActive(false);
        }
        else
        {
            carModels[currentCarIndex - 1].SetActive(false);
        }

        //cars[currentCarIndex].transform.rotation = spawnPoint.transform.rotation;
        //cars[currentCarIndex].transform.position = spawnPoint.transform.position;
        //cars[currentCarIndex].gameObject.SetActive(true);

        //playerCar = Instantiate(cars[currentCarIndex], spawnPoint.transform.position, spawnPoint.transform.rotation);
        if (currentCarIndex < cars.Length - 1)
        {
            currentCarIndex += 1;
        }
        else
        {
            currentCarIndex = 0;
        }
        PlayerPrefs.SetInt("CurrentCar", currentCarIndex);

    }
    public void Right()
    {
        currentCarIndex = PlayerPrefs.GetInt("CurrentCar");
        if (currentCarIndex == 0)
        {
            carModels[cars.Length - 1].SetActive(false);
        }
        else
        {
            carModels[currentCarIndex - 1].SetActive(false);
        }

        //cars[currentCarIndex].transform.rotation = spawnPoint.transform.rotation;
        //cars[currentCarIndex].transform.position = spawnPoint.transform.position;
        //cars[currentCarIndex].gameObject.SetActive(true);
        //playerCar = Instantiate(cars[currentCarIndex], spawnPoint.transform.position, spawnPoint.transform.rotation);
        if (currentCarIndex < cars.Length - 1)
        {
            currentCarIndex += 1;
        }
        else
        {
            currentCarIndex = 0;
        }
        PlayerPrefs.SetInt("CurrentCar", currentCarIndex);

    }
    public void unlockedcar()
    {
        PlayerSelection c = cars[currentCarIndex];
        PlayerPrefs.SetInt(c.name, 1);
        PlayerPrefs.SetInt("selectedcar", currentCarIndex);
        c.isunlocked = true;
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) - c.price);


    }
    public void updateui()
    {
        PlayerSelection c = cars[currentCarIndex];
        if (c.isunlocked)
        {
            buybutton.gameObject.SetActive(false);
        }
        else
        {
            buybutton.gameObject.SetActive(true);
            buybutton.GetComponentInChildren<Text>().text = "buy" + c.price;
            if (c.price < PlayerPrefs.GetInt("coins", 0))
            {
                buybutton.interactable = true;
            }
            else
            {
                buybutton.interactable = false;
            }
        }
    }

}