using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadDestructionPoint : MonoBehaviour
{
    public static float PositionOfZ;

    void Start()
    {
        PositionOfZ = transform.position.z;
    }

    void Update()
    {
        PositionOfZ = transform.position.z;
    }
}
