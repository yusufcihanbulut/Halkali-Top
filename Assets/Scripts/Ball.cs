using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;


public class Ball : MonoBehaviour
{
    public float jumpForce = 5f;   
    public float horizontalForce = 3f;
    private Rigidbody rb;
    public int score = 0;
    public TMP_Text scoreText;

    private bool isDead = false;
    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0)) 
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


    // Trigger'dan geçildiðinde çalýþýr
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hoop")) 
        {
            score += 1; 
            UpdateScoreUI(); 

            Debug.Log("Skor: " + score);
        }
    }

    // Skoru ekrana yazdýran fonksiyon
    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = " " + score;
        }
    }
}
