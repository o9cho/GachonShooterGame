using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameManager : MonoBehaviour
{
    public Transform spawnPoint; // 캐릭터가 생성될 위치

    void Start()
    {
        GameObject selectedCharacter = CharacterSelectManager.Instance.GetSelectedCharacter();
        if (selectedCharacter != null)
        {
            // 선택된 캐릭터 프리팹을 생성
            Instantiate(selectedCharacter, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Debug.LogError("캐릭터 프리팹이 없습니다.");
        }
    }
}
