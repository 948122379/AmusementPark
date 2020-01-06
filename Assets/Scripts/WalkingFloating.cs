using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingFloating : MonoBehaviour {
    private float radian = 0;//度数
    private float perRadian = 0.15f;//每次变化的度数
    public float radius = 0.04f;//半径
    private PlayerMotor motor;
    public Rigidbody rd;

    // Use this for initialization
    void Start () {
        //motor = gameObject.GetComponent<PlayerMotor>();
       // rd = GameObject.Find("player").GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    private void FixedUpdate()
    {
       if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 && rd.velocity.y==0)
        {
           
            float y = Floating();
            transform.localPosition = new Vector3(0, 0.4f + y, 0);
        }
    }


    //行走时的浮动函数
    public float Floating()
    {
        radian += perRadian;
        float dy = Mathf.Cos(radian) * radius;
        return dy;
    }
}
