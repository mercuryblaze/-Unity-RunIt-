using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool CanMove;
    public float WorldSpeed;
    public static bool canMove;
    public static float worldSpeed;
    public int CoinsCollected;
    public GameObject TapMessage;
    public Text CoinsText;
    public Text DistanceText;

    private bool CoinHitThisFrame;
    private bool GameStarted;

    // Увеличение скорости
    public float TimeToIncreaseSpeed;
    public float SpeedMultiplier;
    public float Acceleration;
    public float SpeedIncreaseAmount;
    private float IncreaseSpeedCounter;
    private float TargetSpeedMultiplier;
    private float WorldSpeedStore;
    private float AccelerationStore;
    private float DistanceCovered;

    void Start()
    {
        if (PlayerPrefs.HasKey("CoinsCollected"))
        {
            CoinsCollected = PlayerPrefs.GetInt("CoinsCollected");
        }

        IncreaseSpeedCounter = TimeToIncreaseSpeed;

        TargetSpeedMultiplier = SpeedMultiplier;
        WorldSpeedStore = WorldSpeed;
        AccelerationStore = Acceleration;

        CoinsText.text = "Coins: " + CoinsCollected;
        DistanceText.text = DistanceCovered + "m";
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

            TapMessage.SetActive(false);
        }

        // Увеличение скорости со временем
        if (CanMove)
        {
            IncreaseSpeedCounter -= Time.deltaTime;
            if (IncreaseSpeedCounter <= 0)
            {
                IncreaseSpeedCounter = TimeToIncreaseSpeed;
                //WorldSpeed = WorldSpeed * SpeedMultiplier;
                TargetSpeedMultiplier = TargetSpeedMultiplier * SpeedIncreaseAmount;
                TimeToIncreaseSpeed = TimeToIncreaseSpeed * 0.95f;
            }

            Acceleration = AccelerationStore * SpeedMultiplier;

            SpeedMultiplier = Mathf.MoveTowards(SpeedMultiplier, TargetSpeedMultiplier, Acceleration * Time.deltaTime);
            WorldSpeed = WorldSpeedStore * SpeedMultiplier;

            // Пройденное расстояние
            DistanceCovered += Time.deltaTime * worldSpeed;
            DistanceText.text = Mathf.Floor(DistanceCovered) + "m";
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

            CoinsText.text = "Coins: " + CoinsCollected;
        }
    }
}
