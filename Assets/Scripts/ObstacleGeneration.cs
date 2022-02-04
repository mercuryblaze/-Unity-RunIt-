using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGeneration : MonoBehaviour
{
    public GameObject[] obstacles;
    public float TimeBetweenObstacles;

    private float ObstaclesGeneratorCounter;

    void Start()
    {
        ObstaclesGeneratorCounter = TimeBetweenObstacles;
    }

    void Update()
    {
        if (GameManager.canMove)
        {
            ObstaclesGeneratorCounter -= Time.deltaTime;

            if (ObstaclesGeneratorCounter <= 0)
            {
                int selectObstacle = Random.Range(0, obstacles.Length);
                Instantiate(obstacles[selectObstacle], transform.position, Quaternion.Euler(0f, Random.Range(-45f, 45f), 0f));

                ObstaclesGeneratorCounter = Random.Range(TimeBetweenObstacles * 0.75f, TimeBetweenObstacles * 1.25f);
            }
        }
    }
}
