using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class FirstPersonMovement : MonoBehaviour
{

    CharacterController pawn;
    Camera cam;
    public float speed = 5;
    public float lookSensitivityX = 5;
    public float lookSensitivityY = 3;
    public bool invertLookX = false;
    public bool invertLookY = true;

    void Start()
    {
        pawn = GetComponent<CharacterController>();
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        LookAround();
        MoveAround();
    }

    private void MoveAround()
    {
        

        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        Vector3 velecity = Vector3.zero;
        velecity += transform.forward * v * speed;
        velecity += transform.right * h * speed;
        pawn.SimpleMove(velecity);
    }

    private void LookAround()
    {
        float lookx = Input.GetAxis("Mouse X") * (invertLookX ? -1 : 1) * lookSensitivityX;
        float looky = Input.GetAxis("Mouse Y") * (invertLookY ? -1 : 1) * lookSensitivityY;
        transform.Rotate(0, lookx, 0);
        cam.transform.Rotate(looky, 0, 0);
    }
}
