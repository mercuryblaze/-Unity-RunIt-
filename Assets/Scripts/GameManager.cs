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

    private bool CoinHitThisFrame;

    void Start()
    {
        
    }

    void Update()
    {
        canMove = CanMove;
        worldSpeed = WorldSpeed;
        CoinHitThisFrame = false;
    }

    public void HitObstacle()
    {
        CanMove = false;
        canMove = false;
    }

    public void AddCoin()
    {
        if (!CoinHitThisFrame)
        {
            CoinsCollected++;
            CoinHitThisFrame = true;
        }
    }
}
