using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float speed_ = 3;
    public VariableJoystick joystick_;
   
    private Rigidbody rb_;

    
    //[SerializeField] public GameObject bullet_; //バレットプレハブを格納（弾単発）
    //[SerializeField] public Transform attackPoint_;//アタックポイントを格納(使われてない)

    [SerializeField] public float attackTime_ = 0.1f; //攻撃の間隔
    private float currentAttackTime_; //攻撃の間隔を管理
    private bool canAttack_; //攻撃可能状態かを指定するフラグ
    //private float moveTime;
    public bool moved = false;

    public float gravity = 1.0f;
    public GameObject breakEffect;

    public GameObject questionPanel;

    void Start()
    {
        
        currentAttackTime_ = attackTime_; //currentAttackTimeにattackTimeをセット。
        rb_ = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        moved = false;
        //moveTime = Time.deltaTime;
        Vector3 moveVector = (Vector3.right * joystick_.Horizontal + Vector3.forward * joystick_.Vertical);
       //  joystick 
        Transform transform = this.transform;
        Vector2 localAngle = transform.localEulerAngles;
        float targetAngleX = 0;//0度
        //Debug.Log(joystick_.Horizontal);で確認　左−1、0、右1
        
        if (0 < joystick_.Horizontal)//右
        {
            targetAngleX = 45;                          //localAngle.x += (45 - 0)/3
            localAngle.y = 90;                          //15 += (45 - 15)/3
            moved = true;                               //25 += (45 - 25)/3
        } else if(0 > joystick_.Horizontal) //左        //31.67 += (45 - 31.67)/3 
        {                                               //36.11 += (45 - 36.11)/3
            targetAngleX = 45;                          //39.07 += (45 - 39.07)/3
            localAngle.y = -90;                         //45 += (45 - 45)/3なるまで処理が続く
            moved = true;
        } else // default左右を入力していない時
        {
            targetAngleX = 0;
            moved = false;
        }

        if(joystick_.Vertical > 0)//上昇時
        {
            targetAngleX = 0;
            moved = true;
        }

        localAngle.x += (targetAngleX - localAngle.x) / 3;//＊ターゲットに徐々に近づく式     
        transform.localEulerAngles = localAngle;//toransform.localEulerAnglesはオイラー角（~度etc）を取得する
        //rotationでの返り値はQuatertionであるためVector3は代入できない（オイラー角取得不可）

        // 移動する向きを求める
        // x と y の入力値を正規化して direction に渡す
        Vector2 direction = joystick_.Direction;//new Vector2(x, y).normalized;
        direction.y -= gravity;
        // 移動する向きとスピードを代入する
        // Rigidbody コンポーネントの velocity に方向と移動速度を掛けた値を渡す
        rb_.velocity = direction * speed_;


        //CheckAttack();//AttackするかどうかなのでCheckAttackメソッド(弾単発)
    }
    /*(弾単発)
    public void CheckAttack()
    {
       
        attackTime_ += Time.deltaTime; //attackTimeに毎フレームの時間を加算していく

        if (attackTime_ > currentAttackTime_)
        {
            canAttack_ = true; //指定時間を超えたら攻撃可能にする
        }

        if (Input.GetKeyDown(KeyCode.A)) //Kキーを押したら
        {
            GetComponent<AudioSource>().Play();
            if (canAttack_)
            {
                //Debug.Log(attackPoint_.position);
                //第一引数に生成するオブジェクト、第二引数にVector3型の座標、第三引数に回転の情報
                Instantiate(bullet_, attackPoint_.position,
                    transform.rotation);
                canAttack_ = false;　//攻撃フラグをfalseにする
                attackTime_ = 0f;　//attackTimeを0に戻す
            }
        }
    }
    */
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Building")
        {
            this.gameObject.SetActive(false);//this.gameObjectを非アクティブにする(オブジェクトを非表示にする)
            CreateEffect();
            Invoke("CreatePanel", 1.5f);
            
        }
    }
        /*
    
    public void Change()
    {
        SceneManager.LoadScene("Gameover");
    }
        */
    void CreateEffect()
    {
        GameObject effect = Instantiate(breakEffect) as GameObject;
        effect.transform.position = gameObject.transform.position;
        
    }
    void CreatePanel()
    {
        questionPanel.SetActive(true);
        Time.timeScale = 0f;
    }




}