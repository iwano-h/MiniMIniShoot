using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    //int count = 90;
    //bool flg = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        /*+if (!flg) return;

        count--;
        if (count <= 0)
        {
            flg = false;
            SceneManager.LoadScene("Game");
        }*/

    }

    public void Click()
    {
        GetComponent<AudioSource>().Play();//戻り値がなければメソッドをつなげれる。チェインメソッド
        //AudioSource audio = GetComponent<AudioSource>();
        //audio.Play();
        //flg = true;
        Invoke("Cange", 1f);
    }
    
    public void Cange()
    {
        SceneManager.LoadScene("Game");
    }
    
}
