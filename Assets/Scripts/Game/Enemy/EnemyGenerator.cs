using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] public GameObject enemy_;
    [SerializeField] public float interval_;
    float baseInterval_ = 0;//毎回数値（パラメータ）変化を防ぐ
    float timer_;
    [SerializeField] public Transform targetTrans_;//playerの位置
    
    Score score_;//難度　変数はprivateに（_）付ける。
    
    
    

    // Start is called before the first frame update
    void Start()
    {   //GameObject("ScoreUI")に付いている。Scoreクラスの数値を参照
        score_ = GameObject.Find("ScoreUI").GetComponent<Score>();
        baseInterval_ = interval_;
        
    }
    

    // Update is called once per frame
    void Update()
    {
        timer_ += Time.deltaTime;
        
        if(score_.score >= 10000)//取得されたスコアクラスのスコア数値
        {
            interval_ = baseInterval_ * 0.8f;
        } else if (score_.score >= 3000)
        {
            interval_ = baseInterval_ * 0.9f;
        }
        else
        {
            interval_ = baseInterval_;
        }

        if (timer_ < interval_)
        {

            return;
        }
        timer_ = 0;

        bool fromLeft = Random.Range(0, 100) > 50;//fromLeftに2/1の確率
        //三項演算子　x が+ か- になる　[targetTrans(player)を中心に-10(左)か、10(右)に2/1の確率で生成される]
        Vector3 enemyPosition = new Vector3(
            fromLeft ? targetTrans_.position.x - 10 : targetTrans_.position.x + 10, // x
            Random.Range(3f,10.5f), // y
            targetTrans_.position.z //z
            );
        GameObject enemy = Instantiate(enemy_, enemyPosition, Quaternion.Euler(0f,180f,0f));
        enemy.GetComponent<Enemy>().isLeft = !fromLeft;//EnemyクラスのisLeft_は2/1の確率
        //[(enemy_, enemyPosition, Quaternion.identity)が複製され、GameObjectのenemyに代入される]よく使われる！
    }
    
}
