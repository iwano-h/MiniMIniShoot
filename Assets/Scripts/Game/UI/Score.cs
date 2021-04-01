using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;// スコア　(静的クラス)public static int score;現時点で静的にする必要ない
    public int highScore;// ハイスコア

    public Text scoreText = null;// スコアテキスト
    public Text highScoreText;// ハイスコアテキスト

    public static string scoreStr;
    public static string resultScore;
    public static string highScoreStr;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;// スコアの初期化
        highScore = 0;// ハイスコアの初期化
        scoreText.text = "Score " + score.ToString();// スコアの表示
        UpdateHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        //scoreの方が大きかったら
        if (score > highScore)
        {
            UpdateHighScore();
        }
    }
    public void AddScore(int scoreToAdd)//スコアを増加するメソッド　外部からアクセスするためpublicで定義
    {
        score += scoreToAdd;
        scoreText.text = "Score " + score.ToString();// スコアの表示
    }
    void UpdateHighScore()
    {
        //ハイスコアの表示と更新
        highScoreText.text = "Hightscore " + score.ToString();
    }
    public void Result()
    {
        if(score > 10000)
        {
            Score.resultScore = "Excellent";
        }
        else if(score > 5000)
        {
            Score.resultScore = "VeryGood";
        }
        else if(score > 2500)
        {
            Score.resultScore = "Good";
        }
        else if(score > 1250)
        {
            Score.resultScore = "Average";
        }
        else
        {
            Score.resultScore = "Poor";
        }
        Score.scoreStr = score.ToString();
    }
}
