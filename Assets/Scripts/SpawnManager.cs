using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animals;
    public float spawnPositionZ=20;

    public float spawnRangeX = 14;

    public float delayTime = 2;

    public float repeatRate = 2;
    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating(nameof(SpawnRandomAnimals),delayTime,repeatRate);
}

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnRandomAnimals()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnRangeX,spawnRangeX),0,spawnPositionZ);
        int randomAnimal = Random.Range(0, animals.Length);
        Instantiate(animals[randomAnimal], spawnPosition, animals[randomAnimal].transform.rotation);
    }
}
