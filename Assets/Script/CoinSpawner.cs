using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;

    public int coinAmount = 3;
    public float spacing = 2f;

    void Start()
    {
        SpawnCoins();
    }

    void SpawnCoins()
    {
        for (int i = 0; i < coinAmount; i++)
        {
            Vector3 spawnPosition = transform.position;

            spawnPosition.y += i * spacing;

            Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        }
    }
}