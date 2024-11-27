using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : EnemyBullet
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        // �÷��̾� �±� Ȯ��
        if (collision.CompareTag("Player"))
        {
            // �÷��̾��� Health ������Ʈ�� ��������
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                // �÷��̾��� ü�� ����
                playerHealth.TakeDamage(enemyDamage);
            }

            // �Ѿ� ����
            DestroyBullet();
        }
    }
}
