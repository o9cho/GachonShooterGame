using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float fireRate = 0.5f; // 총알 발사 주기
    private float nextFireTime = 0f; // 다음 발사 시간

    void Update()
    {
        // 스페이스바가 눌리고 발사 시간이 되면 총알을 발사
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFireTime)
        {
            FireBullet();
            nextFireTime = Time.time + fireRate; // 발사 주기 설정
        }
    }

    void FireBullet()
    {
        // BulletPool에서 총알을 가져옴
        GameObject bullet = BulletPool.Instance.GetBullet();

        if (bullet != null)
        {
            // 총알을 플레이어 위치에 배치
            bullet.transform.position = transform.position;
            bullet.transform.rotation = Quaternion.identity; // 회전 초기화 (필요시)

            // 총알 활성화 상태로 변경
            bullet.SetActive(true);

            // 총알이 발사되는 방향으로 이동시키는 로직 추가 (예시: 위쪽으로 발사)
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.up * 10f; // 예시로 위쪽으로 발사, 필요시 속도나 방향을 조정
            }
        }
    }

    // 총알이 화면 밖으로 나갔을 때 호출되는 메서드 (BulletPool에서 호출)
    public void ReturnBulletToPool(GameObject bullet)
    {
        BulletPool.Instance.ReturnBullet(bullet); // 총알을 풀에 반환
    }
}
