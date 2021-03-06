﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    //enum(数字に名前をつける,Nomal,Hard) クラス名（EnemyMode）
    public enum EnemyMode
    {
        Nomal,
        Hard
    }
    public EnemyMode enemyMode = EnemyMode.Nomal;//初期化関数
    /*
    private EnemyMode enemyMode_ = EnemyMode.Nomal;プロパティ
    public EnemyMode enemyMode {
        set { enemyMode_ = value; }
    }
    */


    public float speed = 10;
    public bool isLeft = true;
    public GameObject breakEffect;
    Rigidbody rb_;
    Score score_;//Scoreクラスのインスタンスのscore変数を参照
    public AudioClip fireSound;
    public int scoreValue;

    public GameObject enemyMissilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb_ = GetComponent<Rigidbody>(); 
        Transform transform = this.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        // 三項演算子　Vector2のxの値が、もしisLeft_であれば−１、でなければ１
        Vector2 direction = new Vector2(isLeft ? -1 : 1, 0);
        rb_.velocity = direction * speed;
        //rb_.AddForce(new Vector3(1, 0, 0));

        /*
        if (isLeft_) {
            direction = new Vector2(-1, 0);
        } else {
            direction = new Vector2(1, 0);
        }
        */
        score_ = GameObject.Find("ScoreUI").GetComponent<Score>();

        if(enemyMode == EnemyMode.Hard)
        {
            if (Random.Range(1, 1000) > 970)
            {
                Instantiate(enemyMissilePrefab, transform.position, enemyMissilePrefab.transform.rotation);
            }
        }
        
    }
    public void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //OnCollisioonEnterメソッド(当たったら消える)〜inspectorにBoxColligerをAdd Componnentする
        //Debug.Log(collision.gameObject.tag);//inspectorのtagでグループ分けをする"Ballet"グループにする
        if(collision.gameObject.tag == "Bullet") {
            GameObject.Destroy(this.gameObject);//Balletグループに接触すると、このgameObjectは消える
            score_.AddScore(scoreValue);
            CreateEffect();
            AudioSource.PlayClipAtPoint(fireSound, transform.position);
        }
    }
    void CreateEffect()
    { 
        GameObject effect = Instantiate(breakEffect) as GameObject;
        effect.transform.position = gameObject.transform.position;
        
    }
    

}
