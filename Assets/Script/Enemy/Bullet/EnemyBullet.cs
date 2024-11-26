using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBullet : MonoBehaviour
{
    public float speed = 3f; // �Ѿ� �ӵ�
    public float lifetime = 5f; // �Ѿ� ���� �ð�

    private float BulletTimer; // Ÿ�̸�

    protected virtual void OnEnable()
    {
        BulletTimer = 0f; // Ÿ�̸� �ʱ�ȭ
    }

    void Update()
    {
        // �̵� ó��
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

    // �浹 ó�� (������ �Ļ� Ŭ�������� ���� �ʿ�)
    public abstract void OnCollisionEnter2D(Collision2D collision);
}
