using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayButtton2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Test2", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick() {
        Invoke("Test2", 1);
    }

    void Test2()
    {
        Debug.Log("Test");
    }
}
