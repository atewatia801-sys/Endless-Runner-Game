using UnityEngine;

public class EnvironmentSpawner : MonoBehaviour
{
    public GameObject treePrefab;

public GameObject[] buildingPrefabs;

    public Transform player;

    private float spawnZ = 20f;

    void Update()
    {
        if (player.position.z + 50 > spawnZ)
        {
            SpawnTrees();
            SpawnBuildings();

            spawnZ += 20f;
        }
    }

    void SpawnTrees()
{
    float leftX =
        Random.Range(-14f, -11f);

    float rightX =
        Random.Range(11f, 14f);

    float randomZ =
        spawnZ + Random.Range(-5f, 5f);

    Instantiate(
        treePrefab,
        new Vector3(leftX, -0.05f, randomZ),
        Quaternion.identity);

    Instantiate(
        treePrefab,
        new Vector3(rightX, 0.05f, randomZ),
        Quaternion.identity);
}
void SpawnBuildings()
{
    int leftBuilding =
        Random.Range(0, buildingPrefabs.Length);

    int rightBuilding =
        Random.Range(0, buildingPrefabs.Length);

    float leftZ =
        spawnZ + Random.Range(-5f, 5f);

    float rightZ =
        spawnZ + Random.Range(-5f, 5f);

    Instantiate(
        buildingPrefabs[leftBuilding],
        new Vector3(-18f, 0, leftZ),
        Quaternion.identity);

    Instantiate(
        buildingPrefabs[rightBuilding],
        new Vector3(18f, 0, rightZ),
        Quaternion.identity);
}
}