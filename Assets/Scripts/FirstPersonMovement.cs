using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonMovement : MonoBehaviour {

    public float speed = 5;
    public float lookSensitivityX = 5;
    public float lookSensitivityY = 5;
    public bool invertLookY = true;
    public bool invertLookX = false;

    CharacterController pawn;
    Camera cam;

	void Start () {
        
        pawn = GetComponent<CharacterController>();
        cam = GetComponentInChildren<Camera>();
	}
	
	
	void Update ()
    {

        LookAround();
        MoveAround();
    }

    private void MoveAround()
    {

        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        Vector3 velocity = Vector3.zero;
        velocity += transform.forward * v * speed;
        velocity += transform.right * h * speed;

        pawn.SimpleMove(velocity);
    }

    private void LookAround()
    {
        float lookX = Input.GetAxis("Mouse X") * (invertLookX ? -1 : 1) * lookSensitivityX;
        float lookY = Input.GetAxis("Mouse Y") * (invertLookY ? -1 : 1) * lookSensitivityY;

        transform.Rotate(0, lookX, 0);

        float newAngle = cam.transform.localEulerAngles.x + lookY;
        if (newAngle > 80 && newAngle < 280) return;

        cam.transform.Rotate(lookY, 0, 0);
    }
}
