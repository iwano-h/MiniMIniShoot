using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] public GameObject enemy_;
    [SerializeField] public float interval_;
    [SerializeField] public float timer_;
    [SerializeField] public Transform targetTrans_;//playerの位置
    //public GameObject scoreText_;//難度
    //public int score_ = 0;//難度
    // Start is called before the first frame update
    void Start()
    {
        
        
    }
    

    // Update is called once per frame
    void Update()
    {
        timer_ += Time.deltaTime;
        
       
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
        enemy.GetComponent<Enemy>().isLeft_ = !fromLeft;//EnemyクラスのisLeft_は2/1の確率
        //[(enemy_, enemyPosition, Quaternion.identity)が複製され、GameObjectのenemyに代入される]よく使われる！
    }
    
}
