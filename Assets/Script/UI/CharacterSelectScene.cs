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
            // ���õ� ĳ���� ������ ����
            CharacterSelectManager.Instance.SetSelectedCharacter(characterPrefabs[characterIndex]);

            // ���� ���� ������ ��ȯ
            SceneManager.LoadScene("MainGameScene");
        }
        else
        {
            Debug.LogError("Invalid character index selected.");
        }
    }
}
