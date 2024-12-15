using System.Collections;
using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    public GameObject circlePrefab; // Daire prefab'�
    public float spawnInterval = 2f;  // Dairelerin spawn aral���
    public float minY = -2f;          // Dairenin min Y pozisyonu
    public float maxY = 2f;           // Dairenin max Y pozisyonu
    public float minX = 5f;           // Dairenin min X pozisyonu
    public float maxX = 10f;          // Dairenin max X pozisyonu
    public int maxCircles = 5;        // Maksimum daire say�s�

    private void Start()
    {
        // Daireleri s�rekli spawn etmek i�in ba�lat
        StartCoroutine(SpawnCircles());
    }

    private IEnumerator SpawnCircles()
    {
        while (true)
        {
            if (transform.childCount < maxCircles) // E�er ekran �zerinde yeterince daire yoksa
            {
                // Daireyi olu�tur
                SpawnCircle();
            }

            // Daireleri belirli aral�klarla olu�tur
            yield return new WaitForSeconds(Random.Range(1f, spawnInterval)); // Random zaman aral��� ile spawn et
        }
    }

    void SpawnCircle()
    {
        // Dairenin random X ve Y pozisyonlar�n� se�
        float randomX = Random.Range(minX, maxX); // X ekseninde random de�er
        float randomY = Random.Range(minY, maxY); // Y ekseninde random de�er

        Vector3 spawnPosition = new Vector3(randomX, randomY, 0); // X ve Y pozisyonlar�yla olu�tur

        // Daireyi instantiate et
        Instantiate(circlePrefab, spawnPosition, Quaternion.identity);
    }
}
