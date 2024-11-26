using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // 플레이어 이동 속도
    public Vector2 screenBounds; // 화면 경계 값

    private Vector2 playerSize;

    void Start()
    {
        // 플레이어의 크기를 계산
        playerSize = GetComponent<SpriteRenderer>().bounds.size / 2;
        // 화면 경계 계산 (카메라 크기 기반)
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
        // 키 입력
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // 이동 계산
        Vector3 moveDirection = new Vector3(horizontal, vertical, 0f);
        transform.Translate(moveDirection * speed * Time.deltaTime);

        // 화면 경계 체크
        float clampedX = Mathf.Clamp(transform.position.x, -screenBounds.x + playerSize.x, screenBounds.x - playerSize.x);
        float clampedY = Mathf.Clamp(transform.position.y, -screenBounds.y + playerSize.y, screenBounds.y - playerSize.y);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
