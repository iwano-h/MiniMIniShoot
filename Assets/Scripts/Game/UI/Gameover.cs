using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameover : MonoBehaviour
{
    [SerializeField] Text resultText;

    // Start is called before the first frame update
    void Start()
    {
        resultText.text = string.Format(resultText.text, Score.scoreStr, Score.resultScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
