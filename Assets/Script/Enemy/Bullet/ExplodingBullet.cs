using UnityEngine;

public class ExplodingBullet : EnemyBullet
{
    public int explosionDamage = 1; // 폭발 피해
    public float explosionRadius = 3f; // 폭발 반경
    
    public GameObject explosionEffect; // 폭발 효과 프리팹

    protected override void OnEnable()
    {
        base.OnEnable(); // 기본 활성화 처리
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        Explode(); // 폭발 처리
    }

    private void Explode()
    {
        // 폭발 효과 생성
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
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
                    playerHealth.TakeDamage(explosionDamage); // 플레이어 피해 처리
                }
            }
        }
    }
}
