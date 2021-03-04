using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    public float speed_ = 1;
    public bool isLeft_ = true;
    public Vector2 horizontal_;
    

    // Start is called before the first frame update
    void Start()
    {
        //rb_ = GetComponent<Rigidbody>();
        Transform transform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 horizontal_ = new Vector2(isLeft_ ? -1 : 1, 0);
        transform.localPosition = horizontal_ * speed_;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
