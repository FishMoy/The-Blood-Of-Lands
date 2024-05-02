using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;//因为要用到UI，所以得要添加这个头文件

public class GetItems : MonoBehaviour
{

    Text UItext;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        UItext = GetComponent<Text>();//寻找组件UI
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0;i<itemShowedMax;i++)
        {
            textChange(UItext, ((dynamic)ableItem[i]).name);//这里使用dynamic把obj转换成弱类型，进而可以读取其name属性
        }   
    }

    public new int itemShowedMax = 3;

    /*将地上接触的物品变成列表呈现*/
    ArrayList ableItem = new ArrayList();//声明
    public void OnCollisionStay(Collision collision)//检测是否有接触
    {
        GameObject itemOBJ;
        itemOBJ = GameObject.Find("PickableItem");
        if (collision.gameObject.tag == "item")//检测是否有可拿取的物品
        {
            itemOBJ.SetActive(true);//显现UI

            //在此基础上将所有可拾取的物品列表
            for(int i = 0;i<itemShowedMax;i++)
            {
                if(ableItem[i] != collision.gameObject)
                {
                    ableItem.Add(collision.gameObject);//像列表中添加元素
                }
            }

        }
        else//地上没有可拾取的物品时
        {
            itemOBJ.SetActive(false);//关闭UI
            ableItem.RemoveRange(0, itemShowedMax);//清空列表
        }
    }

    public virtual void RemoveRange(int index, int count) { }//清空物品函数

    public void textChange(Text OBJ,string words)
    {
        OBJ.text += words;//向其中添加文本
    }
}
