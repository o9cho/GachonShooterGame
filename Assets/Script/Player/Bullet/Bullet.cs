using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 5f; // �Ѿ��� ���� �ð� (��)
    private float lifeTimer; // ���� �ð��� �����ϴ� Ÿ�̸�

    public float speed = 10f; // �Ѿ� �ӵ�
    private Rigidbody2D rb; // �Ѿ��� Rigidbody2D

    protected virtual void OnEnable()
    {
        lifeTimer = 0f;
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D ������Ʈ ��������
    }

    void Update()
    {
        // �Ѿ��� ���� �ð��� �� �Ǹ� ȭ�� ������ �������� ����
        lifeTimer += Time.deltaTime;

        if (lifeTimer >= lifetime)
        {
            BulletPool.Instance.OnBulletExitScreen(gameObject); // ȭ�� ������ ������ Ǯ�� ��ȯ
        }

        // �Ѿ��� ���ư��� �������� �̵�
        if (rb != null)
        {
            rb.velocity = transform.up * speed; // ���� �������� ���� �ӵ��� �̵�
        }
    }

    // �浹 ó��: �Ѿ��� ���� �浹�ϸ� Ǯ�� ��ȯ
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        // �浹�� ������Ʈ�� ��
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // ������ ������ ó��
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(1);
            }

            // �Ѿ��� Ǯ�� ��ȯ
            BulletPool.Instance.ReturnBullet(gameObject);
        }
    }
}
