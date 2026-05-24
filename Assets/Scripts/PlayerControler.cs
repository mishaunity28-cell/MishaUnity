using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float jumpForce;
    public float gravityModifier;
    private Rigidbody rigidbody;
    private Animator animator;
    private bool isOnGround = true;
    public bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
      Physics.gravity *= gravityModifier;  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true &&  isGameOver == false)
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            animator.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Ground ground))
        {
            isOnGround = true;
        }
        if(other.gameObject.TryGetComponent(out Obstacle obstacle))
        {
            isGameOver = true;
            animator.SetBool("Death_b", true);
            animator.SetInteger("DeathType_int",1);
        }  
            
    }
}
    
