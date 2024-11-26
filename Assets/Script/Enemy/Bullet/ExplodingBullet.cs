using UnityEngine;

public class ExplodingBullet : EnemyBullet
{
    public int explosionDamage = 1; // ���� ����
    public float explosionRadius = 3f; // ���� �ݰ�
    
    public GameObject explosionEffect; // ���� ȿ�� ������

    protected override void OnEnable()
    {
        base.OnEnable(); // �⺻ Ȱ��ȭ ó��
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        Explode(); // ���� ó��
    }

    private void Explode()
    {
        // ���� ȿ�� ����
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
        }

        // ���� ���� �� ��� �˻�
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D obj in hitObjects)
        {
            // �÷��̾ ���� ������ ������ ���� ó��
            if (obj.CompareTag("Player"))
            {
                PlayerHealth playerHealth = obj.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(explosionDamage); // �÷��̾� ���� ó��
                }
            }
        }
    }
}
