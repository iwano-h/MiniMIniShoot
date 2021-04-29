using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannon : MonoBehaviour
{
    public GameObject enemyMissilePrefab;
    //public int shotNamber;
    //int count_ = 0;
    GameObject player_;
    Score score_;
    
    // Start is called before the first frame update
    void Start()
    {
        player_ = GameObject.Find("Heli_2");
        /*
        for (int i = 0; i < shotNamber; i++)
        {
            Instantiate(enemyMissilePrefab, transform.position, Quaternion.Euler(0, 180, 0));
        }*/
        
    }

    // Update is called once per frame
    void Update()
    {
        if (score_.score >= 1000)
        {
            float shotSpeed = 8.0f;
            
            Vector2 vec = player_.transform.position - transform.position;
            vec.Normalize();
            vec *= shotSpeed;
            var t = Instantiate(enemyMissilePrefab, transform.position, enemyMissilePrefab.transform.rotation);
            t.GetComponent<Rigidbody>().velocity = vec;

        }
        else
        {
            return;
        }
        
    }
}
