using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;// スコア　(静的クラス)public static int score;現時点で静的にする必要ない
    public int highScore;// ハイスコア

    public Text scoreText;// スコアテキスト
    public Text highScoreText;// ハイスコアテキスト

    

    // Start is called before the first frame update
    void Start()
    {
        score = 0;// スコアの初期化
        highScore = 0;// ハイスコアの初期化
        scoreText.text = "SCORE: " + score;// スコアの表示
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
        scoreText.text = "SCORE: " + score;// スコアの表示
    }
    void UpdateHighScore()
    {
        //ハイスコアの表示と更新
        highScoreText.text = "HIGHSCORE: " + score;
    }
}
