using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectManager : MonoBehaviour
{
    public static CharacterSelectManager Instance { get; private set; }

    public GameObject selectedCharacterPrefab; // 선택한 캐릭터 프리팹

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // 중복 방지
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // 씬 변경에도 파괴되지 않음
    }

    // 선택된 캐릭터 프리팹을 저장하는 메서드
    public void SetSelectedCharacter(GameObject characterPrefab)
    {
        selectedCharacterPrefab = characterPrefab;
    }

    // 선택된 캐릭터 프리팹을 반환하는 메서드
    public GameObject GetSelectedCharacter()
    {
        return selectedCharacterPrefab;
    }
}
