using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> enemyPrefabs; // 몬스터 프리팹 리스트
    public List<Transform> spawnPoints; // 스폰 지점 리스트
    public int maxEnemies = 20; // 최대 몬스터 수
    public float spawnInterval = 2f; // 스폰 간격(초)

    private int currentEnemyCount = 0; // 현재 몬스터 수
    private bool spawning = false; // 스폰 중 여부 체크

    void Start()
    {
        StartCoroutine(SpawnEnemiesRoutine());
    }

    // 몬스터 스폰 루틴
    private IEnumerator SpawnEnemiesRoutine()
    {
        spawning = true;

        while (spawning)
        {
            if (currentEnemyCount < maxEnemies)
            {
                SpawnEnemy();
            }

            yield return new WaitForSeconds(spawnInterval); // 스폰 간격
        }
    }

    // 몬스터 스폰 로직
    private void SpawnEnemy()
    {
        if (enemyPrefabs == null || spawnPoints == null || spawnPoints.Count == 0)
        {
            Debug.LogError("SpawnPoints 또는 EnemyPrefabs가 설정되지 않음");
            return;
        }

        // 랜덤 프리팹 선택
        GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];

        // 랜덤 스폰 지점 선택
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];

        // 몬스터 생성
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        currentEnemyCount++; // 몬스터 수 증가
    }

    // 특정 몬스터 제거 시 호출
    public void OnEnemyDestroyed()
    {
        currentEnemyCount--; // 몬스터 수 감소
    }

    // 스폰 중단
    public void StopSpawning()
    {
        spawning = false;
    }
}
