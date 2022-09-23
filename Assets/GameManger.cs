using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    public GameObject[] cars;
    public GameObject[] levels;
    public GameObject[] enemiescar;
    public LevelEditor lvlEditor;
    //[SerializeField] private GameObject _loadercanvas;
    //[SerializeField] private Image _progressbar;

    // Start is called before the first frame update
    void Start()
    {
        lvlEditor = FindObjectOfType<LevelEditor>();
        for (int i = 0; i < cars.Length; i++)
        {
            cars[i].SetActive(false);
        }
        int selectcar = PlayerPrefs.GetInt("selectedcarid");
        cars[selectcar].SetActive(true);


        //for (int i = 0; i < levels.Length; i++)
        //{
        //    lvlEditor.lvlManger[LevelSelection.levelNum].level.SetActive(true);

        //}
        cars[selectcar].transform.position = lvlEditor.lvlManger[LevelSelection.levelNum].playerPosition.position;
        cars[selectcar].transform.eulerAngles = lvlEditor.lvlManger[LevelSelection.levelNum].playerPosition.eulerAngles;

        for (int i = 0; i < lvlEditor.lvlManger[LevelSelection.levelNum].enemiesPosition.Length; i++)
        {
            enemiescar[i].transform.position = lvlEditor.lvlManger[LevelSelection.levelNum].enemiesPosition[i].enemiesPos.position;
            enemiescar[i].transform.eulerAngles = lvlEditor.lvlManger[LevelSelection.levelNum].enemiesPosition[i].enemiesPos.eulerAngles;
            enemiescar[i].GetComponent<RCC_AICarController>().waypointsContainer = lvlEditor.lvlManger[LevelSelection.levelNum].curreentWayPoint;
        }


        lvlEditor.lvlManger[LevelSelection.levelNum].level.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public async void NextBTN()
    {
        
        SceneManager.LoadScene(1);
        //var scene = SceneManager.LoadSceneAsync(1);
        ////scene.allowSceneActivation = false;
        ////_loadercanvas.SetActive(true);
        ////do
        ////{

        ////    _progressbar.fillAmount = scene.progress;

        ////}
        ////while (scene.progress < 0.9f);

        //await Task.Delay(100);

        //scene.allowSceneActivation = true;
        //_loadercanvas.SetActive(false);

        SceneManager.LoadScene(1);
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].SetActive(false);
            Time.timeScale = 1;
            SceneManager.LoadScene(1);
        }

        levels[LevelSelection.levelNum++].SetActive(true);
        

    }
}
