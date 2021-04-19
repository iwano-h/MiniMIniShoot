using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    public GameObject breakEffect_;
    public float humanspeed_ = 1;
    public bool isLeft_ = true;
    public AudioClip fireSound_;
    public Rigidbody humanrb_;
    public Renderer renderer_;//*
    Transform playerTrans_;//*
    
    public int scoreValue_;  // これが敵を倒すと得られる点数になる
    private Score score_;//Scoreクラスのインスタンスのscore変数を参照

    // Start is called before the first frame update
    void Start()
    {
        humanrb_ = GetComponent<Rigidbody>();
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
        //Humanのスピードをランダムにすること自然に散らばる
        humanspeed_ *= Random.Range(0.8f, 1.2f);
        //HumanのInstantiatのpositionをずらすことでも散らばる

        playerTrans_ = GameObject.Find("Heli_2").GetComponent<Transform>();
        //*スタートでプレイヤーの位置情報を取得
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
        humanrb_.velocity = direction * humanspeed_;//velocityは渡した値で
        score_ = GameObject.Find("ScoreUI").GetComponent<Score>();//よく使われる

        //プレイヤーとの距離をチェック。静的Vector3クラスのDistance関数
        if (!renderer_.isVisible && Vector3.Distance(gameObject.transform.position,playerTrans_.position) > 20)
        {
            GameObject.Destroy(this.gameObject);
        }


    }
    public void OnBecameInvisible()//画面外で生成されるオブジェクトには効果ない
    {
        ///GameObject.Destroy(this.gameObject);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet"|| collision.gameObject.tag == "Player")
        {
            GameObject.Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(fireSound_, transform.position);
            EffectGo();
            //Score.score += scoreValue; static(静的Scoreクラスがもつscore変数)1個だけ　参照しなくても取得できる
            score_.AddScore(scoreValue_);　//インスタンスがもつscore変数　複数　unityが自動的に造る　
        }
    }
    
    void EffectGo()
    {
        GameObject effect = Instantiate(breakEffect_) as GameObject;
        effect.transform.position = gameObject.transform.position;
        
    }
    

}
