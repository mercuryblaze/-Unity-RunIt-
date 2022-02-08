using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public GameManager GM;
    public Rigidbody RB;
    public float JumpForce;
    public Transform Skin;
    public LayerMask WhatIsGround;
    public bool OnGround;
    public Animator Anim;
    public float InvincibleTime;
    public AudioManager AM;
    public GameObject CoinEffect;

    private Vector3 StartPosition;
    private Quaternion StartRotation;
    private float InvincibleTimer;

    void Start()
    {
        StartPosition = transform.position;
        StartRotation = transform.rotation;
    }

    void Update()
    {
        if (GM.CanMove)
        {
            OnGround = Physics.OverlapSphere(Skin.position, 0.2f, WhatIsGround).Length > 0;

            if (OnGround && !IsPointerOverUIObject())
            {
                if (Input.GetMouseButton(0))
                {
                    // Заставляем игрока прыгать
                    RB.velocity = new Vector3(0f, JumpForce, 0f);

                    AM.SFXJump.Play();
                }
            }
        }

        // Управление анимациями
        Anim.SetBool("walking", GM.CanMove);
        Anim.SetBool("OnGround", OnGround);

        // Управление неуязвимостью
        if (InvincibleTimer > 0)
        {
            InvincibleTimer -= Time.deltaTime;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (InvincibleTimer <= 0)
        {
            if (other.tag == "Obstacles")
            {
                Debug.Log("Hit Obstacle");
                GM.HitObstacle();

                //RB.isKinematic = false;

                RB.constraints = RigidbodyConstraints.None;

                RB.velocity = new Vector3(Random.Range(GameManager.worldSpeed / 2f, -GameManager.worldSpeed / 2f), 2.5f, -GameManager.worldSpeed / 2f);

                AM.SFXHit.Play();
            }
        }

        if (other.tag == "Coin")
        {
            GM.AddCoin();
            Instantiate(CoinEffect, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);

            AM.SFXCoin.Stop();
            AM.SFXCoin.Play();
        }
    }

    public void ResetPlayer()
    {
        RB.constraints = RigidbodyConstraints.FreezeRotation;
        transform.rotation = StartRotation;
        transform.position = StartPosition;

        InvincibleTimer = InvincibleTime;

    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        return results.Count > 0;
    }
}
