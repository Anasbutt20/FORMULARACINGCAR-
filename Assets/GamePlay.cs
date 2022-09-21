using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlay : MonoBehaviour
{
    bool ispaused = false;
    public GameObject winpanel;
    public static GamePlay instance;
    public GameObject pausepanel;
    public GameObject rcccanvas;
   


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void pausegame()
        
    {
        pausepanel.SetActive(true);
            Time.timeScale = 0;
        rcccanvas.SetActive(false);
           
    }
    public void WINPANEL()
    {
        PlayerPrefs.SetInt("levelunlocked", LevelSelection.levelNum);
        winpanel.SetActive(true);
        rcccanvas.SetActive(false);
    }
    public void RESTART()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void resume()
    {
        Time.timeScale = 1;
        pausepanel.SetActive(false);
        rcccanvas.SetActive(true);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

}
