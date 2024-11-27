using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 5f; // 총알의 생명 시간 (초)
    private float lifeTimer; // 생명 시간을 추적하는 타이머

    public float speed = 10f; // 총알 속도
    private Rigidbody2D rb; // 총알의 Rigidbody2D

    protected virtual void OnEnable()
    {
        lifeTimer = 0f;
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D 컴포넌트 가져오기
    }

    void Update()
    {
        // 총알의 생명 시간이 다 되면 화면 밖으로 나가도록 설정
        lifeTimer += Time.deltaTime;

        if (lifeTimer >= lifetime)
        {
            BulletPool.Instance.OnBulletExitScreen(gameObject); // 화면 밖으로 나가면 풀에 반환
        }

        // 총알이 날아가는 방향으로 이동
        if (rb != null)
        {
            rb.velocity = transform.up * speed; // 현재 방향으로 일정 속도로 이동
        }
    }

    // 충돌 처리: 총알이 적과 충돌하면 풀로 반환
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌한 오브젝트가 적
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // 적에게 데미지 처리
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(1);
            }

            // 총알을 풀로 반환
            BulletPool.Instance.ReturnBullet(gameObject);
        }
    }
}
