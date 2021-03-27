using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    
    private float screenSide_;
    private Rigidbody rb_;
    [SerializeField] public GameObject human_ = null;
    [SerializeField] public Transform appearPoint_;
    private bool canAppear_;
    public float apperDely_ = 0.1f;
    public GameObject breakEffect;   
    
    // Start is called before the first frame update
    void Start()
    {
        
        
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

            rb_ = GetComponent<Rigidbody>();
            StartCoroutine(AppearGo());
        }
    }
    IEnumerator AppearGo()
    {
        while (true)
        {
            CanAppear();
            yield return new WaitForSeconds(apperDely_);
        }
        
    }
    public void CanAppear()
    {
        //canAppear_ = true;
        bool fromLeft = Random.Range(0, 100) > 50;
        human_.GetComponent<Human>().isLeft_ = !fromLeft;
        Instantiate(human_, appearPoint_.position, transform.rotation);
        screenSide_ = Camera.main.ViewportToWorldPoint(new Vector2(fromLeft ? 1 : -1, 0)).x;
        //画面の両サイドの座標を取得
        if (canAppear_ == false)
        {
            return;
        }
        if (this.transform.position.x > screenSide_ + 1)
        {
            canAppear_ = false;
        }


        /*
        for (int i = 0; i < 10; i++)
        {
            Instantiate(human_, appearPoint_.position, transform.rotation);
        }
        */

        //canAppear_ = false;
    }


    void CreateEffect()
    {
        GameObject effect = Instantiate(breakEffect) as GameObject;
        effect.transform.position = gameObject.transform.position;
        GetComponent<AudioSource>().Play();
    }
    

}
