using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] spawnPoints; // 스폰 위치 배열
    private List<GameObject> activeEnemies = new List<GameObject>();

    public void SpawnEnemies(GameObject[] enemies)
    {
        ClearEnemies();

        foreach (GameObject enemyPrefab in enemies)
        {
            GameObject enemy = Instantiate(enemyPrefab,
                                           GetRandomSpawnPoint().position,
                                           Quaternion.identity);
            activeEnemies.Add(enemy);
        }
    }

    public bool AreAllEnemiesDefeated()
    {
        activeEnemies.RemoveAll(enemy => enemy == null);
        return activeEnemies.Count == 0;
    }

    private Transform GetRandomSpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length)];
    }

    private void ClearEnemies()
    {
        foreach (GameObject enemy in activeEnemies)
        {
            if (enemy != null)
            {
                Destroy(enemy);
            }
        }
        activeEnemies.Clear();
    }
}
