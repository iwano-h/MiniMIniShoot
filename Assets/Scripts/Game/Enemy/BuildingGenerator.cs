using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGenerator : MonoBehaviour
{
    public GameObject Building_;
    [SerializeField] public float interval_;
    [SerializeField] public float timer_;
    [SerializeField] public Transform targetTrans_;
    
    //public bool isLeft_ = false;


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

        if (NearBuildingExistsCheck())
        {
            return;
        }



        bool fromLeft = Random.Range(0, 100) > 50;//左右に2/1の確率
        fromLeft = targetTrans_.localEulerAngles.y == 90 ? false : true;//playerが右の時true
        //三項演算子　x が+ か- になる　[targetTrans(player)を中心に-10(左)か、10(右)に2/1の確率で生成される]
        Vector3 buildingPosition = new Vector3(
            fromLeft ? targetTrans_.position.x - 10 : targetTrans_.position.x + 10,
            0.53f, 
            0.95f
            );
        Instantiate(Building_,buildingPosition, Quaternion.Euler(0f,180f,0f));
        //isLeft_ = !fromLeft;
    }

    bool NearBuildingExistsCheck()//近くにビルが有るか？チェックする関数
    {
        //全てのビルを配列にする＜unityのFind関数で格納
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Building");
        foreach (GameObject obj in objects)//foreachで回して、１つ１つ取得しチェック
        {
             
            if (obj.transform.position.x > targetTrans_.position.x - 10 &&
                obj.transform.position.x < targetTrans_.position.x + 10)
            {
                return true;
            }
        }

        return false;
    }


}
