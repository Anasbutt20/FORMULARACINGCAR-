using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levelunlocked : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void unlocked(int nextlevel)
    {
        PlayerPrefs.SetInt("levelunlocked", nextlevel);
    }
}
