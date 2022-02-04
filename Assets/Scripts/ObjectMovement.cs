using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    //public float MoveSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        if (GameManager.canMove)
        {
            transform.position -= new Vector3(0f, 0f, GameManager.worldSpeed * Time.deltaTime);
        }
        
        if (transform.position.z < RoadDestructionPoint.PositionOfZ)
        {
            Destroy(gameObject);
        }
    }
}
