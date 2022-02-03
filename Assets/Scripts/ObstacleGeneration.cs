using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGeneration : MonoBehaviour
{
    public GameObject[] obstacles;
    public float TimeBetweenObstacles;

    private float ObstaclesGeneratorCounter;

    // Start is called before the first frame update
    void Start()
    {
        ObstaclesGeneratorCounter = TimeBetweenObstacles;
    }

    // Update is called once per frame
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
