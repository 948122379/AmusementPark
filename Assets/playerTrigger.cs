using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerTrigger : MonoBehaviour
{


    public bool isBeThrow;//小龙是否被扔下悬崖,是连接小龙脚本中换摄像机的开关
    public bool isCatchLDragon;//小龙是否已经被抓，是连接小龙脚本中换被抓效果的开关
    [HideInInspector]
    public bool isGetMission;//玩家是否已经找大龙接任务
    [HideInInspector]
    public bool isPerformMission;//是否已经完成任务
    private bool isHandInMission;//是否已经找大龙交任务

    public bool isChangeBack;//是否可以换回自己的身体
    [HideInInspector]
    public bool isCanCatch;//小龙是否能被抓，用来添加小龙在视野内才可以抓的条件////////////////未做
    [HideInInspector]
    public bool isCanGetMission;//玩家是否能接任务，用来添加大龙在视野内才可以接任务的条件////////////////未做
    [HideInInspector]
    public bool isCanChangeBack;//是否可以换回自己的身体，用来添加玩家在视野内才可以换回身体的条件////////////////未做

    private int tryCatchNeedNum = 4;//抓小龙时需要连续按键的次数
    private int tryCatchNum = 0;//抓小龙时，连续按键的次数
    private int backCatchNum = 0;//抓小龙抓一般中断时，需要显示的抓取进度条
    [HideInInspector]
    public bool ismedalSwitchOn;//蒲公英勋章开关是否被打开
    public int modelMax = 8;//最大勋章数,公有变量需要在窗口中设置，这里赋值无效
    [HideInInspector]
    public int modelNum;//已收集的勋章数,被TriggerToExplode用来检测是否破碎
    private Vector3 aimPosition;
    // Use this for initialization
    void Start()
    {
        if (gameObject.name == "LittleDragon")
        {
            isBeThrow = true;

            isCatchLDragon = true;
            isCanCatch = true;

            isGetMission = true;
            isCanGetMission = true;
            isPerformMission = false;
            isHandInMission = false;

            isChangeBack = false;
            isCanChangeBack = false;
        }
        else if (gameObject.name == "player")
        {
            isBeThrow = false;
            isCatchLDragon = false;
            isCanCatch = false;
            isGetMission = false;
            isCanGetMission = false;
            isPerformMission = false;
            isHandInMission = false;
            isChangeBack = false;
            isCanChangeBack = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //魔法阵旋转
        //GameObject.Find("medalSwitch").transform.rotation = Quaternion.Euler(GameObject.Find("medalSwitch").transform.rotation.x, Time.time * 100, GameObject.Find("medalSwitch").transform.rotation.z);
        //箭头始终指向玩家
        GameObject.Find("arrows").transform.LookAt(transform.position);
        //交互部分
        if (isGetMission == false)//如果还未接任务，判断是否在大龙附近，如果在附近则打开可以接任务的开关，若不在附近则关闭开关
        {
            if (GameObject.Find(gameObject.name + "/Camera").GetComponent<MyTrueRay>().CanCommunicateDragon_skin == true)
            {
                isCanGetMission = true;
                GameObject.Find("dragon_skin").transform.LookAt(new Vector3(transform.position.x, GameObject.Find("dragon_skin").transform.position.y, transform.position.z));
                GameObject.Find("Canvas/Text").GetComponent<Text>().text = "大龙希望你能教教它孩子飞翔，你能帮助大龙完成它的心愿吗？按左键/手柄A键接受任务";
            }
            else
            {
                isCanGetMission = false;
                if (GameObject.Find(gameObject.name + "/Camera").GetComponent<MyTrueRay>().CanCommunicateLittleDragon == true)//如果还未接任务，判断是否与小龙交互
                {
                    GameObject.Find("LittleDragon").transform.LookAt(new Vector3(transform.position.x, GameObject.Find("LittleDragon").transform.position.y, transform.position.z));
                    GameObject.Find("Canvas/Text").GetComponent<Text>().text = "要抓小龙，需要征得山脚下的大龙的同意";
                }
                else if (GameObject.Find(gameObject.name + "/Camera").GetComponent<MyTrueRay>().CanCommunicateLittleDragon == false)
                {
                    GameObject.Find("Canvas/Text").GetComponent<Text>().text = "大龙有事情要拜托你，沿着面前的红林小径可以找到大龙";
                }

            }
        }
        else if (isGetMission == true)
        {
            if (isCatchLDragon == false)//如果还没抓小龙，判断是否在小龙附近，如果在附近则打开可以抓的开关，若不在附近则关闭开关
            {
                if (GameObject.Find(gameObject.name + "/Camera").GetComponent<MyTrueRay>().CanCommunicateLittleDragon == true)
                {
                    isCanCatch = true;
                    GameObject.Find("LittleDragon").transform.LookAt(new Vector3(transform.position.x, GameObject.Find("LittleDragon").transform.position.y, transform.position.z));
                    GameObject.Find("Canvas/Text").GetComponent<Text>().text = "按下F键/手柄LB键 " + (tryCatchNeedNum - tryCatchNum + 1).ToString() + " 次抓住小龙";
                }
                else
                {
                    isCanCatch = false;

                    if (GameObject.Find(gameObject.name + "/Camera").GetComponent<MyTrueRay>().CanCommunicateDragon_skin == true)//如果还没抓小龙，判断是否在大龙附近
                    {
                        GameObject.Find("dragon_skin").transform.LookAt(new Vector3(transform.position.x, GameObject.Find("dragon_skin").transform.position.y, transform.position.z));
                        GameObject.Find("Canvas/Text").GetComponent<Text>().text = "大龙：顺着小路上山可以找到小龙哦";
                    }
                    else
                    { 
                        GameObject.Find("Canvas/Text").GetComponent<Text>().text = "首先你要抓住淘气的小龙，顺着小路上山你可以找到小龙";
                        if (tryCatchNum >= 0)//小龙超出视野，清空连抓次数,显示抓取进度条
                        {
                            GameObject.Find("LittleDragon/LoadCatch/Cube" + tryCatchNum.ToString()).GetComponent<MeshRenderer>().enabled = true;
                            if (tryCatchNum > 0)
                            {
                                tryCatchNum--;
                            }
                        }
                    }
                }
            }
            else if (isCatchLDragon == true)//如果抓到小龙，
            {
                if (isPerformMission == true)//如果完成任务
                {
                    if (isHandInMission == false)
                    {
                        if (GameObject.Find(gameObject.name + "/Camera").GetComponent<MyTrueRay>().CanCommunicateDragon_skin == true)
                        {
                            GameObject.Find("dragon_skin").transform.LookAt(new Vector3(transform.position.x, GameObject.Find("dragon_skin").transform.position.y, transform.position.z));
                            GameObject.Find("Canvas/Text").GetComponent<Text>().text = "大龙：你真腻害~，你可以去前面换回你的身体啦";
                            isHandInMission = true;

                            aimPosition = GameObject.Find("player").transform.position;
                            GameObject.Find("arrows").transform.position = new Vector3(aimPosition.x, aimPosition.y + 15, aimPosition.z);
                        }
                        else
                        {
                            GameObject.Find("Canvas/Text").GetComponent<Text>().text = "你已收集齐所有勋章，快回去找你妈妈吧！你可以在那里换回身体";
                        }
                    }
                    else if (isHandInMission == true && isChangeBack == false)//如果已经完成任务，但是还没有换回身体，判断是否在玩家附近，如果在附近则打开可以换身体的开关，若不在附近则关闭开关
                    {
                        if (GameObject.Find(gameObject.name + "/Camera").GetComponent<MyTrueRay>().CanCommunicateDragon_skin == true)
                        {
                            GameObject.Find("dragon_skin").transform.LookAt(new Vector3(transform.position.x, GameObject.Find("dragon_skin").transform.position.y, transform.position.z));
                            if (gameObject.name == "player")
                            {
                                GameObject.Find("Canvas/Text").GetComponent<Text>().text = "大龙：十分感谢";
                            }
                            else if (gameObject.name == "LittleDragons")
                            {
                                GameObject.Find("Canvas/Text").GetComponent<Text>().text = "大龙：你真腻害~，你可以去前面换回你的身体啦";
                            }
                        }
                        else if (GameObject.Find(gameObject.name + "/Camera").GetComponent<MyTrueRay>().CanCommunicatePlayer == true)
                        {
                            isCanChangeBack = true;
                            GameObject.Find("Canvas/Text").GetComponent<Text>().text = "按下左键/手柄A键可以换回身体";
                        }
                        else
                        {
                            isCanChangeBack = false;
                            GameObject.Find("Canvas/Text").GetComponent<Text>().text = "你需要在身体附近才可以换回身体";
                        }
                    }
                    else if (isChangeBack==true)
                    {
                        GameObject.Find("Canvas/Text").GetComponent<Text>().text = "你已经完成大龙的心愿，欢迎你在附近参观";
                    }
                }
            }
        }

        //如果按下手柄A键，不同状态有相应不同的作用
        if (Input.GetKeyDown(KeyCode.Joystick1Button0)||Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (isPerformMission == false)//如果还未完成任务
            {
                if (isGetMission == true)//如果玩家已经找大龙接了任务
                {
                    if (ismedalSwitchOn == true)//如果蒲公英勋章开关是打开状态
                    {
                        if (isBeThrow == false)//小龙没有被扔下悬崖
                        {
                            isBeThrow = true;
                            GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
                            GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(new Vector3(216.89f, 0.75f, 184f));
                            GameObject.Find("Canvas/Text").GetComponent<Text>().text = "你已附身在小龙身上，快去你后面的紫林山谷收集徽章！";
                            for (int i = 0; i < modelMax; i++)//打开勋章检测碰撞开关，使之可收集
                            {
                                GameObject.Find("medal/Sphere_" + i.ToString()).GetComponent<SphereCollider>().isTrigger = true;
                            }
                        }
                        else//小龙已经被扔下悬崖
                        {
                            GameObject.Find("Canvas/Text").GetComponent<Text>().text = "你已收集 " + modelNum.ToString() + " 个蒲公英勋章";
                            //GameObject.Find("player/Canvas/Text").GetComponent<Text>().text="按下“A”键查看你收集的勋章数目";
                        }
                    }
                    else
                    {//如果蒲公英勋章开关是关闭状态，判断是否已经抓了小龙
                        if (isCatchLDragon == false)//如果还没抓小龙
                        {
                            /*if (isCanCatch == true)//如果可以抓小龙
                            {
                                tryCatchNum++;
                                if (tryCatchNum >= tryCatchNeedNum)
                                {
                                    GameObject.Find("Canvas/Text").GetComponent<Text>().text = "√get 1 小龙，接下来带着小龙去悬崖边开启法阵吧";
                                    isCatchLDragon = true;
                                }
                            }*/
                            //换成RT键抓小龙了
                        }
                    }
                }
                else if (isGetMission == false)//如果玩家还没找大龙接任务
                {
                    if (isCanGetMission == true)//如果玩家目前可以向大龙接任务
                    {
                        GameObject.Find("Canvas/Text").GetComponent<Text>().text = "首先你要抓住淘气的小龙，顺着小路上山你可以找到小龙";
                        isGetMission = true;

                        aimPosition = GameObject.Find("LittleDragon").transform.position;
                        GameObject.Find("arrows").transform.position = new Vector3(aimPosition.x, aimPosition.y + 20, aimPosition.z);
                    }
                }
            }
            else//如果已经完成任务
            {
                if (isChangeBack == false)//如果还未换回身体
                {
                    if (isCanChangeBack == true)
                    {//如果能够换回身体
                        GameObject.Find("Canvas/Text").GetComponent<Text>().text = "你已经换回你的身体了";
                        isChangeBack = true;
                        GameObject.Find("arrows").GetComponent<MeshRenderer>().enabled = false;
                    }
                }
            }
        }

        //如果按下手柄LB键,抓小龙
        if (Input.GetKeyDown(KeyCode.Joystick1Button6) || Input.GetKeyDown(KeyCode.F))
        {
            if (gameObject.name == "player")//如果是玩家状态
            {
                if (isCanCatch == true)//如果可以抓小龙
                {
                    if (tryCatchNum >= tryCatchNeedNum)
                    {
                        GameObject.Find("Canvas/Text").GetComponent<Text>().text = "√get 1 小龙，接下来带着小龙去悬崖边开启法阵吧";
                        isCatchLDragon = true;
                    }
                    else
                    {
                        tryCatchNum++;
                        GameObject.Find("LittleDragon/LoadCatch/Cube" + (tryCatchNum - 1).ToString()).GetComponent<MeshRenderer>().enabled=false;
                        GameObject.Find("LittleDragon/Point light").GetComponent<Light>().enabled = true;
                        //GameObject.Find("Canvas/Text").GetComponent<Text>().text = "再按“LB”键 " + (tryCatchNeedNum-tryCatchNum).ToString() + " 次抓住小龙";//放到上面互动判断里了
                    }
                }
            }
        }
        else 
        {
            if (isCatchLDragon == false)
            {
                GameObject.Find("LittleDragon/Point light").GetComponent<Light>().enabled = false;
            }
            else
            {
                if (isBeThrow == true)
                {
                    if(GameObject.Find("player/LittleDragon/Point light")){
                        GameObject.Find("player/LittleDragon/Point light").GetComponent<Light>().enabled = false;
                    }
                    else if (GameObject.Find("LittleDragon/Point light"))
                    {
                        GameObject.Find("LittleDragon/Point light").GetComponent<Light>().enabled = false;
                    }
                }
            }
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        //控制玩家时
        if (isPerformMission == false)
        {
            if (gameObject.name == "player")
            {
                if (isGetMission == true)
                {//如果已经接了任务
                    //还未抓小龙时
                    if (isCatchLDragon == false)
                    {
                        if (coll.name == "medalSwitch")//还未抓小龙时,碰撞蒲公英勋章开关时，打开蒲公英勋章开关
                        {
                            GameObject.Find("Canvas/Text").GetComponent<Text>().text = "开启法阵需要小龙的魔力，你需要先抓住一只小龙";
                        }
                        else if (coll.name == "dragon_skin")//碰撞大龙时，提示快去完成任务,放到上面Updata函数里了
                        {
                        }
                    }
                    //已经抓住小龙
                    else
                    {
                        if (coll.name == "medalSwitch")//已经抓住小龙,碰撞蒲公英勋章开关时，打开蒲公英勋章开关,打卡箭头提示
                        {
                            GameObject.Find("Canvas/Text").GetComponent<Text>().text = "蒲公英徽章收集开关已打开，按下左键/手柄A键扔下小龙即可开始收集勋章";
                            ismedalSwitchOn = true;

                            aimPosition = GameObject.Find("medal/Sphere_0").transform.position;
                            GameObject.Find("arrows").transform.position = new Vector3(aimPosition.x, aimPosition.y + 20, aimPosition.z);
                        }
                        else if (coll.name == "dragon_skin")//碰撞大龙时，提示带小龙快去开启魔法阵
                        {
                            /*if (isHandInMission == false)
                            {
                                GameObject.Find("dragon_skin").transform.LookAt(new Vector3(transform.position.x, GameObject.Find("dragon_skin").transform.position.y, transform.position.z));
                                GameObject.Find("Canvas/Text").GetComponent<Text>().text = "大龙：你需要开法阵才能开始教它飞翔";
                            }
                            else
                            {

                            }*/
                        }
                    }
                }
                else//如果还未接任务
                {
                    if (coll.name == "dragon_skin")//还未接任务,碰撞到大龙，放到上面Updata函数里了
                    {
                    }
                    else if (coll.name == "medalSwitch")//还未接任务,碰撞法阵开关
                    {
                        GameObject.Find("Canvas/Text").GetComponent<Text>().text = "开启法阵需要小龙的魔力，你需要先抓住一只小龙";
                    }
                    else if (coll.name == "LittleDragon")//还未接任务,碰撞到小龙，放到上面Updata函数里了
                    {
                    }
                    else //还未接任务,碰撞到蒲公英
                    {
                        GameObject.Find("Canvas/Text").GetComponent<Text>().text = "你需要先开启法阵，才能开始收集蒲公英勋章";
                    }
                }
            }

            //控制小龙时,可以收集勋章
            else if (gameObject.name == "LittleDragon")
            {
                if (coll.name == "Sphere_" + modelNum.ToString())//碰撞蒲公英勋章时，收集蒲公英勋章,实时改变提示箭头位置
                {
                    modelNum++;
                    if (modelNum == modelMax)//如果收集齐蒲公英勋章，提示去交任务，可以去大龙那里换回身体
                    {
                        isPerformMission = true;
                        GameObject.Find("Canvas/Text").GetComponent<Text>().text = "你已收集齐所有勋章，快回去找你妈妈吧！你可以在那里换回身体";

                        aimPosition = GameObject.Find("dragon_skin").transform.position;
                        GameObject.Find("arrows").transform.position = new Vector3(aimPosition.x, aimPosition.y + 25, aimPosition.z);
                    }
                    else
                    {
                        GameObject.Find("Canvas/Text").GetComponent<Text>().text = "你已收集 " + modelNum.ToString() + " 个蒲公英勋章";
                        aimPosition = GameObject.Find("medal/Sphere_" + modelNum.ToString()).transform.position;
                        GameObject.Find("arrows").transform.position = new Vector3(aimPosition.x, aimPosition.y + 20, aimPosition.z);
                    }
                }
                else if (coll.name == "medalSwitch")//小龙碰撞蒲公英勋章开关时，提示法阵已无效
                {
                    if (isBeThrow == true)
                    {
                        GameObject.Find("Canvas/Text").GetComponent<Text>().text = "法阵已失效，你需要收集齐勋章后再找到你的身体才能换回去";
                    }
                }
                else if (coll.name == "dragon_skin")//碰撞大龙时，提示快去收集徽章
                {

                }
                else if (coll.name == "player")//小龙完成任务碰撞身体时，这个接反应放到上面Updata函数里了
                {
                }
                else if (coll.name.Substring(0, 6) == "Sphere_") //没有按顺序碰撞蒲公英勋章时，给出提示
                {
                    GameObject.Find("Canvas/Text").GetComponent<Text>().text = "请按顺序收集蒲公英勋章,你已收集 " + modelNum.ToString() + " 个蒲公英勋章";
                }
            }
        }
        else
        {
            if(gameObject.name=="player"){
                GameObject.Find("Canvas/Text").GetComponent<Text>().text = "你已经完成大龙的心愿，欢迎你在附近随意参观";
            }
        }

    }
}
