using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    //public float MoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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