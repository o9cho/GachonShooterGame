using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneEnemy : Enemy
{
    [Header("Speed")]
    public float moveSpeed = 1f; // 이동속도

    void Update()
    {
        MoveY();
    }

    // Y축으로만 이동하는 함수
    void MoveY()
    {
        transform.Translate(Vector2.up * -moveSpeed * Time.deltaTime);
    }
}
