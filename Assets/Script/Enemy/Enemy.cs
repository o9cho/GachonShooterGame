using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("HP")]
    public int health; // ���� ü��

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"�÷��̾ {damage}��ŭ�� ���ظ� �־����ϴ�. ���� ü��: {health}");

        if (health <= 0)
        {
            Die(); // ü���� 0 ���ϰ� �Ǹ� Die ȣ��
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }



}
