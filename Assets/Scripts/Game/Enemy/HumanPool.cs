using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPool : MonoBehaviour
{
    Transform pool; //オブジェクトを保存する空オブジェクトのtransform
    // Start is called before the first frame update
    void Start()
    {
        pool = new GameObject("Human").transform;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void GetObject(GameObject obj, Vector3 pos, Quaternion qua)
    {
        foreach (Transform t in pool)
        {
            //オブジェが非アクティブなら使い回し
            if (!t.gameObject.activeSelf)
            {
                t.SetPositionAndRotation(pos, qua);
                t.gameObject.SetActive(true);//位置と回転を設定後、アクティブにする
            }
        }
        //非アクティブなオブジェクトがないなら生成
        Instantiate(obj, pos, qua, pool);//生成と同時にpoolを親に設定
    }
    //[SerializeField] public GameObject humanPool_;
    //public List<GameObject> poolList_;
    //public const int maxCount = 10;
    /*
    // 最初にある程度の数、オブジェクトを作成してプールしておく処理
    private void CreatePool()
    {
        poolList_ = new List<GameObject>();
        for (int i = 0; i < maxCount; i++)
        {
            var newObj = CreateNewHuman(); // humanを生成して
            newObj.GetComponent<Rigidbody>().velocity = false; // 物理演算を切って(=未使用にして)
            poolList_.Add(newObj); // リストに保存しておく
        }
    }
    public GameObject GetHuman()
    {
        // 使用中でないものを探して返す
        foreach (var obj in poolList_)
        {
            var objrb = obj.GetComponent<Rigidbody>();
            if (objrb.simulated == false)
            {
                objrb.simulated = true;
                return obj;
            }
        }

        // 全て使用中だったら新しく作り、リストに追加してから返す
        var newObj = CreateNewHuman();
        poolList_.Add(newObj);

        newObj.GetComponent<Rigidbody>().simulated = true;
        return newObj;
    }
    // 新しく弾を作成する処理
    private GameObject CreateNewHuman()
    {
        var pos = new Vector2(100, 100); // 画面外であればどこでもOK
        var newObj = Instantiate(poolList_, pos, Quaternion.identity); // 弾を生成しておいて
        newObj.name = poolList_.name + (poolList_.Count + 1); // 名前を連番でつけてから

        return newObj; // 返す
    }
    */

}
