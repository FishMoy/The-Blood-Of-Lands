using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ThirdPersonCamera : MonoBehaviour
{
    //****变量声明部分***
    float yaw; //yaw的中文意思是航向, 也就是物体绕y轴旋转角度
    float pitch;//pitch是俯仰, 也就是物体绕x轴旋转角度
    public float mouseSensitivity = 10f;//鼠标灵敏度,因为鼠标要控制摄像机转向
    public Transform target,player;
    //1. 这里想要获取一个对象的transform组件的实例, 先声明一个transform以待赋值, 要获取的是游戏角色子对象, 用于确定相机位置
    //2. 这个target会通过编辑器赋值, 就是我创建的CameraPosition子对象, 但是其实直接把相机作为角色的子对象岂不是更好??
    //public float dstFromTarget = 2;//就是相机就距离CameraPosition这个对象两米远
 
    // Start is called before the first frame update
    void Start()
    {
         
    }
 
    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {
        yaw+=Input.GetAxis("Mouse X")*mouseSensitivity;
        pitch-=Input.GetAxis("Mouse Y")*mouseSensitivity;
        Vector3 targetRotation = new Vector3(pitch,yaw,0);//显然我们是不需要摄像机左右倾斜的, 所以z轴锁定为0
        Vector3 playerRotation = new Vector3(0,yaw,0);//显然我们是不需要摄像机左右倾斜的, 所以z轴锁定为0
        //***设置相机旋转***
        //这句话必须要放在下边那句给摄像机角度赋值的语句前边才有用
        //transform.LookAt(target.position);
        //transform.eulerAngles = targetRotation;
       // player.transform.eulerAngles = playerRotation;
        //***设置相机位置***
       //transform.position = target.position-transform.forward*dstFromTarget;
        //总之是Vector3变量做加减, target.position说的是cameraPosition子对象的位置,是在编辑器里赋值的, 这个位置的x轴减两米就是本对象位置(也就是相机位置)
        target.rotation = Quaternion.Euler(pitch,yaw,0);//设置摄像机旋转
        // if(Input.GetKey(KeyCode.W))
        // {
        // player.rotation = Quaternion.Euler(0,yaw,0);//设置角色旋转
        // }
    }
}