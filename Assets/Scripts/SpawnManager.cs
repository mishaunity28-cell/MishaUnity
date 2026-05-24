using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private PlayerControler player;
    public Obstacle obstacleTemplate;

    private Vector3 startPosition = new Vector3(25, 0, 0);

    private float startDelay = 2;

    private float repeatRate = 2;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerControler>();
      InvokeRepeating(nameof(SpawnObstacle),startDelay,repeatRate); 
    }

   private void SpawnObstacle()
   {
       if (!player.isGameOver )
       {
           Instantiate(obstacleTemplate, startPosition, obstacleTemplate.transform.rotation);
       } 
       
   } 
 
}
