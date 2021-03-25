using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    private float time;
    public int count;
    [SerializeField] public GameObject[] human_;
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
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Bullet")
        {
            GameObject.Destroy(this.gameObject);
            
            CreateEffect();
            AppearGo();
        }
    }
    public void AppearGo()
    {
        canAppear_ = true;
        time -= Time.deltaTime;
        if (time <= 0.0f)
        {
            time = 0.7f;
            count = Random.Range(3, 10);
            Instantiate(human_[count], appearPoint_.position, transform.rotation);
            /*
            for (int i = 0; i < 10; i++)
            {
                Instantiate(human_[count], appearPoint_.position, transform.rotation);
            }
            */
        }
        canAppear_ = false;
    }
    
    void CreateEffect()
    {
        GameObject effect = Instantiate(breakEffect) as GameObject;
        effect.transform.position = gameObject.transform.position;
        GetComponent<AudioSource>().Play();
    }
    

}
