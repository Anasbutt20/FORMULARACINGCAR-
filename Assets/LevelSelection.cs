using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class LevelSelection : MonoBehaviour
{
    public GameObject[] levelbutton;
    [SerializeField] private GameObject _loadercanvas;
    [SerializeField] private Image _progressbar;
    public static int levelNum;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;  i < levelbutton.Length; i++)
        {
            levelbutton[i].GetComponent<Button>().interactable= false;
        }
        Debug.Log(PlayerPrefs.GetInt("levelunlocked"));
        for(int i = 0; i <= PlayerPrefs.GetInt("levelunlocked"); i++)
        {
            Debug.Log(i);
            levelbutton[i].GetComponent<Button>().interactable = true;
        }
    }
    private void Awake()
    {
        if (PlayerPrefs.GetInt("levelunlocked") == 0)
        {
            PlayerPrefs.SetInt("levelunlocked",0);
        }
    }
     public async void loadscene(int index)
    {
        levelNum = index;
       // SceneManager.LoadScene(index);
        //var scene = SceneManager.LoadSceneAsync(1);
        //scene.allowSceneActivation = false;
        //_loadercanvas.SetActive(true);
        //do
        //{

        //    _progressbar.fillAmount = scene.progress;

        //}
        //while (scene.progress < 0.9f);

        //await Task.Delay(100);

        //scene.allowSceneActivation = true;
        //_loadercanvas.SetActive(false);

         SceneManager.LoadScene(1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
