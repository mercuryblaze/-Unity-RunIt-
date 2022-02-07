using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string LevelToLoad;

    public GameObject MainScreen;
    public GameObject SwitchingScreen;
    public Transform Camera;
    public Transform CharSwitchHolder;
    public float CameraSpeed;
    public GameObject[] Chars;
    public int CurrentCharacter;
    public GameObject SwitchPlayButton;
    public GameObject SwitchUnlockButton;
    public GameObject SwitchGetCoinsButton;
    public int CurrentCoins;
    public GameObject CharLockedImage;
    public Text CoinsText;

    private Vector3 CamTargetPos;

    void Start()
    {
        CamTargetPos = Camera.position;

        if (!PlayerPrefs.HasKey(Chars[0].name))
        {
            PlayerPrefs.SetInt(Chars[0].name, 1);
        }

        if (PlayerPrefs.HasKey("CoinsCollected"))
        {
            CurrentCoins = PlayerPrefs.GetInt("CoinsCollected");
        }
        else
        {
            PlayerPrefs.SetInt("CoinsCollected", 0);
        }
    }


    void Update()
    {
        Camera.position = Vector3.Lerp(Camera.position, CamTargetPos, CameraSpeed * Time.deltaTime);

        CoinsText.text = "Coins: " + CurrentCoins;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(LevelToLoad);
    }

    public void ChooseChar()
    {
        MainScreen.SetActive(false);
        SwitchingScreen.SetActive(true);

       CamTargetPos = Camera.position + new Vector3(0f, CharSwitchHolder.position.y, 0f);

        UnlockedCheck();
    }

    public void MoveLeft()
    {
        if (CurrentCharacter > 0)
        {
            CamTargetPos += new Vector3(2f, 0f, 0f);
            CurrentCharacter--;

            UnlockedCheck();
        }
    }

    public void MoveRight()
    {
        if (CurrentCharacter < Chars.Length - 1)
        {
            CamTargetPos -= new Vector3(2f, 0f, 0f);
            CurrentCharacter++;

            UnlockedCheck();
        }
    }

    public void UnlockedCheck()
    {
        if (PlayerPrefs.HasKey(Chars[CurrentCharacter].name))
        {
            if (PlayerPrefs.GetInt(Chars[CurrentCharacter].name) == 0)
            {
                SwitchPlayButton.SetActive(false);

                CharLockedImage.SetActive(true);

                if (CurrentCoins < 500)
                {
                    SwitchGetCoinsButton.SetActive(true);
                    SwitchUnlockButton.SetActive(false);
                }
                else
                {
                    SwitchUnlockButton.SetActive(true);
                    SwitchGetCoinsButton.SetActive(false);
                }
            }
            else
            {
                SwitchPlayButton.SetActive(true);
                SwitchGetCoinsButton.SetActive(false);
                SwitchUnlockButton.SetActive(false);

                CharLockedImage.SetActive(false);
            }
        }
        else
        {
            PlayerPrefs.SetInt(Chars[CurrentCharacter].name, 0);
            UnlockedCheck();
        }
    }

    public void UnlockChar()
    {
        CurrentCoins -= 500;
        PlayerPrefs.SetInt(Chars[CurrentCharacter].name, 1);
        PlayerPrefs.SetInt("CoinsCollected", CurrentCoins);
        UnlockedCheck();
    }
}
