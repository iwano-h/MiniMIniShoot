using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    public float speed_ = 10;
    public bool isLeft_ = true;
    public GameObject breakEffect;
    private Rigidbody rb_;
    public int scoreValue;  // これが敵を倒すと得られる点数になる
    private Score score;//Scoreクラスのインスタンスのscore変数を参照


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
        Vector2 direction = new Vector2(isLeft_ ? -1 : 1, 0);
        rb_.velocity = direction * speed_;
        //rb_.AddForce(new Vector3(1, 0, 0));

        /*
        if (isLeft_) {
            direction = new Vector2(-1, 0);
        } else {
            direction = new Vector2(1, 0);
        }
        */
        score = GameObject.Find("ScoreUI").GetComponent<Score>();
    }
    public void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //OnCollisioonEnterメソッド(当たったら消える)〜inspectorにBoxColligerをAdd Componnentする
        Debug.Log(collision.gameObject.tag);//inspectorのtagでグループ分けをする"Ballet"グループにする
        if(collision.gameObject.tag == "Bullet") {
            GameObject.Destroy(this.gameObject);//Balletグループに接触すると、このgameObjectは消える
            score.AddScore(scoreValue);
            CreateEffect();
        }
    }
    void CreateEffect()
    { 
        GameObject effect = Instantiate(breakEffect) as GameObject;
        effect.transform.position = gameObject.transform.position;
        GetComponent<AudioSource>().Play();
    }
}
