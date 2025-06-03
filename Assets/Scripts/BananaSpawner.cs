using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaSpawner : MonoBehaviour
{
    public Transform bananaSpawnPoint;
    public GameObject bananaPrefab;
    public int forceStrength = 5;


    public void StartSpawningBananas(int num)
    {
        StartCoroutine(SpawnBananas(num));
    }

    IEnumerator SpawnBananas(int num)
    {
        while (num > 0)
        {
            Vector3 spawnPosition = bananaSpawnPoint ? bananaSpawnPoint.position : transform.position;
            GameObject newBanana = Instantiate(bananaPrefab, spawnPosition, Quaternion.identity);
            num--;
            Rigidbody2D rb = newBanana.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 randForce = Random.insideUnitCircle.normalized;
                rb.AddForce(randForce * forceStrength, ForceMode2D.Impulse);
            }
            yield return new WaitForSeconds(.1f);
        }
    }
}
