using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    
    //private float screenSide_;
    private Rigidbody rb_;
    [SerializeField] public GameObject human_;//= null;
    [SerializeField] public Transform appearPoint_;
    private int timeCount;
    private bool canAppear_;
    //public float apperDely_ = 0.1f;
    public GameObject breakEffect;
    public AudioClip fireSound;
    public int scoreValue;  // これが敵を倒すと得られる点数になる
    private Score score;//Scoreクラスのインスタンスのscore変数を参照


    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        score = GameObject.Find("ScoreUI").GetComponent<Score>();
    }
    public void OnBecameInvisible()
    {
        GameObject.Destroy(this.gameObject);

    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Bullet")
        {
            GameObject.Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(fireSound, transform.position);
            CreateEffect();
            score.AddScore(scoreValue);
            rb_ = GetComponent<Rigidbody>();
            StartCoroutine(AppearGo());
        }
    }
    IEnumerator AppearGo()
    {
        while (true)
        {
            CanAppear();
            yield return null;//new WaitForSeconds(apperDely_);
        }
        
    }
    public void CanAppear()
    {
        for (int i = 0; i < Random.Range(6,13); i++)
        {
            Vector3 pos = appearPoint_.position;
            pos.x += i*Random.Range(0.1f,0.3f);
            Instantiate(human_, pos, transform.rotation);
        }

        return;

        //連射の要領でHumanを生成をトライしたがダメでした。
        /*canAppear_ = true;
        bool fromLeft = Random.Range(0, 100) > 50;
        human_.GetComponent<Human>().isLeft_ = !fromLeft;
        Instantiate(human_, appearPoint_.position, transform.rotation);
        const int SHOT_INTERVAL = 5;
        timeCount++;
        
        //カウントが発射間隔に達したら、人を発射
        if (timeCount > SHOT_INTERVAL)
        {
            timeCount = 0;  //カウント初期化
            GameObject human = Instantiate(human_, transform.position, Quaternion.identity) as GameObject;
            Rigidbody missileRb = human.GetComponent<Rigidbody>();
            //humanRb_.AddForce(transform.forward * humanSpeed);
                
            Destroy(human_, 2.0f);
        }
        
        else
        {
            //「Fire1」ボタンが押されていない場合、次弾用意
            timeCount = SHOT_INTERVAL;
        }/*

        /*
        screenSide_ = Camera.main.ViewportToWorldPoint(new Vector2(fromLeft ? 1 : -1, 0)).x;
        //画面の両サイドの座標を取得
        if (canAppear_ == false)
        {
            return;
        }
        if (this.transform.position.x > screenSide_ + 1)
        {
            canAppear_ = false;
        }

        for (int i = 0; i < 10; i++)
        {
            Instantiate(human_, appearPoint_.position, transform.rotation);
        }
        */

        


        //canAppear_ = false;
    }


    void CreateEffect()
    {
        GameObject effect = Instantiate(breakEffect) as GameObject;
        effect.transform.position = gameObject.transform.position;
        GetComponent<AudioSource>().Play();
    }
    

}
