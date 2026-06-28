using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed = 150;
    private PlayerInputAction playerInputAction;
    void Start()
    {
        playerInputAction = new PlayerInputAction();
        playerInputAction.Player.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = playerInputAction.Player.Move.ReadValue<Vector2>();
        float horizontalInput = moveInput.x;
        
        transform.Rotate(Vector3.up,horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
