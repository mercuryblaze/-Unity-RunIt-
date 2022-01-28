using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    public GameObject RoadSection;

    public Transform EndPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < EndPoint.position.z)
        {
            Instantiate(RoadSection, transform.position, transform.rotation);
            transform.position += new Vector3(0f, 0f, 2f);
        }
        
    }
}
