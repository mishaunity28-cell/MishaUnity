using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float bottomBound;

    private Rigidbody rigidbody;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerController = FindObjectOfType<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (playerController.transform.position - transform.position).normalized;
        rigidbody.AddForce(lookDirection * speed);
        if (transform.position.y < bottomBound)
        {
            Destroy(gameObject);
        }
    }
}
