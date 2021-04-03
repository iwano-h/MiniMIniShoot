using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToTitleButton : MonoBehaviour
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
            SceneManager.LoadScene("Title");
        }

    }
    
    public void Click()
    {
        GetComponent<AudioSource>().Play();
        flg = true;
    }
}
