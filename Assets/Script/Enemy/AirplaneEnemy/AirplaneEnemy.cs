using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneEnemy : Enemy
{
    [Header("Speed")]
    public float moveSpeed = 1f; // �̵��ӵ�

    void Update()
    {
        MoveY();
    }

    // Y�����θ� �̵��ϴ� �Լ�
    void MoveY()
    {
        transform.Translate(Vector2.up * -moveSpeed * Time.deltaTime);
    }
}
