using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerController : MonoBehaviour
{
    /***变量声明区域***/
    float walkSpeed = 5;
    float runSpeed = 10;
    Animator animator;//创建一个animator变量以待赋值(在start()方法里赋值)
    public float turnSmoothTime = 0.13f;//设定角色转向平滑时间
    float turnSmoothVelocity;//平滑函数需要这么一个平滑加速度, 不需要为他赋值, 但是需要把这个变量当参数传入
    public float speedSmoothTime = 0.13f;//用于平滑速度
    float speedSmoothVelocity;
    float currentSpeed;
 
    public Transform cameraT;
 
 
 
 
 
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //cameraT = Camera.main.transform;
    }
 
    // Update is called once per frame
    void Update()
    {
        //***WASD输入***//
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));//获取键盘输入
        Vector2 inputDir = input.normalized;//反正就是返回一个单位长度的这个变量
 
        //***角色移动部分***//
        bool running = Input.GetKey(KeyCode.LeftShift);//按了左shift则bool变量running就是1
        float targetSpeed = ((running)?runSpeed:walkSpeed)*inputDir.magnitude;
        
        //Vector3 PlayerMovement = new Vector3(hor,0f,ver)*targetSpeed*Time.deltaTime;
        transform.Translate(transform.forward*targetSpeed*Time.deltaTime,Space.World);//让游戏角色位置移动
        //transform.Translate(PlayerMovement,Space.Self);
 
        //***转向部分***//
        if(inputDir != Vector2.zero)
        //可能是因为键盘自动收入0, 玩家不输入的时候角色就会自动面向正方向, 所以加一个判定, 输入为0的话就是没输入, 所以就不要转向
        {//平滑转向代码
        float targetRotation = Mathf.Atan2(inputDir.x,inputDir.y)*Mathf.Rad2Deg+cameraT.eulerAngles.y;//这就是根据玩家键盘输入算出来的目标转向角度(y轴的)
        transform.eulerAngles = Vector3.up*Mathf.SmoothDampAngle(transform.eulerAngles.y,targetRotation,ref turnSmoothVelocity,turnSmoothTime);
        //上边这个函数是角度渐变, 也可以叫平滑吧, 这个ref是什么意思还存疑, 以后肯定能解决, 还有这个turnSmoothVelocity是什么意思以后迟早能知道, 不急于一时<br>　　　　//这个ref就是引用参数 , 学点C#就知道了 , 用这个参数把方法内的数据给保存出来
        }
 
        /***位置运动部分***/
         //这个inputDir是个单位向量,inputDir.magnitude是他的长度,有任何输入的时候单位向量的长度都是1, 在键盘没有输入的时候这个长度就是0
        //其实之所以乘以这个长度就是为了能够在玩家没有输入的时候把速度变成0
        //currentSpeed = Mathf.SmoothDamp(currentSpeed,targetSpeed,ref speedSmoothVelocity,speedSmoothTime);
        //看起来这个函数SmoothDamp以及上边的SmoothDampAngle一样, 他们的第一个参数其实是被赋值的, 直接把空参数传进去, 就能获得合适的值
         
        
 
        float animationSpeedPercent = ((running)?0.75f:0.25f)*inputDir.magnitude;//通过布尔变量给动画状态机控制变量赋值
        animator.SetFloat("speedPercent",animationSpeedPercent,speedSmoothTime,Time.deltaTime);
        //1. 通过调用animator变量的setfloat函数给混合状态机的speedPercent参数赋值
        //2. 这个函数有四个参数, 第三个是自带的平滑参数, 可以通过给这个参数赋值来实现动画状态机自动平滑动作
 
 
 
    }
 
}