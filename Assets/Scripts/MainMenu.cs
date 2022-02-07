using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string LevelToLoad;

    public GameObject MainScreen;
    public GameObject SwitchingScreen;
    public Transform Camera;
    public Transform CharSwitchHolder;
    public float CameraSpeed;

    private Vector3 CamTargetPos;

    void Start()
    {
        CamTargetPos = Camera.position;
    }


    void Update()
    {
        Camera.position = Vector3.Lerp(Camera.position, CamTargetPos, CameraSpeed * Time.deltaTime);
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
    }
}
