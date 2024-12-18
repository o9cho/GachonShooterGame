using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBullet : MonoBehaviour
{
    public int enemyDamage = 1; // 폭발 피해
    public float speed = 3f; // 총알 속도
    public float lifetime = 5f; // 총알 생명 시간

    private float BulletTimer; // 타이머

    protected virtual void OnEnable()
    {
        BulletTimer = 0f; // 타이머 초기화
    }

    void Update()
    {
        Move();

        // 시간이 다 되면 제거
        BulletTimer += Time.deltaTime;
        if (BulletTimer >= lifetime)
        {
            DestroyBullet();
        }
    }

    protected virtual void Move()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    // 오브젝트 제거 처리
    protected void DestroyBullet()
    {
        Destroy(gameObject); // 오브젝트 삭제
    }

    // 화면 밖으로 나갔을 때 자동 제거
    private void OnBecameInvisible()
    {
        DestroyBullet();
    }

    // 충돌 처리
    public abstract void OnTriggerEnter2D(Collider2D collision);
}
