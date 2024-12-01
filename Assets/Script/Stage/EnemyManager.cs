using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> enemyPrefabs; // ���� ������ ����Ʈ
    public List<Transform> spawnPoints; // ���� ���� ����Ʈ
    public int maxEnemies = 20; // �ִ� ���� ��
    public float spawnInterval = 2f; // ���� ����(��)

    private int currentEnemyCount = 0; // ���� ���� ��
    private bool spawning = false; // ���� �� ���� üũ

    void Start()
    {
        StartCoroutine(SpawnEnemiesRoutine());
    }

    // ���� ���� ��ƾ
    private IEnumerator SpawnEnemiesRoutine()
    {
        spawning = true;

        while (spawning)
        {
            if (currentEnemyCount < maxEnemies)
            {
                SpawnEnemy();
            }

            yield return new WaitForSeconds(spawnInterval); // ���� ����
        }
    }

    // ���� ���� ����
    private void SpawnEnemy()
    {
        if (enemyPrefabs == null || spawnPoints == null || spawnPoints.Count == 0)
        {
            Debug.LogError("SpawnPoints �Ǵ� EnemyPrefabs�� �������� ����");
            return;
        }

        // ���� ������ ����
        GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];

        // ���� ���� ���� ����
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];

        // ���� ����
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        currentEnemyCount++; // ���� �� ����
    }

    // Ư�� ���� ���� �� ȣ��
    public void OnEnemyDestroyed()
    {
        currentEnemyCount--; // ���� �� ����
    }

    // ���� �ߴ�
    public void StopSpawning()
    {
        spawning = false;
    }
}
