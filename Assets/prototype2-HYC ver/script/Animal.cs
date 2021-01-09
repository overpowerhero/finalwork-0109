using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// tset github
// shiouuu test
//HYC test 1/08 10pm

public class Animal : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody enemyRb;//lok 0108
    private GameObject player;//lok 0108

    // Start is called before the first frame update
    void Start()
    {
        //lok 0108-HYC
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Human");
    }
     
    // Update is called once per frame
    void Update()
    {
        //lok 0108
        Vector3 lookDirection = (player.transform.position- transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed );//問老師速度怎麼調
    }
}
