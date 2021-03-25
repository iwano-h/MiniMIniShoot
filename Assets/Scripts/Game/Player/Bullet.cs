using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public float speed_ = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        //BulletとPlayerの不具合（弾を打つとプレイヤーが回転）Layer　PlayerとBulletを指定
    }   //BulletとPlayerの当たり判定を制御する

    // Update is called once per frame
    void Update()
    {
        //var direction = transform.rotation;
        //Vector3 bulletPos = transform.localPosition;

        //bulletPos.x += speed_ * Time.deltaTime;
        //transform.localPosition = bulletPos;

        //transfrom.forwardはオブジェクトが向いている方向のベクトル、1f*Time.deltaTimeは1m/sの速さで処理を行うことを示す
        Vector3 foward = transform.forward;　
        foward.x = foward.x * speed_;//計算式改変　speed_の数値変更
        foward.y = foward.y * speed_;
        transform.position += foward;//前方方向の向きに対して進行する
        //Debug.LogFormat("x:{0} y:{1}", foward.x, foward.y);

        //if(transform.position.x < -10 && transform.position.x > 10)
        //{
        //    Destroy(gameObject);
        //}
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