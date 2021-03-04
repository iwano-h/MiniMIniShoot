using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanGenerator : MonoBehaviour
{
    public GameObject human_;
    [SerializeField] public float interval_;
    [SerializeField] public float timer_;
    [SerializeField] public Transform targetTrans_;//Building
    

    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        timer_ += Time.deltaTime;
        if (timer_ < interval_)
        {
            return;
        }
        timer_ = 0;

        

        Vector3 humanPosition = new Vector3(
            targetTrans_.position.x, targetTrans_.position.y, targetTrans_.position.z
            );
        GameObject human = Instantiate(human_, humanPosition, Quaternion.identity);
        
    }
}
