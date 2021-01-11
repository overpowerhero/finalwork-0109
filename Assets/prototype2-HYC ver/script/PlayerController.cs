using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 30;
    public float horizontalInput;
    public float verticalInput;

    //1/10 zixinma

    public float jumpForce = 10;
    public float gravityModifier = 5;
    public bool isOnGround = true;
    private Rigidbody playerRb;

    private int xRange = 20;

    //1/11 zixinma
    private int zRange = 60;
    public float forwardInput;


    public GameObject flyFood;
    // Start is called before the first frame update
    void Start()
    {

       playerRb = GetComponent<Rigidbody>();
       Physics.gravity *= gravityModifier;

        //1/10馬子馨
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        //limit bound
        if (transform.position.x < -xRange) // too left
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange) // too right
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        //1/11 zixinma (前面無法固定，但後面可以)

        if (transform.position.z < -zRange) // 前
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }

        if (transform.position.z > zRange) // 後
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }


        //需要再加後面?
        // Generate fly food
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(flyFood, transform.position, flyFood.transform.rotation);
        }

       if (Input.GetKeyDown(KeyCode.C) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

   private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
    //問老師這邊跟第三張不同的地方是有無用標籤，他不會自動落下來碰到地板 已解決 現在是有機率掉到地板底下
}
