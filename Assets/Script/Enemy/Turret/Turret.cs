using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public string playerTag = "Player";
    private Transform player; // 플레이어의 Transform
    public float rotationSpeed = 5f; // 회전 속도
    public float searchInterval = 10f; // 플레이어를 찾는 간격 (초)

    void Start()
    {
        // 10초마다 한 번씩 플레이어를 찾도록 설정
        InvokeRepeating("FindPlayer", 0f, searchInterval);
    }

    // 일정 간격마다 플레이어를 찾는 함수
    void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag(playerTag)?.transform;

        if (player == null)
        {
            Debug.LogWarning("플레이어 트랜스폼이 할당되지 않았습니다.");
        }
    }

    void Update()
    {
        if (player != null)
        {
            RotateTurret();
        }
    }

    void RotateTurret()
    {
        if (player == null)
        {
            return;
        }

        // 플레이어 위치를 향하는 벡터 계산
        Vector2 direction = (player.position - transform.position).normalized;

        // 벡터로 각도를 계산
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 회전 속도를 적용하여 부드럽게 회전하도록 설정
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // 지정된 회전 속도로 터렛 회전
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
