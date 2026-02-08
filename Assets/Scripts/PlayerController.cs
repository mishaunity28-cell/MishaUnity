using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
 public int moveSpeed = 5;

 public GameObject food;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     float horizontalInput = Input.GetAxis("Horizontal");
     transform.Translate(Vector3.right * moveSpeed * horizontalInput * Time.deltaTime);

     if (transform.position.x > 15)
     {
         transform.position = new Vector3(15, 0, 0);
     }

     if (transform.position.x < -15)
     {
         transform.position = new Vector3(-15, 0, 0);
     }

     if (Input.GetKeyDown(KeyCode.Space))
     {
         Instantiate(food, transform.position, food.transform.rotation);
     }
    }
}
