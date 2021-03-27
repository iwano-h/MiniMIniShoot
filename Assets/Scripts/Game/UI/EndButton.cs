using System.Collections;
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

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SceneChange()
    {
        SceneManager.LoadScene("Gameover");
    }
    public void Click()
    {
        Invoke("SceneChange", 1.5f);
        GetComponent<AudioSource>().Play();
    }
}
