using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public string playerTag = "Player";
    private Transform player; // �÷��̾��� Transform
    public float rotationSpeed = 5f; // ȸ�� �ӵ�

    void Start()
    {
        // �±׷� �÷��̾ ã�� Transform �Ҵ�
        player = GameObject.FindGameObjectWithTag(playerTag).transform;
    }

    void Update()
    {
        RotateTurret();
    }

    void RotateTurret()
    {
        // �÷��̾� ��ġ�� ���ϴ� ���� ���
        Vector2 direction = (player.position - transform.position).normalized;

        // ���ͷ� ������ ���
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // ȸ�� �ӵ��� �����Ͽ� �ε巴�� ȸ���ϵ��� ����
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // ������ ȸ�� �ӵ��� �ͷ� ȸ��
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
