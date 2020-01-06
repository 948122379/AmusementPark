using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleDragonController : MonoBehaviour {
    [SerializeField]
    private float speed = 2;

    private PlayerMotor motor;
    [SerializeField]
    private float rotateSpeed = 60;


    // Use this for initialization
    void Start () {
        motor = GetComponent<PlayerMotor>();
    }
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = h * transform.right + v * transform.forward;
        motor.Move(dir.normalized * speed);

        float mouseX = Input.GetAxisRaw("Mouse X");
        motor.Rotate(mouseX * rotateSpeed);

        float mouseY = Input.GetAxisRaw("Mouse Y");
        motor.UpDownRotate(mouseY);

        if (Input.GetKeyDown(KeyCode.Joystick1Button7) || Input.GetKeyDown(KeyCode.Space))
        {
            motor.Jump();
        }
        if (motor.isOnGround == false) {
            motor.Glide();
            motor.Fly();
        }
    }
}
