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
    private bool GameStarted;

    // Увеличение скорости
    public float TimeToIncreaseSpeed;
    public float SpeedMultiplier;
    private float IncreaseSpeedCounter;

    void Start()
    {
        if (PlayerPrefs.HasKey("CoinsCollected"))
        {
            CoinsCollected = PlayerPrefs.GetInt("CoinsCollected");
        }

        IncreaseSpeedCounter = TimeToIncreaseSpeed;
    }

    void Update()
    {
        canMove = CanMove;
        worldSpeed = WorldSpeed;

        if (!GameStarted && Input.GetMouseButtonDown(0))
        {
            CanMove = true;
            canMove = true;
            GameStarted = true;
        }

        // Увеличение скорости со временем
        if (CanMove)
        {
            IncreaseSpeedCounter -= Time.deltaTime;
            if (IncreaseSpeedCounter <= 0)
            {
                IncreaseSpeedCounter = TimeToIncreaseSpeed;
                WorldSpeed = WorldSpeed * SpeedMultiplier;
            }
        }

        CoinHitThisFrame = false;
    }

    public void HitObstacle()
    {
        CanMove = false;
        canMove = false;

        PlayerPrefs.SetInt("CoinsCollected", CoinsCollected);
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
