using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float jumpForce = 5f;   // Yukar� do�ru z�plama kuvveti
    public float horizontalForce = 3f; // Sa�a veya sola uygulanan kuvvet
    private Rigidbody rb; 

    void Start()
    {
       
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Ekrana dokunuldu�unda z�pla ve y�n belirle
        if (Input.GetMouseButtonDown(0)) // 0: Sol fare butonu veya mobil ekran dokunmas�
        {
            JumpBasedOnTouch();
        }
    }

    void JumpBasedOnTouch()
    {
        Vector3 touchPosition = Input.mousePosition;

        float screenMiddle = Screen.width / 2;

        rb.velocity = new Vector3(0, jumpForce, 0);

     
        if (touchPosition.x < screenMiddle)
        {
            rb.velocity += Vector3.left * horizontalForce;
        }
      
        else if (touchPosition.x > screenMiddle)
        {
            rb.velocity += Vector3.right * horizontalForce;
        }
    }
}
