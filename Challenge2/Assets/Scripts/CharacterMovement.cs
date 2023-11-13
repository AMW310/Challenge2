using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 5f;
    public Light flash;
    private bool light;

    void Start()
    {
        flash.intensity = 0f;
    }
    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Flash();
        }
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        float horizontalRot = Input.GetAxis("RotationHorizontal");
        float verticalRot = Input.GetAxis("RotationVertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        Vector3 rotation = new Vector3(horizontalRot, 0f, verticalRot).normalized;


        // Rotate the character smoothly towards the direction of movement
        if (rotation != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(rotation, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // Move the character
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    void Flash()
    {

        if (!light)
        {
            flash.intensity = 0f;
            light = false;
        }

        if (!light)
        {
            flash.intensity = 10f;
            light = true;
        }
    }
}
