using UnityEngine;
using System.Collections;

//Author:ken@iamcoding.com  
public class gg: MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        //获取组件  
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }


    void Update()
    {
        //鼠标左键点击  
        if (Input.GetMouseButtonDown(0))
        {
            //摄像机到点击位置的的射线  
            Ray ray = GameObject.Find("Cube/Camera (1)").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //判断点击的是否地形  
                if (!hit.collider.name.Equals("Terrain"))
                {
                    return;
                }
                //点击位置坐标  
                Vector3 point = hit.point;
                //转向  
                transform.LookAt(new Vector3(point.x, transform.position.y, point.z));
                //设置寻路的目标点  
                agent.SetDestination(new Vector3(216.89f, 0.75f, 184f));
            }
        }

        if (Mathf.Abs(Mathf.Abs(transform.position.x) - 216.89f) < 50
            && Mathf.Abs(Mathf.Abs(transform.position.y) - 0.75f) < 50)
        {
            transform.LookAt(new Vector3(251.5f, 0.5f, 166.3f));
        }

        //播放动画，判断是否到达了目的地，播放空闲或者跑步动画  
       /* if (agent.remainingDistance == 0)
        {
            GetComponent<Animation>().Play("idle");
        }
        else
        {
            GetComponent<Animation>().Play("run");
        }*/

    }
}  
