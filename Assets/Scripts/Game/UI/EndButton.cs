﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndButton : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Change()
    {
        SceneManager.LoadScene("Gameover");
    }
    public void Click()
    {
        Invoke("Change", 1.5f);
        GetComponent<AudioSource>().Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}