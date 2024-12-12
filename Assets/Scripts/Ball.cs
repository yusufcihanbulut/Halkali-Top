using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float jumpForce = 5f; // Z�plama kuvveti
    private Rigidbody rb;       // Rigidbody bile�eni

    void Start()
    {
        // Rigidbody bile�enini al
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Ekrana dokunuldu�unda z�pla
        if (Input.GetMouseButtonDown(0)) // 0: Sol fare butonu ya da mobil ekrana dokunma
        {
            Jump();
        }
    }

    void Jump()
    {
        // Yukar� do�ru h�z uygula
        rb.velocity = Vector3.up * jumpForce;
    }
}