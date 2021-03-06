using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomOutsideGenerator : MonoBehaviour
{
    public GameManager GM;
    public float TimeBetweenObjects;
    public GameObject[] objects;
    public Transform MinPoint;
    public Transform MaxPoint;

    private float ObjectGenCounter;

    void Start()
    {
        
    }

    void Update()
    {
        if (GM.CanMove)
        {
            ObjectGenCounter -= Time.deltaTime;

            if (ObjectGenCounter <= 0)
            {
                int selectObject = Random.Range(0, objects.Length);

                // Выбор рандомной точки для генерации объекта
                Vector3 genPoint = new Vector3(Random.Range(MinPoint.position.x, MaxPoint.position.x), transform.position.y, transform.position.z);

                Instantiate(objects[selectObject], genPoint, Quaternion.Euler(0f, Random.Range(-180f, 180f), 0f));

                ObjectGenCounter = Random.Range(TimeBetweenObjects * 1f, TimeBetweenObjects * 1.5f);

                ObjectGenCounter = ObjectGenCounter / GM.SpeedMultiplier;
            }
        }
    }
}
