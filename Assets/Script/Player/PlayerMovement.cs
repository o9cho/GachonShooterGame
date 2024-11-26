using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // �÷��̾� �̵� �ӵ�
    public Vector2 screenBounds; // ȭ�� ��� ��

    private Vector2 playerSize;

    void Start()
    {
        // �÷��̾��� ũ�⸦ ���
        playerSize = GetComponent<SpriteRenderer>().bounds.size / 2;
        // ȭ�� ��� ��� (ī�޶� ũ�� ���)
        Camera mainCamera = Camera.main;
        screenBounds = new Vector2(
            mainCamera.aspect * mainCamera.orthographicSize,
            mainCamera.orthographicSize
        );
    }

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        // Ű �Է�
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // �̵� ���
        Vector3 moveDirection = new Vector3(horizontal, vertical, 0f);
        transform.Translate(moveDirection * speed * Time.deltaTime);

        // ȭ�� ��� üũ
        float clampedX = Mathf.Clamp(transform.position.x, -screenBounds.x + playerSize.x, screenBounds.x - playerSize.x);
        float clampedY = Mathf.Clamp(transform.position.y, -screenBounds.y + playerSize.y, screenBounds.y - playerSize.y);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
