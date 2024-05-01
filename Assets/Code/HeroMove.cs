using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeroMove : MonoBehaviour
{
    /***变量声明区域***/
    public float walkSpeed = 5;
    public float runSpeed = 10;
 
    // Start is called before the first frame update
    void Start()
    {

    }
 
    // Update is called once per frame
    void Update()
    {
        move(Input.GetKeyDown(KeyCode.LeftShift));
    }

    public void move(bool ifShift)
    {
        /*开始判断是否为跑步*/
        float nowSpeed = 0;
        if(ifShift == false)
        {
            nowSpeed = walkSpeed;
        }
        else
        {
            nowSpeed = runSpeed;
        }

        /*开始判断按键*/
        if(Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector3.forward * nowSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector3.forward * -nowSpeed * Time.deltaTime);//加负号是为了控制速度方向的异同
        }
        if(Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector3.right * -nowSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector3.right * nowSpeed * Time.deltaTime);
        }
    }

    /*跳跃*/
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "wall" && Input.GetKey(KeyCode.Space) == true)//检测是否着地和按下按键
        {
            print("space success!");
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 7.5f, 0f), ForceMode.Impulse);
        }
    }

}
