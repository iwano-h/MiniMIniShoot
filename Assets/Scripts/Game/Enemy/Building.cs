using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    //private Rigidbody rb_;
    [SerializeField] public GameObject human_;
    [SerializeField] public Transform appearPoint_;
    private bool canAppear_;
    
    // Start is called before the first frame update
    void Start()
    {
        //rb_ = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Bullet")
        {

            GameObject.Destroy(this.gameObject);

            AppearGo();
        }
    }
    public void AppearGo()
    {
        canAppear_ = true;
        if (canAppear_)
        {
            Instantiate(human_, appearPoint_.position, transform.rotation);

        }
        canAppear_ = false;
    }

}
