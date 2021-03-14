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
        bool fromLeft = Random.Range(0, 100) > 50;
        

        
        //ターゲットが消ええたときにhumanを生成したい
        Vector3 humanPosition = new Vector3(
            targetTrans_.position.x, // x
            targetTrans_.position.y, // y
            targetTrans_.position.z //z
            );
        GameObject human = Instantiate(human_, humanPosition, Quaternion.Euler(0f, fromLeft ? -90f : 90f, 10f));
        human.GetComponent<Human>().isLeft_ = !fromLeft;


        
    }
}
