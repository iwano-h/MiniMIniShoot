using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotor : MonoBehaviour
{
    float rotSpeed_ = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotSpeed_ = 10;
        transform.Rotate(0, this.rotSpeed_, 0);
    }
}
