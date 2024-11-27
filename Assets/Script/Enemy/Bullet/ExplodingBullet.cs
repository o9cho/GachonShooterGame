using UnityEngine;
using System.Collections;

public class ExplodingBullet : EnemyBullet
{
    public float explosionRadius = 3f; // ���� �ݰ�
    public float explosionTime = 0.5f;

    public GameObject explosionEffect; // ���� ȿ�� ������

    protected override void OnEnable()
    {
        base.OnEnable(); // �⺻ Ȱ��ȭ ó��
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        // Ʈ���Ű� �÷��̾�� �浹���� ��
        if (other.CompareTag("Player"))
        {
            Explode(); // ���� ó��
            gameObject.SetActive(false); // �߻�ü ��Ȱ��ȭ
        }
    }

    private void Explode()
    {
        // ���� ȿ�� ����
        if (explosionEffect != null)
        {
            GameObject effect = Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(effect, explosionTime); // 0.5�� �� ���� ȿ�� ����
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
                    playerHealth.TakeDamage(enemyDamage); // �÷��̾� ���� ó��
                }
            }
        }
    }
}
