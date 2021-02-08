using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public float speed_ = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 bulletPos = transform.position;
        bulletPos.x += speed_ * Time.deltaTime;
        transform.position = bulletPos;
    }

    public void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
