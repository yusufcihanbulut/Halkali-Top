using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float jumpForce = 5f; // Zýplama kuvveti
    private Rigidbody rb;       // Rigidbody bileþeni

    void Start()
    {
        // Rigidbody bileþenini al
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Ekrana dokunulduðunda zýpla
        if (Input.GetMouseButtonDown(0)) // 0: Sol fare butonu ya da mobil ekrana dokunma
        {
            Jump();
        }
    }

    void Jump()
    {
        // Yukarý doðru hýz uygula
        rb.velocity = Vector3.up * jumpForce;
    }
}