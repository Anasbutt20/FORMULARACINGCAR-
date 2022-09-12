using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class level : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CarSelection;
    public GameObject levelSelection;
    public GameObject plane;
    public static int levelNum;

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
        CarSelection.SetActive(true);

    }
    public void selectcar()
    {
       
        CarSelection.SetActive(false);
        plane.SetActive(false);
        levelSelection.SetActive(true);


    }
 
    public void back()
    {
        MainMenu.SetActive(true);
        CarSelection.SetActive(false);
    }
    public void mood(int num)
    {
        levelNum = num;
        SceneManager.LoadScene(1);
    }
    
}
