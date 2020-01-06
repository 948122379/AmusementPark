using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private Rigidbody rd;
    private Vector3 moveVelocity;
    private float rotateVelocity;
    private float updownrotateVelocity;
    private Transform cameraTransform;
    private float cameraXRotation = 0;
    private float jumpForce = 300;

    public float glideForce;
    public float flyForce;
    public float maxCameraXRotation = 80;
    public float minCameraXRotation = -70;
    [HideInInspector]
    public bool isOnGround = true;
    public Vector3 pos;


    // Use this for initialization
    void Start()
    {
        rd = GetComponent<Rigidbody>();
        cameraTransform = transform.Find("Camera");
    }

    private void FixedUpdate()
    {
        // transform.position = transform.position + moveVelocity * Time.deltaTime;
        rd.MovePosition(transform.position + moveVelocity * Time.deltaTime);
        rd.MoveRotation(transform.rotation * Quaternion.Euler(new Vector3(0, rotateVelocity, 0) * Time.deltaTime));
        pos = rd.position;
        // cameraTransform.Rotate(-Vector3.right*updownrotateVelocity*Time.deltaTime);

    }

    // Update is called once per frame
    void Update()
    {

    }

    //移动函数
    public void Move(Vector3 velocity)
    {
        this.moveVelocity = velocity;
    }

    //视角左右变化
    public void Rotate(float rotateVelocity)
    {
        this.rotateVelocity = rotateVelocity;
    }

    //视角上下变化
    public void UpDownRotate(float rotateVelocity)
    {
        //this.updownrotateVelocity = rotateVelocity;
        cameraXRotation -= rotateVelocity;
        cameraXRotation = Mathf.Clamp(cameraXRotation, minCameraXRotation, maxCameraXRotation);
        cameraTransform.localEulerAngles = new Vector3(cameraXRotation, 0, 0);

    }

    //跳跃函数
    public void Jump()
    {
        rd.AddForce(Vector3.up * jumpForce);
        isOnGround = false;
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name == "Terrain")
        {
            isOnGround = true;
        }
    }

    //滑翔获得浮力
    public void Glide()
    {
        if (rd.velocity.y < 0)
        {
            rd.AddForce(Vector3.up * glideForce);
        }
    }

    //离开地面时获得一个额外的向上的力
    public void Fly()
    {
        rd.AddForce(Vector3.up * flyForce);
    }

}