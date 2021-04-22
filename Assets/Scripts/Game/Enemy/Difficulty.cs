using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
    public GameObject scoreText;
    public int score = 0;
    public float interval_;
    GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        this.scoreText = GameObject.Find("Score");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void difficulty()
    {

    }
}
