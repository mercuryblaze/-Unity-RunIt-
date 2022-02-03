using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager GM;
    public Rigidbody RB;
    public float JumpForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.CanMove)
        {
            if (Input.GetMouseButton(0))
            {
                // Заставляем игрока прыгать
                RB.velocity = new Vector3(0f, JumpForce, 0f);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
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
}
