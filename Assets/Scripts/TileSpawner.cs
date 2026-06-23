using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public GameObject tilePrefab;

    public Transform player;

    private float spawnZ = 0;
    private float tileLength = 20f;

    public int numberOfTiles = 5;
public GameObject[] obstaclePrefabs;
    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            SpawnTile();
        }
    }

    void Update()
    {
        if (player.position.z > spawnZ - (numberOfTiles * tileLength))
        {
            SpawnTile();
        }
    }

    void SpawnTile()
{
    GameObject tile = Instantiate(
        tilePrefab,
        transform.forward * spawnZ,
        Quaternion.identity);

    SpawnObstacle(tile.transform);

    spawnZ += tileLength;
}
void SpawnObstacle(Transform tile)
{
    if (Random.Range(0, 100) < 40)
    return;
    int randomObstacle =
        Random.Range(0, obstaclePrefabs.Length);

    int randomLane = Random.Range(0, 3);

    float xPos = 0;

    if (randomLane == 0)
        xPos = -3;

    else if (randomLane == 2)
        xPos = 3;

    Vector3 obstaclePos =
        new Vector3(xPos, 1, tile.position.z + Random.Range(10, 30));

    Instantiate(
        obstaclePrefabs[randomObstacle],
        obstaclePos,
        Quaternion.identity);
        if (Random.Range(0, 100) > 70)
        {
            int secondLane = Random.Range(0, 3);
            while(secondLane == randomLane)
            {
            secondLane = Random.Range(0, 3);
            }

            float secondX = 0;

            if (secondLane == 0)
            secondX = -3;

            else if (secondLane == 2)
             secondX = 3;

            Vector3 secondPos =
                new Vector3(
             secondX,
            1,
            obstaclePos.z + 8f);

         int secondObstacle =
         Random.Range(0, obstaclePrefabs.Length);

         Instantiate(
        obstaclePrefabs[secondObstacle],
        secondPos,
        Quaternion.identity);
        }
    }
}