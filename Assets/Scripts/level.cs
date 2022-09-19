using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class level : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject carSelection;
    public GameObject levelSelection;
    public GameObject plane;
    public static int levelNum;
    public GameObject load;
    public static LEVELMANGER Instance;
   
   


    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startrace()
    {
        MainMenu.SetActive(false);
        carSelection.SetActive(true);

    }
   
 
    public void back()
    {
      
        MainMenu.SetActive(true);
        carSelection.SetActive(false);

    }
    public void selectcar()
    {
        levelSelection.SetActive(true);
        carSelection.SetActive(false);
        PlayerPrefs.SetInt("selectedcarid",ShopSystem.currentCarIndex);
    }

    public void loading()
    {
        levelSelection.SetActive(false);
        load.SetActive(true);
    }
    public async void Mood(int num)
    {
        levelNum = num;
        //public async void loadscene(string sceneName)
        
           
    }
  
   
    
}
