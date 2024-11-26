using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 3; // 적의 체력

    // 적이 데미지를 받을 때 호출되는 메서드
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die(); // 체력이 0 이하가 되면 죽음 처리
        }
    }

    // 적이 죽을 때 호출되는 메서드
    void Die()
    {
        // 적의 죽음 처리 (예: 애니메이션, 점수 추가 등)
        Destroy(gameObject); // 예시
    }
}
