using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private float spawnPosX = 20;
    private float startDelay = 1.5f;
    private float spawnInterval = 1.5f;
    private PlayerController playerControllerScript;

    void Start()
    {
        InvokeRepeating(nameof(SpawnRandomObstacle), startDelay, spawnInterval);
        playerControllerScript = GameObject.Find("SimplePeople_Woman_Doctor_Black").GetComponent<PlayerController>();
    }

    void SpawnRandomObstacle()
    {
        if (playerControllerScript.gameOver == false) {
            Vector3 spawnPos = new Vector3(spawnPosX, 0.66f, 0.42f);
            int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[obstacleIndex], spawnPos, obstaclePrefabs[obstacleIndex].transform.rotation);
        }
    }
}
