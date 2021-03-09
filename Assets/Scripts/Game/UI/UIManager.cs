using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public GameObject descriptionPanel;
    Animation panelAnimation;
     
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        panelAnimation = this.gameObject.GetComponent<Animation>();
    }
    public void Click()
    {

        panelAnimation.Play();
        Time.timeScale = 1f;
        //Invoke("GameGo", 2f);



    }
    /*
    public void GameGo()
    {
        
        Time.timeScale = 1f;
        
    }
    */
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
