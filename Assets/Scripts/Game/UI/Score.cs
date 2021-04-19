using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score_ = 0;// スコア　(静的クラス)public static int score;現時点で静的にする必要ない
    public int highScore_ = 0;// ハイスコア

    public Text scoreText_;// スコアテキスト
    public Text highScoreText_;// ハイスコアテキスト

    public static string scoreStr_;
    public static string highScoreStr_;

    public static string scoreResult_;
    public GameObject enemy_;
    EnemyGenerator enemyGenerator_;

    // Start is called before the first frame update
    void Start()
    {
        //score = 0;// スコアの初期化
        //highScore = 0;// ハイスコアの初期化
        highScore_ = PlayerPrefs.GetInt("Score", 0);// スコアのロード
        scoreText_.text = "Score " + score_.ToString();// スコアの表示
        UpdateHighScore();
        


    }
 
    // Update is called once per frame
    void Update()
    {
     
        //scoreの方が大きかったら
        if (score_ > highScore_)
        {
            highScore_ = score_;//*ここでhighScoreにscoreを代入
            UpdateHighScore();
            // スコアを保存*highScoreにscoreの代入された数値がセーブされる
            PlayerPrefs.SetInt("Score", highScore_);
            PlayerPrefs.Save();
        }
    }
    public void AddScore(int scoreToAdd)//スコアを増加するメソッド　外部からアクセスするためpublicで定義
    {
        score_ += scoreToAdd;
        scoreText_.text = "Score " + score_.ToString();// スコアの表示
    }
    void UpdateHighScore()
    {
        //ハイスコアの表示と更新
        highScoreText_.text = "Hightscore " + highScore_.ToString();
        
    }
    public void Result()
    {
        if(score_ > 10000)
        {
            Score.scoreResult_ = "Excellent";
        }
        else if(score_ > 5000)
        {
            Score.scoreResult_ = "VeryGood";
        }
        else if(score_ > 2500)
        {
            Score.scoreResult_ = "Good";
        }
        else if(score_ > 1250)
        {
            Score.scoreResult_ = "Average";
            float interval = enemy_.GetComponent<EnemyGenerator>().interval_;
            interval = 8f;
            Debug.Log(interval);
        }
        else
        {
            Score.scoreResult_ = "Poor";
        }
        Score.scoreStr_ = score_.ToString();
        Score.highScoreStr_ = highScore_.ToString();//* = scoreを = highScoreに変えた。
    }
    
}
