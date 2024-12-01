using UnityEngine;

public class PlayerMovement : Movable
{
    private Vector2 playerSize;
    private Vector2 screenBounds;

    void Start()
    {
        if (GetComponent<SpriteRenderer>() == null)
        {
            Debug.LogError("SpriteRenderer가 이 오브젝트에 없습니다!");
        }
        else
        {
            CalculateBounds();
        }
    }

    protected override void CalculateBounds()
    {
        // 플레이어 크기 계산
        playerSize = GetComponent<SpriteRenderer>().bounds.size / 2;

        // 카메라의 화면 경계 계산
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

        // 화면 경계 체크
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
