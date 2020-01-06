using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedalLine : MonoBehaviour {
    private int medalNum;
    private GameObject[] lines;
    private int haveLinenNum=0;
    public GameObject medalline;
	// Use this for initialization
	void Start () {
        medalNum = 8;
        lines = new GameObject[medalNum];
	}
	
	// Update is called once per frame
	void Update () {
        if (haveLinenNum < medalNum-1)
        {
            for (int i = 0; i < medalNum - 1; i++)
            {
                haveLinenNum++;
                float Line_Zscale = Disdance(("medal/Sphere_" + i.ToString()), ("medal/Sphere_" + (i + 1).ToString()));
                Vector3 Line_position = MiddlePosition(("medal/Sphere_" + i.ToString()), ("medal/Sphere_" + (i + 1).ToString()));
                Vector3 Line_angle = Angle(("medal/Sphere_" + i.ToString()), ("medal/Sphere_" + (i + 1).ToString()));
                print(Line_angle.x+" "+Line_angle.y+" "+Line_angle.z);
                lines[i] = Instantiate(medalline, Line_position, new Quaternion(Line_angle.x, Line_angle.y , Line_angle.z, 0)) as GameObject;
                lines[i].transform.parent = GameObject.Find("MedalLine").transform;
                lines[i].transform.localScale = new Vector3(1, 1,Line_Zscale);
                //lines[i].transform.rotation = new Quaternion(Line_angle.x, Line_angle.y-90, Line_angle.z, 0);
                lines[i].transform.Rotate(0, -90, 0,Space.World);
            }
        }
	}

    float Disdance(string medal1name, string medal2name)
    {
        GameObject medal1 = GameObject.Find(medal1name);
        GameObject medal2 = GameObject.Find(medal2name);
        float dis = Mathf.Sqrt(
            Mathf.Pow(medal1.transform.position.x - medal2.transform.position.x, 2) +
            Mathf.Pow(medal1.transform.position.y - medal2.transform.position.y, 2) +
            Mathf.Pow(medal1.transform.position.z - medal2.transform.position.z, 2));
        return dis;
    }
    Vector3 MiddlePosition(string medal1name, string medal2name)
    {
        GameObject medal1 = GameObject.Find(medal1name);
        GameObject medal2 = GameObject.Find(medal2name);
        float x = medal1.transform.position.x + (medal2.transform.position.x - medal1.transform.position.x)/2;
        float y = medal1.transform.position.y + (medal2.transform.position.y - medal1.transform.position.y)/2;
        float z = medal1.transform.position.z + (medal2.transform.position.z - medal1.transform.position.z)/2;
        return new Vector3(x, y, z);
    }
    Vector3 Angle(string medal1name, string medal2name)
    {
        GameObject medal1 = GameObject.Find(medal1name);
        GameObject medal2 = GameObject.Find(medal2name);
        float distance = Disdance(medal1name, medal2name);
        float r_x = Mathf.Acos((medal2.transform.position.x - medal1.transform.position.x) / distance);
        float r_y = Mathf.Acos((medal2.transform.position.y - medal1.transform.position.y) / distance);
        float r_z = Mathf.Acos((medal2.transform.position.z - medal1.transform.position.z) / distance);
        return new Vector3(r_x, r_y, r_z);
    }
}
