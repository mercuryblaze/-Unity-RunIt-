using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool CanMove;
    public float WorldSpeed;
    public static bool canMove;
    public static float worldSpeed;
    public int CoinsCollected;

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

    public void AddCoin()
    {
        CoinsCollected++;
    }
}
