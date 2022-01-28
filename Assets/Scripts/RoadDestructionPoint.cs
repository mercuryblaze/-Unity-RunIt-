using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadDestructionPoint : MonoBehaviour
{
    public static float PositionOfZ;

    // Start is called before the first frame update
    void Start()
    {
        PositionOfZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        PositionOfZ = transform.position.z;
    }
}
