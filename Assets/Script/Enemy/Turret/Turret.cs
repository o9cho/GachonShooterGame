using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public string playerTag = "Player";
    private Transform player; // 플레이어의 Transform
    public float rotationSpeed = 5f; // 회전 속도

    void Start()
    {
        // 태그로 플레이어를 찾아 Transform 할당
        player = GameObject.FindGameObjectWithTag(playerTag).transform;
    }

    void Update()
    {
        RotateTurret();
    }

    void RotateTurret()
    {
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
