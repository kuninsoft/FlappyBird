using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField, Min(0)] private float minSpawnTimeoutInSeconds = 1f;
    [SerializeField, Min(0)] private float maxSpawnTimeoutInSeconds = 2f;
    [SerializeField, Min(0)] private float obstacleVerticalOffsetRange = 5f;

    private void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    private IEnumerator SpawnObstacle()
    {
        while (GameManager.IsGameRunning)
        {
            float actualTimeout = Random.Range(minSpawnTimeoutInSeconds, maxSpawnTimeoutInSeconds);

            yield return new WaitForSeconds(actualTimeout);
            
            Instantiate(original: obstacle, 
                position: CalculateObstacleSpawnPosition(inRegardTo: spawnPoint.transform.position),
                rotation: Quaternion.identity, parent: this.transform);
        }
    }

    private Vector3 CalculateObstacleSpawnPosition(Vector3 inRegardTo)
    {
        float obstacleVerticalOffset = Random.Range(-obstacleVerticalOffsetRange, obstacleVerticalOffsetRange);

        return new Vector3(inRegardTo.x, inRegardTo.y + obstacleVerticalOffset);
    }
}
