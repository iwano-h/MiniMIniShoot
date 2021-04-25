using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankGenerator : MonoBehaviour
{
    [SerializeField] public GameObject tank_;
    [SerializeField] public float interval_;
    [SerializeField] public float timer_;
    [SerializeField] public Transform targetTrans_;
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

        bool fromLeft = Random.Range(0, 100) > 50;//fromLeftに2/1の確率
        //三項演算子　x が+ か- になる　[targetTrans(player)を中心に-10(左)か、10(右)に2/1の確率で生成される]
        Vector3 tankPosition = new Vector3(
            fromLeft ? targetTrans_.position.x - 10 : targetTrans_.position.x + 10,// x
            0.97f, // y
            targetTrans_.position.z //z
            );
        GameObject tank = Instantiate(tank_, tankPosition, Quaternion.Euler(0f, 90f, 0f));
        tank.GetComponent<Tank>().isLeft_ = !fromLeft;
    }
}
