using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    public GameObject breakEffect;
    public float speed_ = 1;
    public bool isLeft_ = true;
    private Rigidbody rb_;
    public int scoreValue;  // これが敵を倒すと得られる点数になる
    private Score score;//Scoreクラスのインスタンスのscore変数を参照

    // Start is called before the first frame update
    void Start()
    {
        rb_ = GetComponent<Rigidbody>();
        Transform transform = this.transform;
        if(Random.Range(0, 100) > 50)//Renge関数の戻り値(0~100)が50と比較して大きい場合
        {
            isLeft_ = true;//isLeft_にtrueを返す。左に行く。
        } else
        {
            isLeft_ = false;//falseを返す。左に行かない。右にいく。
        }
        //isLeft_ = Random.Range(0, 100) > 50;

        float rotY = 0;//Rotation
        if(isLeft_ == true)
        {
            rotY = 180;
        } else
        {
            rotY = 0;
        }
        transform.localEulerAngles = new Vector3(0, rotY, 0);

        //transform.localEulerAngles = new Vector3(0, isLeft_ ? 180 : 0, 0);
        score = GameObject.Find("ScoreUI").GetComponent<Score>();//よく使われる
    }

    // Update is called once per frame
    void Update()
    {
        float x = 0;
        if (isLeft_ == true)//isLeft_がtrueの時が左
        {
            x = -1;//Vector2(x,0)に-1 -1の方向が左に
        }
        else
        {
            x = 1;//1の方向が右に
        }
        Vector2 direction = new Vector2(x, 0);
        //Vector2 direction = new Vector2(isLeft_ ? -1 : 1, 0);
        rb_.velocity = direction * speed_;//velocityは渡した値で
   
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            GameObject.Destroy(this.gameObject);
            GetComponent<AudioSource>().Play();
            EffectGo();
            //Score.score += scoreValue; static(静的Scoreクラスがもつscore変数)1個だけ　参照しなくても取得できる
            score.AddScore(scoreValue);　//インスタンスがもつscore変数　複数　unityが自動的に造る　
        }
    }
    
    void EffectGo()
    {
        GameObject effect = Instantiate(breakEffect) as GameObject;
        effect.transform.position = gameObject.transform.position;
    }
    public void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

}
