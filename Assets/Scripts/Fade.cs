using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image ScreenColor;
    public float WaitToFade;
    public float FadeSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        if (WaitToFade > 0)
        {
            WaitToFade -= Time.deltaTime;
        }
        else
        {
            ScreenColor.color = new Color(ScreenColor.color.r, ScreenColor.color.g, ScreenColor.color.b, Mathf.MoveTowards(ScreenColor.color.a, 0f, FadeSpeed * Time.deltaTime));

            if (ScreenColor.color.a == 0f)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
