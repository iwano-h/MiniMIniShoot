using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndButton : MonoBehaviour
{
    int count = 90;
    bool flg = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!flg) return;

        count--;
        if (count <= 0)
        {
            flg = false;
            SceneManager.LoadScene("Gameover");
        }
    }

    public void Click()
    {
        GetComponent<AudioSource>().Play();
        flg = true;
    }


}
