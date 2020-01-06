using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyRay : MonoBehaviour
{
    public Shader shader1_1;
    public Shader shader1_2;
    public Renderer myrenderer1;
    public int heighLightDisdance;//产生可交互高光的距离

    // Use this for initialization
    void Start()
    {
        //myrenderer1 = GameObject.Find("hydra").GetComponent<Renderer>();
        if (myrenderer1 == null)
        {
            print("0");
        }
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;//返回碰撞信息
        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject gameobj = hitInfo.collider.gameObject;//获得碰撞到的物体
            if (gameobj.name == "dragon_skin")
            {
                float d = Disdance(gameobj.name);//d为摄像机与碰撞到的物体之间的距离
                if (d < heighLightDisdance)
                {                  
                    myrenderer1.material.shader = shader1_1;
                }
                else
                {
                    myrenderer1.material.shader = shader1_2;
                }
            }

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

}

