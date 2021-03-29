using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] public float speed_ = 0.1f;
    public GameObject bulletPrefab_;//連射
    public AudioClip fireSound_;
    private int timeCount_;//連射
    const int SHOT_INTERVAL = 10;

    // Start is called before the first frame update
    void Start()
    {
        
        //BulletとPlayerの不具合（弾を打つとプレイヤーが回転）Layer　PlayerとBulletを指定
    }   //BulletとPlayerの当たり判定を制御する

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
            timeCount_++;

            //カウントが発射間隔に達したら、弾を発射
            if (timeCount_ > SHOT_INTERVAL)
            {
                timeCount_ = 0;  //カウント初期化
                //キャノンのtransform.position,transform.rotationでバレットプレハブを生成する。
                GameObject bullet = Instantiate(bulletPrefab_, transform.position,transform.rotation) as GameObject;
                AudioSource.PlayClipAtPoint(fireSound_, transform.position);
                /*Vector3 foward = transform.forward;
                foward.x = foward.x * speed_;//計算式改変　speed_の数値変更
                foward.y = foward.y * speed_;
                transform.position += foward;//前方方向の向きに対して進行する
                */
                //Destroy(bullet, 2.0f);
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
    
    
}