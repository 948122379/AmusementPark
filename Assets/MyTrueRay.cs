using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//用于对游戏场景中可以交互的物体产生高光效果
//使用时在CHANGENUM_MAX中储存场景中需要高光效果的物体的个数
//然后在Start中对nameArray数组赋值
//最后在Inspector面板中对myrendererArray赋值
//对nameArray赋值的顺序应和对myrendererArray赋值的顺序相同
public class MyTrueRay : MonoBehaviour
{
    public Shader shaderHeighLight;//高光shader
    public int heighLightDisdance;//产生可交互高光的距离
    private bool isChanged = false;
    const int CHANGENUM_MAX = 3;//场景中需要高光效果的物体的个数

    private Shader[] shaderArray;//用于储存模型原本的shader
    public Renderer[] myrendererArray;//用于储存模型的renderer，必须与nameArray[]中的名字对应
    private string[] nameArray;//用于储存产生高光效果的物体的名字
    private int index = 0;//shaderArray和myrendererArray共用
    private int indexSave;//用于储存前一个被改变的shader的数组序号

    public bool CanCommunicateDragon_skin;//大龙是否在视野范围内可交互
    public bool CanCommunicatePlayer;//玩家是否在视野范围内可交互
    public bool CanCommunicateLittleDragon;//小龙是否在视野范围内可交互

    // Use this for initialization
    void Start()
    {
        nameArray = new string[CHANGENUM_MAX];
        shaderArray = new Shader[CHANGENUM_MAX];
        //myrendererArray = new Renderer[CHANGENUM_MAX];

        nameArray[0] = "dragon_skin";
        nameArray[1] = "player";
        nameArray[2] = "LittleDragon";

        for (int i = 0; i < CHANGENUM_MAX; i++)
        {
            shaderArray[i] = myrendererArray[i].material.shader;
        }
        //myrenderer1 = GameObject.Find("hydra").GetComponent<Renderer>();

        CanCommunicateDragon_skin = false;
        CanCommunicatePlayer = false;
        CanCommunicateLittleDragon = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;//返回碰撞信息
        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject gameobj = hitInfo.collider.gameObject;//获得碰撞到的物体
            //index = GetMyIndex(gameobj.name);
            ChangeShader(gameobj.name);
        }
    }

    //计算摄像机与物体之间的距离
    float Disdance(string st)
    {
        GameObject gb = GameObject.Find(st);
        float dis = Mathf.Sqrt(
            Mathf.Pow(gb.transform.position.x - this.transform.position.x, 2) +
            Mathf.Pow(gb.transform.position.y - this.transform.position.y, 2) +
            Mathf.Pow(gb.transform.position.z - this.transform.position.z, 2));
        return dis;
    }
    
    void ChangeShader(string st)
    {
        for (index = 0; index < CHANGENUM_MAX; index++)//检测传进来的名字是不是需要高光效果的物体中的一个
        {
            if (st!=transform.parent.name&&st == nameArray[index] && Disdance(nameArray[index]) < heighLightDisdance && isChanged == false)//Disdance(gameobj.name)为摄像机与碰撞到的物体之间的距离
            {
                myrendererArray[index].material.shader = shaderHeighLight;
                isChanged = true;
                indexSave = index;
                if (indexSave == 0)
                {
                    CanCommunicateDragon_skin = true;
                }
                else if (indexSave == 1)
                {
                    CanCommunicatePlayer = true;
                }
                else if (indexSave == 2)
                {
                    CanCommunicateLittleDragon = true;
                }
            }
            else if (st != transform.parent.name && isChanged == true && (st != nameArray[indexSave] || Disdance(nameArray[indexSave]) >= heighLightDisdance))
            {
                myrendererArray[indexSave].material.shader = shaderArray[indexSave];
                isChanged = false;
                if (indexSave == 0)
                {
                    CanCommunicateDragon_skin = false;
                }
                else if (indexSave == 1)
                {
                    CanCommunicatePlayer = false;
                }
                else if (indexSave == 2)
                {
                    CanCommunicateLittleDragon = false;
                }
            }
        }
    }

}

