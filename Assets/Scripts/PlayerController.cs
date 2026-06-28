using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;

    private PlayerInputAction playerInputAction;

    private Rigidbody rigidbody;
    public GameObject focalPoint;
    // Start is called before the first frame update
    void Start()
    { 
        rigidbody =  GetComponent<Rigidbody>();
     playerInputAction = new PlayerInputAction();  
     playerInputAction.Player.Enable();
    }

    // Update is called once per frame
    void Update()
    {
       Vector2 moveInput = playerInputAction.Player.Move.ReadValue<Vector2>();
       float verticalInput = moveInput.y;

       rigidbody.AddForce(focalPoint.transform.forward * verticalInput * playerSpeed * Time.deltaTime);
    }
}
