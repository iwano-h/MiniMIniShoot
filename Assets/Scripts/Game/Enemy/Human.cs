using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    public GameObject breakEffect;
    public float speed_ = 1;
    public bool isLeft_ = true;
    private Rigidbody rb_;
   
    

    // Start is called before the first frame update
    void Start()
    {
        rb_ = GetComponent<Rigidbody>();
        Transform transform = this.transform;
        isLeft_ = Random.Range(0, 100) > 50;
        transform.localEulerAngles = new Vector3(0, isLeft_ ? 180 : 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 direction = new Vector2(isLeft_ ? -1 : 1, 0);
        rb_.velocity = direction * speed_;

   
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            GameObject.Destroy(this.gameObject);
            GetComponent<AudioSource>().Play();
            EffectGo();
        }
    }
    
    void EffectGo()
    {
        GameObject effect = Instantiate(breakEffect) as GameObject;
        effect.transform.position = gameObject.transform.position;
    }
    
}
