using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 5f; // �ִ� ü��
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth; // �ʱ� ü�� ����
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log($"�÷��̾ {damage}��ŭ�� ���ظ� �Ծ����ϴ�. ���� ü��: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("���� ����");
        // ���� ���� ȭ�� ȣ��
        gameObject.SetActive(false);
    }
}
