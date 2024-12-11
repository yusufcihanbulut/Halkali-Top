using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        // Rigidbody bile�enini al�yoruz
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Top hareket ettirilebilir, �rnek olarak klavye giri�leriyle
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * 10f); // H�z katsay�s�n� de�i�tirebilirsiniz
    }

    void OnCollisionEnter(Collision collision)
    {
        // �arp��may� alg�lad���m�z yer
        if (collision.gameObject.CompareTag("Ground")) // "Ground" zeminin etiketi
        {
            // H�z� s�f�rl�yoruz
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            // Topun hareketini tamamen durdurmak i�in Rigidbody'yi kinematik yap�yoruz
            rb.isKinematic = true;
        }
    }
}