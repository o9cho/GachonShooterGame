using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // 총알 프리팹
    public Transform firePoint; // 총알 발사 지점 (터렛의 총구)
    public float fireRate = 1f; // 총알 발사 주기 (N초에 1번)
    private float nextFireTime = 0f; // 다음 발사 시간 추적

    void Update()
    {
        // 일정 시간 간격으로 총알 발사
        if (Time.time >= nextFireTime)
        {
            FireBullet(); // 총알 발사
            nextFireTime = Time.time + fireRate; // 다음 발사 시간 설정
        }
    }

    void FireBullet()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            // 총알 생성
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // 총알에 속도 부여 (예시: 총알이 터렛의 방향으로 발사)
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = firePoint.up * 10f; // 총알이 터렛의 방향으로 발사되도록 속도 설정
            }
        }
    }
}
