using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool CanMove;
    public float WorldSpeed;

    public static bool canMove;
    public static float worldSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        canMove = CanMove;
        worldSpeed = WorldSpeed;
    }

    public void HitObstacle()
    {
        CanMove = false;
        canMove = false;
    }
}
