using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class littleDragon : MonoBehaviour
{
    private bool isBeThrow;
    private bool isChangeCamera;

    private bool isCatchLDragon;
    private bool isChangeBeCatch;

    private bool isChangeBack;
    private bool isOverChangeBack;

    private bool isOverRotateCamera;
    public int angleSpeed;
    private int angle1;
    private int angle2;
    // Use this for initialization
    void Start()
    {
        isChangeCamera = false;
        isChangeBeCatch = false;
        isOverRotateCamera = false;
        isOverChangeBack = false;
    }

    // Update is called once per frame
    void Update()
    {
        //从playerTrigger中获得状态
        isBeThrow = GameObject.Find("player").GetComponent<playerTrigger>().isBeThrow;
        isCatchLDragon = GameObject.Find("player").GetComponent<playerTrigger>().isCatchLDragon;
        isChangeBack = GameObject.Find("LittleDragon").GetComponent<playerTrigger>().isChangeBack;
        if (isChangeBack == false)//如果不需要换回身体
        {
            if (isCatchLDragon == true)//如果抓到了小龙
            {
                if (isChangeBeCatch == true)//如果小龙已经由被未抓状态转换为已被抓状
                {
                    if (isBeThrow == true)//如果小龙已经被扔
                    {
                        if (isChangeCamera == false)//如果小龙已经被扔，而且摄像机还没切换，则切换摄像机
                        {
                            //播放切换镜头动画
                            print("已附身小龙");
                            transform.parent = null;
                            GameObject.Find("LittleDragon").GetComponent<Rigidbody>().isKinematic = false;
                            GameObject.Find("LittleDragon").GetComponent<BoxCollider>().isTrigger = false;

                            GameObject.Find("LittleDragon/Camera").GetComponent<Camera>().enabled = true;
                            GameObject.Find("LittleDragon/Camera").GetComponent<AudioListener>().enabled = true;
                            GameObject.Find("LittleDragon/Camera").GetComponent<MyTrueRay>().enabled = true;
                            GameObject.Find("LittleDragon").GetComponent<playerTrigger>().enabled = true;
                            GameObject.Find("LittleDragon").GetComponent<LittleDragonController>().enabled = true;
                            GameObject.Find("LittleDragon").GetComponent<PlayerMotor>().enabled = true;

                            GameObject.Find("player/Camera").GetComponent<Camera>().enabled = false;
                            GameObject.Find("player/Camera").GetComponent<AudioListener>().enabled = false;
                            GameObject.Find("player/Camera").GetComponent<MyTrueRay>().enabled = false;
                            GameObject.Find("player").GetComponent<playerTrigger>().enabled = false;
                            GameObject.Find("player").GetComponent<PlayerController>().enabled = false;
                            GameObject.Find("player").GetComponent<PlayerMotor>().enabled = false;

                            GameObject.Find("player").GetComponent<Rigidbody>().isKinematic = true;
                            GameObject.Find("player").GetComponent<BoxCollider>().isTrigger = true;

                            angle1 = (int)transform.rotation.y * 180;
                            angle2 = (int)transform.rotation.y * 180 + 180;

                            isChangeCamera = true;
                        }
                        else if (isOverRotateCamera == false)//转换角度
                        {
                            //ChangeAngle();
                        }
                    }
                }
                else //如果小龙由被未抓状态转换为已被抓，则进行状态转换,让小龙绑在玩家身上
                {
                    isChangeBeCatch = true;
                    GameObject.Find("LittleDragon").GetComponent<Rigidbody>().isKinematic = true;
                    GameObject.Find("LittleDragon").GetComponent<BoxCollider>().isTrigger = true;
                    GameObject player = GameObject.Find("player");
                    transform.position = new Vector3(player.transform.position.x + 1.8f, player.transform.position.y + 0.30f, player.transform.position.z + 2.5f);
                    transform.rotation = Quaternion.Euler(player.transform.rotation.x + 0f, player.transform.rotation.y - 119.79f, player.transform.rotation.z + 0f);
                    transform.parent = GameObject.Find("player").transform;
                }
            }
        }
        else//如果需要换回身体
        {
            if (isOverChangeBack == false)
            {
                //播放切换镜头动画
                isOverChangeBack = true;
                print("换回来了");
                GameObject.Find("LittleDragon").GetComponent<Rigidbody>().isKinematic = true;
                GameObject.Find("LittleDragon").GetComponent<BoxCollider>().isTrigger = true;

                GameObject.Find("LittleDragon/Camera").GetComponent<Camera>().enabled = false;
                GameObject.Find("LittleDragon/Camera").GetComponent<AudioListener>().enabled = false;
                GameObject.Find("LittleDragon/Camera").GetComponent<MyTrueRay>().enabled = false;
                GameObject.Find("LittleDragon").GetComponent<playerTrigger>().enabled = false;
                GameObject.Find("LittleDragon").GetComponent<LittleDragonController>().enabled = false;
                GameObject.Find("LittleDragon").GetComponent<PlayerMotor>().enabled = false;

                GameObject.Find("player/Camera").GetComponent<Camera>().enabled = true;
                GameObject.Find("player/Camera").GetComponent<AudioListener>().enabled = true;
                GameObject.Find("player/Camera").GetComponent<MyTrueRay>().enabled = false;
                //GameObject.Find("player").GetComponent<playerTrigger>().enabled = true;不要逻辑了，随便逛
                GameObject.Find("player").GetComponent<PlayerController>().enabled = true;
                GameObject.Find("player").GetComponent<PlayerMotor>().enabled = true;

                GameObject.Find("player").GetComponent<Rigidbody>().isKinematic = false;
                GameObject.Find("player").GetComponent<BoxCollider>().isTrigger = false;

                GameObject.Find("player").GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
                GameObject.Find("player").transform.position = new Vector3(216.9f, 2.346f, 183.97f);

                GameObject.Find("Canvas/Text").GetComponent<Text>().text = "任务部分已经结束，欢迎你在这里随意参观";
            }
        }
    }
    void ChangeAngle() {
        print(angle1 + "  " + transform.rotation.y);
        if (190 + angle1 > 170 + angle1)
        {
            if (transform.rotation.y*180 < 190 + angle1 && transform.rotation.y*180 < 170 + angle1)
            {
                transform.Rotate(Vector3.up * angleSpeed);
            }
            else
            {
                isOverRotateCamera = true;
            }
        }
        else if (190 + angle1 <= 170 + angle1)
        {
            if (transform.rotation.y * 180 > 190 + angle1 && transform.rotation.y * 180 < 170 + angle1)
            {
                transform.Rotate(Vector3.up * angleSpeed);
            }
            else
            {
                isOverRotateCamera = true;
            }
        }
    }
}
