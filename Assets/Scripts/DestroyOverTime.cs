using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    public float Lifetime;

    void Start()
    {
        
    }

    void Update()
    {
        Destroy(gameObject, Lifetime);
    }
}
