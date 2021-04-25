using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannon : MonoBehaviour
{
    public GameObject enemyMissilePrefab;
    public int shotNamber;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < shotNamber; i++)
        {
            Instantiate(enemyMissilePrefab, transform.position, Quaternion.Euler(0, 180, 0));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
