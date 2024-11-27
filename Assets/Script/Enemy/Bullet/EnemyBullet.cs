using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBullet : MonoBehaviour
{
    public int enemyDamage = 1; // ���� ����
    public float speed = 3f; // �Ѿ� �ӵ�
    public float lifetime = 5f; // �Ѿ� ���� �ð�

    private float BulletTimer; // Ÿ�̸�

    protected virtual void OnEnable()
    {
        BulletTimer = 0f; // Ÿ�̸� �ʱ�ȭ
    }

    void Update()
    {
        Move();

        // �ð��� �� �Ǹ� ����
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

    // ������Ʈ ���� ó��
    protected void DestroyBullet()
    {
        Destroy(gameObject); // ������Ʈ ����
    }

    // ȭ�� ������ ������ �� �ڵ� ����
    private void OnBecameInvisible()
    {
        DestroyBullet();
    }

    // �浹 ó��
    public abstract void OnTriggerEnter2D(Collider2D collision);
}
