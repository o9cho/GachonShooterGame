using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 5f; // 최대 체력
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth; // 초기 체력 설정
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log($"플레이어가 {damage}만큼의 피해를 입었습니다. 현재 체력: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("게임 오버");
        // 게임 오버 화면 호출
        gameObject.SetActive(false);
    }
}
