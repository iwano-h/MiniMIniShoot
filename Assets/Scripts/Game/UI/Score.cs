using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;// スコア　(静的クラス)public static int score;現時点で静的にする必要ない
    public int highScore = 0;// ハイスコア

    public Text scoreText;// スコアテキスト
    public Text highScoreText;// ハイスコアテキスト

    public static string scoreStr;
    public static string highScoreStr;

    public static string scoreResult;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //score = 0;// スコアの初期化
        //highScore = 0;// ハイスコアの初期化
        highScore = PlayerPrefs.GetInt("Score", 0);// スコアのロード
        scoreText.text = "Score " + score.ToString();// スコアの表示
        UpdateHighScore();
    }
 
        // Update is called once per frame
        void Update()
    {
        //scoreの方が大きかったら
        if (score > highScore)
        {
            highScore = score;//*ここでhighScoreにscoreを代入
            UpdateHighScore();
            // スコアを保存*highScoreにscoreの代入された数値がセーブされる
            PlayerPrefs.SetInt("Score", highScore);
            PlayerPrefs.Save();
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
        highScoreText.text = "Hightscore " + highScore.ToString();
        
    }
    public void Result()
    {
        if(score > 10000)
        {
            Score.scoreResult = "Excellent";
        }
        else if(score > 5000)
        {
            Score.scoreResult = "VeryGood";
        }
        else if(score > 2500)
        {
            Score.scoreResult = "Good";
        }
        else if(score > 1250)
        {
            Score.scoreResult = "Average";
        }
        else
        {
            Score.scoreResult = "Poor";
        }
        Score.scoreStr = score.ToString();
        Score.highScoreStr = highScore.ToString();//* = scoreを = highScoreに変えた。
    }
    
}
