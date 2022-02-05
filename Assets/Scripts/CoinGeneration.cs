using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGeneration : MonoBehaviour
{
    public GameObject[] CoinGroups;
    public Transform TopPos;

    public float TimeBetweenCoins;

    private float CoinGenCounter;

    void Start()
    {
        CoinGenCounter = TimeBetweenCoins;
    }

    void Update()
    {
        if (GameManager.canMove)
        {
            CoinGenCounter -= Time.deltaTime;

            if (CoinGenCounter <= 0)
            {
                bool goTop = Random.value > .5f;

                int selectCoins = Random.Range(0, CoinGroups.Length);

                if (goTop)
                {
                    Instantiate(CoinGroups[selectCoins], TopPos.position, transform.rotation);
                }
                else
                {
                    Instantiate(CoinGroups[selectCoins], transform.position, transform.rotation);
                }

                CoinGenCounter = Random.Range(TimeBetweenCoins * 0.75f, TimeBetweenCoins * 1.25f);
            }
        }
    }
}
