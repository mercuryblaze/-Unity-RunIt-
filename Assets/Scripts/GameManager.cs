using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public GameObject DeathScreen;
    public Text DeathScreenCoins;
    public Text DeathScreenDistance;
    public float DeathScreenDelay;
    public string MainMenuName;
    public GameObject NotEnoughCoinsScreen;
    public PlayerController ThePlayer;
    public GameObject PauseScreen;
    public GameObject[] Models;
    public GameObject DefaultChar;
    public AudioManager AM;

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

        // Поиск и загрузка необходимых моделей персонажей
        for (int i = 0; i < Models.Length; i++)
        {
            if (Models[i].name == PlayerPrefs.GetString("SelectedChar"))
            {
                GameObject clone = Instantiate(Models[i], ThePlayer.Skin.position, ThePlayer.Skin.rotation);
                clone.transform.parent = ThePlayer.Skin;
                Destroy(clone.GetComponent<Rigidbody>());
                DefaultChar.SetActive(false);
            }
        }
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

        //DeathScreen.SetActive(true);
        DeathScreenCoins.text = CoinsCollected + " coins!";
        DeathScreenDistance.text = Mathf.Floor(DistanceCovered) + "m!";

        StartCoroutine("ShowDeathScreen");
    }

    public IEnumerator ShowDeathScreen()
    {
        AM.StopMusic();
        yield return new WaitForSeconds(DeathScreenDelay);
        DeathScreen.SetActive(true);
        AM.GameOverMusic.Play();
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

    public void ContinueGame()
    {
        if (CoinsCollected >= 100)
        {
            CoinsCollected -= 100;
            CanMove = true;
            canMove = true;
            DeathScreen.SetActive(false);
            ThePlayer.ResetPlayer();

            AM.StopMusic();
            AM.GameMusic.Play();
        }
        else
        {
            NotEnoughCoinsScreen.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GetCoins()
    {

    }

    public void MainMenu()
    {
        SceneManager.LoadScene(MainMenuName);
        Time.timeScale = 1f;
    }

    public void CloseNotEnoughCoins()
    {
        NotEnoughCoinsScreen.SetActive(false);
    }

    public void ResumeGame()
    {
        PauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        if (Time.timeScale == 1f)
        {
            PauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            PauseScreen.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
