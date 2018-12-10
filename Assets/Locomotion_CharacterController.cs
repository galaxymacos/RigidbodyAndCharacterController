using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotion_CharacterController : MonoBehaviour {
    [SerializeField] private float speed = 6.0f;
    [SerializeField] private float jumpSpeed = 8.0f;
    [SerializeField] private float gravity = 20.0f;
    [SerializeField] private float rotateSpeed = 3f;

    private Animator anim;
    
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    void Start() {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        // let the gameObject fall down
        // gameObject.transform.position = new Vector3(0, 5, 0);
    }

    void Update() {
        if (controller.isGrounded) {
            // We are grounded, so recalculate
            // move direction directly from axes
            anim.SetBool("grounded",true);
            anim.SetFloat("v",Input.GetAxis("Vertical"));
            anim.SetFloat("h",Input.GetAxis("Horizontal"));
            moveDirection = Vector3.zero;
            moveDirection.z = Input.GetAxis("Vertical");
            transform.Rotate(0,Input.GetAxis("Horizontal")*rotateSpeed,0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection * speed;

            if (Input.GetButton("Jump")) {
                moveDirection.y = jumpSpeed;
                anim.SetTrigger("jump");
            }
        }
        else {
            anim.SetBool("grounded", false);
        }

        // Apply gravity
        anim.SetFloat("y",moveDirection.y);
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);
    }
}