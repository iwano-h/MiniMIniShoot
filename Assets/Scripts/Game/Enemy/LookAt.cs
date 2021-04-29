using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    GameObject target_;
    // Start is called before the first frame update
    void Start()
    {
        target_ = GameObject.Find("Heli_2"); 
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.LookAt(target_.transform.position);
    }
}
