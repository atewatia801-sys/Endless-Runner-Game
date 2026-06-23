using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;

    public Transform player;

    private float spawnZ = 30f;

    public float distanceBetweenCoins = 15f;

    void Update()
    {
        if (player.position.z + 50 > spawnZ)
        {
            SpawnCoin();
        }
    }

    void SpawnCoin()
    {
        int lane = Random.Range(0, 3);

        float xPosition = 0;

        if (lane == 0)
            xPosition = -3;

        else if (lane == 1)
            xPosition = 0;

        else
            xPosition = 3;

        Vector3 spawnPosition =
            new Vector3(xPosition, 1, spawnZ);

        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);

        spawnZ += distanceBetweenCoins;
    }
}