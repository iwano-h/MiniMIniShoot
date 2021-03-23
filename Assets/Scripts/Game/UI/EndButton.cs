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

    public void Change()
    {
        SceneManager.LoadScene("Gameover");
    }
    public void Click()
    {
        GetComponent<AudioSource>().Play();//戻り値がなければメソッドをつなげれる。チェインメソッド
        //AudioSource audio = GetComponent<AudioSource>();
        //audio.Play();

        Invoke("Change", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
