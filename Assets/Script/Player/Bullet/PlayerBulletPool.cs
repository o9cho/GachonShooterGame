using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance { get; private set; } // �̱��� �ν��Ͻ�
    public GameObject bulletPrefab; // �Ѿ� ������
    public int poolSize = 10; // Ǯ�� ũ��
    private ObjectPool<GameObject> bulletPool; // �Ѿ� ������Ʈ Ǯ

    private void Awake()
    {
        // �̱��� ����
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // �Ѿ� ������Ʈ Ǯ �ʱ�ȭ
        bulletPool = new ObjectPool<GameObject>(
            createFunc: () => Instantiate(bulletPrefab), // ���ο� �Ѿ� ����
            actionOnGet: bullet => bullet.SetActive(true), // Ǯ���� ���� �� Ȱ��ȭ
            actionOnRelease: bullet => bullet.SetActive(false), // Ǯ�� ��ȯ�� �� ��Ȱ��ȭ
            actionOnDestroy: bullet => Destroy(bullet), // Ǯ���� ������ �� �Ѿ� ����
            maxSize: poolSize // �ִ� ũ�� ����
        );
    }

    // �Ѿ��� Ǯ���� ������ �޼���
    public GameObject GetBullet()
    {
        return bulletPool.Get();
    }

    // �Ѿ��� Ǯ�� ��ȯ�ϴ� �޼���
    public void ReturnBullet(GameObject bullet)
    {
        bulletPool.Release(bullet);
    }

    // �Ѿ��� ȭ�� ������ ������ �� ȣ��Ǵ� �޼���
    public void OnBulletExitScreen(GameObject bullet)
    {
        ReturnBullet(bullet); // ȭ�� ������ ������ Ǯ�� ��ȯ
    }
}
