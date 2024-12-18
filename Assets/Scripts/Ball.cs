using System.Collections;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    public float jumpForce = 5f;
    public float horizontalForce = 3f;
    private Rigidbody rb;
    public int score = 0;
    public TMP_Text scoreText;

    private bool isDead = false;
    private float timeSinceLastJump = 0f;
    public float timeLimit = 3f; // Topun Circle'a çarpmadan durmasý için geçen süre

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
      
        if (!isDead)
        {
            timeSinceLastJump += Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0))
        {
            JumpBasedOnTouch();
            timeSinceLastJump = 0f;
        }

       
        if (timeSinceLastJump >= timeLimit && !isDead)
        {
            GameOver();
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

  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hoop"))
        {
            score += 1;
            UpdateScoreUI();
            Debug.Log("Skor: " + score);

            timeSinceLastJump = 0f;
        }
    }

   
    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = " " + score;
        }
    }

   
    void GameOver()
    {
        isDead = true;
        Time.timeScale = 0f; // Oyun durur
        Debug.Log("Game Over");
       
    }
}
