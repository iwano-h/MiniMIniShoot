using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameover : MonoBehaviour
{
    [SerializeField] Text resultHighScore_;
    [SerializeField] Text resultScore_;

    // Start is called before the first frame update
    void Start()
    {
        //ScoreのResultメソッドを呼ぶ
        resultHighScore_.text = string.Format(resultHighScore_.text, Score.highScoreStr_);
        resultScore_.text = string.Format(resultScore_.text, Score.scoreStr_, Score.scoreResult_);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
