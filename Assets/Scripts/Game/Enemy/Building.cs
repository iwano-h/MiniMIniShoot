using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    //private Rigidbody rb_;
    [SerializeField] public GameObject human_;
    [SerializeField] public Transform appearPoint_;
    private bool canAppear_;
    public GameObject breakEffect;   
    
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
            GetComponent<AudioSource>().Play();
            CreateEffect();
            AppearGo();
        }
    }
    public void AppearGo()
    {
        canAppear_ = true;

        if (canAppear_)
        {
            for (int i = 0; i < 5; i++)
            {
                Instantiate(human_, appearPoint_.position, transform.rotation);
            }

        }
        canAppear_ = false;
    }
    
    void CreateEffect()
    {
        GameObject effect = Instantiate(breakEffect) as GameObject;
        effect.transform.position = gameObject.transform.position;
    }
    

}
