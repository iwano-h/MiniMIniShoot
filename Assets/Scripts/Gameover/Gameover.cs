using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameover : MonoBehaviour
{
    [SerializeField] Text resultHighScore;
    [SerializeField] Text resultScore;

    // Start is called before the first frame update
    void Start()
    {
        resultHighScore.text = string.Format(resultHighScore.text, Score.highScoreStr);
        resultScore.text = string.Format(resultScore.text, Score.scoreStr, Score.scoreResult);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
