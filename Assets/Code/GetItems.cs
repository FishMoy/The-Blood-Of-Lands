using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;//��ΪҪ�õ�UI�����Ե�Ҫ������ͷ�ļ�

public class GetItems : MonoBehaviour
{

    Text UItext;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        UItext = GetComponent<Text>();//Ѱ�����UI
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0;i<itemShowedMax;i++)
        {
            textChange(UItext, ((dynamic)ableItem[i]).name);//����ʹ��dynamic��objת���������ͣ��������Զ�ȡ��name����
        }   
    }

    public new int itemShowedMax = 3;

    /*�����ϽӴ�����Ʒ����б����*/
    ArrayList ableItem = new ArrayList();//����
    public void OnCollisionStay(Collision collision)//����Ƿ��нӴ�
    {
        GameObject itemOBJ;
        itemOBJ = GameObject.Find("PickableItem");
        if (collision.gameObject.tag == "item")//����Ƿ��п���ȡ����Ʒ
        {
            itemOBJ.SetActive(true);//����UI

            //�ڴ˻����Ͻ����п�ʰȡ����Ʒ�б�
            for(int i = 0;i<itemShowedMax;i++)
            {
                if(ableItem[i] != collision.gameObject)
                {
                    ableItem.Add(collision.gameObject);//���б������Ԫ��
                }
            }

        }
        else//����û�п�ʰȡ����Ʒʱ
        {
            itemOBJ.SetActive(false);//�ر�UI
            ableItem.RemoveRange(0, itemShowedMax);//����б�
        }
    }

    public virtual void RemoveRange(int index, int count) { }//�����Ʒ����

    public void textChange(Text OBJ,string words)
    {
        OBJ.text += words;//����������ı�
    }
}
