using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    public float speed_ = 10;
    public bool isLeft_ = true;

    private Rigidbody rb_;
    


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
       
        /*
        if (isLeft_) {
            direction = new Vector2(-1, 0);
        } else {
            direction = new Vector2(1, 0);
        }
        */

    }

    private void OnCollisionEnter(Collision collision)
    {
        //OnCollisioonEnterメソッド(当たったら消える)〜inspectorにBoxColligerをAdd Componnentする
        Debug.Log(collision.gameObject.tag);//inspectorのtagでグループ分けをする"Ballet"グループにする
        if(collision.gameObject.tag == "Bullet") {
            GameObject.Destroy(this.gameObject);//Balletグループに接触すると、このgameObjectは消える
        }
    }
}
