using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreesMovement : MonoBehaviour
{
    public Transform DisappearPoint;
    public Collider Collider;

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

        if (transform.position.z < DisappearPoint.position.z)
        {
            transform.position += new Vector3(0f, 0f, Collider.bounds.size.z * 2f);
        }
    }
}
