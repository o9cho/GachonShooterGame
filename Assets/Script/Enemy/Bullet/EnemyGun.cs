using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : EnemyBullet
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        // 플레이어 태그 확인
        if (collision.CompareTag("Player"))
        {
            // 플레이어의 Health 컴포넌트를 가져오기
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                // 플레이어의 체력 감소
                playerHealth.TakeDamage(enemyDamage);
            }

            // 총알 제거
            DestroyBullet();
        }
    }
}
