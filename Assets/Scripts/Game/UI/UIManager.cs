using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public GameObject descriptionPanel;
     
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }
    public void GameGo()
    {
        Destroy(this.gameObject);
        Time.timeScale = 1f;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
