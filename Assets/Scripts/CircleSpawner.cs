using System.Collections;
using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    public GameObject circlePrefab; // Daire prefab'ý
    public float spawnInterval = 2f;  // Dairelerin spawn aralýðý
    public float minY = -2f;          // Dairenin min Y pozisyonu
    public float maxY = 2f;           // Dairenin max Y pozisyonu
    public float minX = 5f;           // Dairenin min X pozisyonu
    public float maxX = 10f;          // Dairenin max X pozisyonu
    public int maxCircles = 5;        // Maksimum daire sayýsý

    private void Start()
    {
        // Daireleri sürekli spawn etmek için baþlat
        StartCoroutine(SpawnCircles());
    }

    private IEnumerator SpawnCircles()
    {
        while (true)
        {
            if (transform.childCount < maxCircles) // Eðer ekran üzerinde yeterince daire yoksa
            {
                // Daireyi oluþtur
                SpawnCircle();
            }

            // Daireleri belirli aralýklarla oluþtur
            yield return new WaitForSeconds(Random.Range(1f, spawnInterval)); // Random zaman aralýðý ile spawn et
        }
    }

    void SpawnCircle()
    {
        // Dairenin random X ve Y pozisyonlarýný seç
        float randomX = Random.Range(minX, maxX); // X ekseninde random deðer
        float randomY = Random.Range(minY, maxY); // Y ekseninde random deðer

        Vector3 spawnPosition = new Vector3(randomX, randomY, 0); // X ve Y pozisyonlarýyla oluþtur

        // Daireyi instantiate et
        Instantiate(circlePrefab, spawnPosition, Quaternion.identity);
    }
}
