using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animals;
    public float spawnPositionZ=20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Vector3 spawnPosition = new Vector3(0,0,spawnPositionZ);
            int randomAnimal = Random.Range(0, animals.Length);
            Instantiate(animals[randomAnimal], spawnPosition, animals[randomAnimal].transform.rotation);
        }

    }
}
