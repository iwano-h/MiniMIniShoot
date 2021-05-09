using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissile : MonoBehaviour
{
    public float speed = 1f;
    Rigidbody rb_;
    GameObject target_;
    // Start is called before the first frame update
    void Start()
    {
        rb_ = GetComponent<Rigidbody>();
        target_ = GameObject.Find("Heli_2");
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.LookAt(target_.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
        }
        
    }
}
