using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        // Rigidbody bileþenini alýyoruz
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Top hareket ettirilebilir, örnek olarak klavye giriþleriyle
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * 10f); // Hýz katsayýsýný deðiþtirebilirsiniz
    }

    void OnCollisionEnter(Collision collision)
    {
        // Çarpýþmayý algýladýðýmýz yer
        if (collision.gameObject.CompareTag("Ground")) // "Ground" zeminin etiketi
        {
            // Hýzý sýfýrlýyoruz
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            // Topun hareketini tamamen durdurmak için Rigidbody'yi kinematik yapýyoruz
            rb.isKinematic = true;
        }
    }
}