using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed_ = 3;
    public VariableJoystick joystick_;
   
    private Rigidbody rb_;


    [SerializeField] public GameObject bullet_; //バレットプレハブを格納
    [SerializeField] public Transform attackPoint_;//アタックポイントを格納

    [SerializeField] public float attackTime_ = 0.2f; //攻撃の間隔
    private float currentAttackTime_; //攻撃の間隔を管理
    private bool canAttack_; //攻撃可能状態かを指定するフラグ

    void Start()
    {
        
        currentAttackTime_ = attackTime_; //currentAttackTimeにattackTimeをセット。
        rb_ = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        Vector3 moveVector = (Vector3.right * joystick_.Horizontal + Vector3.forward * joystick_.Vertical);
        // 右・左のデジタル入力値を x に渡す
        float x = joystick_.Horizontal;//Input.GetAxisRaw("Horizontal");
        // 上・下のデジタル入力値 y に渡す
        float y = joystick_.Vertical;//Input.GetAxisRaw("Vertical");
        // 移動する向きを求める
        // x と y の入力値を正規化して direction に渡す
        Vector2 direction = joystick_.Direction;//new Vector2(x, y).normalized;
        // 移動する向きとスピードを代入する
        // Rigidbody コンポーネントの velocity に方向と移動速度を掛けた値を渡す
        rb_.velocity = direction * speed_;

        Attack();
    }

    public void Attack()
    {
        
        attackTime_ += Time.deltaTime; //attackTimeに毎フレームの時間を加算していく

        if (attackTime_ > currentAttackTime_)
        {
            canAttack_ = true; //指定時間を超えたら攻撃可能にする
        }

        if (Input.GetKeyDown(KeyCode.K)) //Kキーを押したら
        {
            if (canAttack_)
            {
                //第一引数に生成するオブジェクト、第二引数にVector3型の座標、第三引数に回転の情報
                Instantiate(bullet_, attackPoint_.position, bullet_.transform.rotation);
                canAttack_ = false;　//攻撃フラグをfalseにする
                attackTime_ = 0f;　//attackTimeを0に戻す
            }
        }
    }



}