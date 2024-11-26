using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // �Ѿ� ������
    public Transform firePoint; // �Ѿ� �߻� ���� (�ͷ��� �ѱ�)
    public float fireRate = 1f; // �Ѿ� �߻� �ֱ� (N�ʿ� 1��)
    private float nextFireTime = 0f; // ���� �߻� �ð� ����

    void Update()
    {
        // ���� �ð� �������� �Ѿ� �߻�
        if (Time.time >= nextFireTime)
        {
            FireBullet(); // �Ѿ� �߻�
            nextFireTime = Time.time + fireRate; // ���� �߻� �ð� ����
        }
    }

    void FireBullet()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            // �Ѿ� ����
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // �Ѿ˿� �ӵ� �ο� (����: �Ѿ��� �ͷ��� �������� �߻�)
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = firePoint.up * 10f; // �Ѿ��� �ͷ��� �������� �߻�ǵ��� �ӵ� ����
            }
        }
    }
}
