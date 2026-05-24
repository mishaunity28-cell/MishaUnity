using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float jumpForce;
    public float gravityModifier;
    private Rigidbody rigidbody;
    private bool isOnGround = true;
    public bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
      Physics.gravity *= gravityModifier;  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true &&  isGameOver == false)
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
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
        }  
            
    }
}
    
