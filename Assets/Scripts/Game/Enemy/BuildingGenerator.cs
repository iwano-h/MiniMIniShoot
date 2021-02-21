using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGenerator : MonoBehaviour
{
    public GameObject Building_;
    [SerializeField] public float interval_;
    [SerializeField] public float timer_;
    [SerializeField] public Transform targetTrans_;
    public bool isLeft_ = false;

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

        bool fromLeft = Random.Range(0, 100) > 50;//左右に2/1の確率
        //三項演算子　x が+ か- になる　[targetTrans(player)を中心に-10(左)か、10(右)に2/1の確率で生成される]
        Vector3 buildingPosition = new Vector3(
            fromLeft ? targetTrans_.position.x - 10 : targetTrans_.position.x + 10,
            0.52f, 
            targetTrans_.position.z
            );
        Instantiate(Building_,buildingPosition, Quaternion.identity);
        isLeft_ = !fromLeft;
    }
}
