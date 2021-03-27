using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public float speed_ = 0.1f;
    public GameObject bulletPrefab_;
    public AudioClip fireSound_;
    private int timeCount_;

    // Start is called before the first frame update
    void Start()
    {
        
        //BulletとPlayerの不具合（弾を打つとプレイヤーが回転）Layer　PlayerとBulletを指定
    }   //BulletとPlayerの当たり判定を制御する

    // Update is called once per frame
    void Update()
    {
        const int SHOT_INTERVAL = 5;
        if (Input.GetKey(KeyCode.A))
        {
            timeCount_++;

            //カウントが発射間隔に達したら、弾を発射
            if (timeCount_ > SHOT_INTERVAL)
            {
                timeCount_ = 0;  //カウント初期化
                GameObject bullet = Instantiate(bulletPrefab_, transform.position, Quaternion.identity) as GameObject;
                Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
                //bulletRb.AddForce(transform.forward * speed_);
                Vector3 foward = transform.forward;
                foward.x = foward.x * speed_;//計算式改変　speed_の数値変更
                foward.y = foward.y * speed_;
                transform.position += foward;//前方方向の向きに対して進行する
                AudioSource.PlayClipAtPoint(fireSound_, transform.position);
                Destroy(bullet, 2.0f);
            }
        }
        else
        {
            //「A」ボタンが押されていない場合、次弾用意
            timeCount_ = SHOT_INTERVAL;
        }
        
        /*
        //弾単発
        //transfrom.forwardはオブジェクトが向いている方向のベクトル、1f*Time.deltaTimeは1m/sの速さで処理を行うことを示す
        Vector3 foward = transform.forward;　
        foward.x = foward.x * speed_;//計算式改変　speed_の数値変更
        foward.y = foward.y * speed_;
        transform.position += foward;//前方方向の向きに対して進行する
        //Debug.LogFormat("x:{0} y:{1}", foward.x, foward.y);
        */
        
    }
    
    public void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Building")
        {
            
            GameObject.Destroy(this.gameObject);
        }
    }
}