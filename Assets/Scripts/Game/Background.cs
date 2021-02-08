using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] GameObject bg1_ = null;
    [SerializeField] GameObject bg2_ = null;
    [SerializeField] Transform target_ = null;

    const float WIDTH = 4.15f;
    const float SCALE = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float target_x = target_.localPosition.x;
        float x = Mathf.Floor(target_x / (WIDTH * SCALE)) * WIDTH;
        bg1_.transform.localPosition = new Vector3(x, bg1_.transform.localPosition.y, bg1_.transform.localPosition.z);
        bg2_.transform.localPosition = new Vector3(x + WIDTH, bg1_.transform.localPosition.y, bg1_.transform.localPosition.z);


    }
}
