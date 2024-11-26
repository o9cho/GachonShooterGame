using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 3; // ���� ü��

    // ���� �������� ���� �� ȣ��Ǵ� �޼���
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die(); // ü���� 0 ���ϰ� �Ǹ� ���� ó��
        }
    }

    // ���� ���� �� ȣ��Ǵ� �޼���
    void Die()
    {
        // ���� ���� ó�� (��: �ִϸ��̼�, ���� �߰� ��)
        Destroy(gameObject); // ����
    }
}
