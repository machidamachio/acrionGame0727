using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody rb;

    [SerializeField]
    private float jumpPower = 800;
    [SerializeField]
    private float moveSpeed = 10;

    private Animator anim;

    private bool grounded;

    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.TransformDirection(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.TransformDirection(Vector3.back * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -5, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 5, 0));
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) ||Input.GetKey (KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("Running", true);
        }

        else
        {
            anim.SetBool("Running", false);
        }

        if (Input.GetKey(KeyCode.K))
        {
            anim.SetBool("Kicking", true);
        }
        else
        {
            anim.SetBool("Kicking", false);
        }
        if (Input.GetKey(KeyCode.P))
        {
            anim.SetBool("Punching", true);
        }
        else
        {
            anim.SetBool("Punching", false);
        }
        if (Input.GetKey(KeyCode.H))
        {
            anim.SetBool("Head Spining", true);
        }
        else
        {
            anim.SetBool("Head Spining", false);
        }




        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded == true)
            {
                rb.AddForce(Vector3.up * jumpPower);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
        
    }
}