using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float fireRate = 0.5f; // �Ѿ� �߻� �ֱ�
    private float nextFireTime = 0f; // ���� �߻� �ð�

    void Update()
    {
        // �����̽��ٰ� ������ �߻� �ð��� �Ǹ� �Ѿ��� �߻�
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFireTime)
        {
            FireBullet();
            nextFireTime = Time.time + fireRate; // �߻� �ֱ� ����
        }
    }

    void FireBullet()
    {
        // BulletPool���� �Ѿ��� ������
        GameObject bullet = BulletPool.Instance.GetBullet();

        if (bullet != null)
        {
            // �Ѿ��� �÷��̾� ��ġ�� ��ġ
            bullet.transform.position = transform.position;
            bullet.transform.rotation = Quaternion.identity; // ȸ�� �ʱ�ȭ (�ʿ��)

            // �Ѿ� Ȱ��ȭ ���·� ����
            bullet.SetActive(true);

            // �Ѿ��� �߻�Ǵ� �������� �̵���Ű�� ���� �߰� (����: �������� �߻�)
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.up * 10f; // ���÷� �������� �߻�, �ʿ�� �ӵ��� ������ ����
            }
        }
    }

    // �Ѿ��� ȭ�� ������ ������ �� ȣ��Ǵ� �޼��� (BulletPool���� ȣ��)
    public void ReturnBulletToPool(GameObject bullet)
    {
        BulletPool.Instance.ReturnBullet(bullet); // �Ѿ��� Ǯ�� ��ȯ
    }
}
