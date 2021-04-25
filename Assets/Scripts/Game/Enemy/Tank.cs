using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public float speed_ = 2;
    public bool isLeft_ = true;
    public GameObject breakEffect_;
    private Rigidbody rb_;
    //public int scoreValue_;  // これが敵を倒すと得られる点数になる
    //private Score score_;//Scoreクラスのインスタンスのscore変数を参照
    //public AudioClip fireSound_;
    // Start is called before the first frame update
    void Start()
    {
        rb_ = GetComponent<Rigidbody>();
        Transform transform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(isLeft_ ? -1 : 1, 0);
        //rb_.velocity = direction * speed_;
        transform.position += transform.forward * speed_;
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Bullet")
        {
            GameObject.Destroy(this.gameObject);
            
            //AudioSource.PlayClipAtPoint(fireSound_, transform.position);
        }
    }
}
