using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 0.1f;
    //public Renderer renderer_;//*
    //Transform playerTrans_;//*


    // Start is called before the first frame update
    void Start()
    {
        //playerTrans_ = GameObject.Find("Heli_2").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed;
        /*if (!renderer_.isVisible && Vector3.Distance(gameObject.transform.position, playerTrans_.position) > 20)
        {
            GameObject.Destroy(this.gameObject);
        }*/
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
