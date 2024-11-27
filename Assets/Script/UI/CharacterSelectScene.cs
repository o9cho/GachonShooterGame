using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectScene : MonoBehaviour
{
    public GameObject[] characterPrefabs;

    public void OnCharacterSelected(int characterIndex)
    {
        if (characterIndex >= 0 && characterIndex < characterPrefabs.Length)
        {
            // 선택된 캐릭터 프리팹 저장
            CharacterSelectManager.Instance.SetSelectedCharacter(characterPrefabs[characterIndex]);

            // 메인 게임 씬으로 전환
            SceneManager.LoadScene("MainGameScene");
        }
        else
        {
            Debug.LogError("Invalid character index selected.");
        }
    }
}
