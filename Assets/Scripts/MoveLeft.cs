
using System;
using UnityEditor;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float moveSpeed;
    public float leftBound = -15;
    
    private PlayerControler player;

    private void Start()
    {
        player = FindObjectOfType<PlayerControler>();
    }


    // Update is called once per frame
   private void Update()
   {
        if (!player.isGameOver)
        {
            transform.Translate(Vector3.left * (moveSpeed * Time.deltaTime));
        }

        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
            
    }
}
