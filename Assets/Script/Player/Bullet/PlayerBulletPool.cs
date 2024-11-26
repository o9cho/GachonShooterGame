using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance { get; private set; } // 싱글턴 인스턴스
    public GameObject bulletPrefab; // 총알 프리팹
    public int poolSize = 10; // 풀의 크기
    private ObjectPool<GameObject> bulletPool; // 총알 오브젝트 풀

    private void Awake()
    {
        // 싱글턴 설정
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // 총알 오브젝트 풀 초기화
        bulletPool = new ObjectPool<GameObject>(
            createFunc: () => Instantiate(bulletPrefab), // 새로운 총알 생성
            actionOnGet: bullet => bullet.SetActive(true), // 풀에서 꺼낼 때 활성화
            actionOnRelease: bullet => bullet.SetActive(false), // 풀에 반환할 때 비활성화
            actionOnDestroy: bullet => Destroy(bullet), // 풀에서 삭제할 때 총알 삭제
            maxSize: poolSize // 최대 크기 설정
        );
    }

    // 총알을 풀에서 꺼내는 메서드
    public GameObject GetBullet()
    {
        return bulletPool.Get();
    }

    // 총알을 풀에 반환하는 메서드
    public void ReturnBullet(GameObject bullet)
    {
        bulletPool.Release(bullet);
    }

    // 총알이 화면 밖으로 나갔을 때 호출되는 메서드
    public void OnBulletExitScreen(GameObject bullet)
    {
        ReturnBullet(bullet); // 화면 밖으로 나가면 풀로 반환
    }
}
