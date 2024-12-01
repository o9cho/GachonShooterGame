using UnityEngine;

public class PlayerMovement : Movable
{
    private Vector2 playerSize;
    private Vector2 screenBounds;

    void Start()
    {
        if (GetComponent<SpriteRenderer>() == null)
        {
            Debug.LogError("SpriteRenderer�� �� ������Ʈ�� �����ϴ�!");
        }
        else
        {
            CalculateBounds();
        }
    }

    protected override void CalculateBounds()
    {
        // �÷��̾� ũ�� ���
        playerSize = GetComponent<SpriteRenderer>().bounds.size / 2;

        // ī�޶��� ȭ�� ��� ���
        Camera mainCamera = Camera.main;
        screenBounds = new Vector2
        (
            mainCamera.aspect * mainCamera.orthographicSize,
            mainCamera.orthographicSize
        );
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontal, vertical, 0f);

        Move(moveDirection);

        // ȭ�� ��� üũ
        ClampToScreenBounds();
    }

    private void ClampToScreenBounds()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -screenBounds.x + playerSize.x, screenBounds.x - playerSize.x),
            Mathf.Clamp(transform.position.y, -screenBounds.y + playerSize.y, screenBounds.y - playerSize.y),
            transform.position.z
        );
    }
}
