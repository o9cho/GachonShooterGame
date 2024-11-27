using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("HP")]
    public int health; // 적의 체력

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"플레이어가 {damage}만큼의 피해를 주었습니다. 현재 체력: {health}");

        if (health <= 0)
        {
            Die(); // 체력이 0 이하가 되면 Die 호출
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }



}
