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
        if (ispaused)
        {
            Time.timeScale = 1;
            ispaused = false;
        }
        else
        {
            Time.timeScale = 0;
            ispaused = true;
        }
    }
    public void WINPANEL()
    {
        winpanel.SetActive(true);
    }
    public void RESTART()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void resume()
    {
        Time.timeScale = 1;
        pausepanel.SetActive(false);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

}
