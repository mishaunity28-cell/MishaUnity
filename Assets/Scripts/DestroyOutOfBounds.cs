using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float bottomBound = -5;
    public float topBound = 25;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < bottomBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
    }
}
