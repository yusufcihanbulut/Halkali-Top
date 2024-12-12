using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public float speed = 5f; // Dairenin hareket hýzý


    void Update()
    {
        // Daireyi sola hareket ettir
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        // Ekranýn dýþýna çýkarsa yok et
        if (transform.position.x < -10f) 
        {
            Destroy(gameObject);
        }
    }
  
}
