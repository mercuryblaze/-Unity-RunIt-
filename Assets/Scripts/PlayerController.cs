using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

            if (OnGround)
            {
                if (Input.GetMouseButton(0))
                {
                    // Заставляем игрока прыгать
                    RB.velocity = new Vector3(0f, JumpForce, 0f);
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
            }
        }

        if (other.tag == "Coin")
        {
            GM.AddCoin();
            Destroy(other.gameObject);
        }
    }

    public void ResetPlayer()
    {
        RB.constraints = RigidbodyConstraints.FreezeRotation;
        transform.rotation = StartRotation;
        transform.position = StartPosition;

        InvincibleTimer = InvincibleTime;

    }
}
