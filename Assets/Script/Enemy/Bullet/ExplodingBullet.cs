using UnityEngine;
using System.Collections;

public class ExplodingBullet : EnemyBullet
{
    public float explosionRadius = 3f; // 폭발 반경
    public float explosionTime = 0.5f;

    public GameObject explosionEffect; // 폭발 효과 프리팹

    protected override void OnEnable()
    {
        base.OnEnable(); // 기본 활성화 처리
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        // 트리거가 플레이어와 충돌했을 때
        if (other.CompareTag("Player"))
        {
            Explode(); // 폭발 처리
            gameObject.SetActive(false); // 발사체 비활성화
        }
    }

    private void Explode()
    {
        // 폭발 효과 생성
        if (explosionEffect != null)
        {
            GameObject effect = Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(effect, explosionTime); // 0.5초 뒤 폭발 효과 제거
        }

        // 폭발 범위 내 대상 검색
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D obj in hitObjects)
        {
            // 플레이어가 폭발 범위에 있으면 피해 처리
            if (obj.CompareTag("Player"))
            {
                PlayerHealth playerHealth = obj.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(enemyDamage); // 플레이어 피해 처리
                }
            }
        }
    }
}
