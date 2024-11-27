using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectManager : MonoBehaviour
{
    public static CharacterSelectManager Instance { get; private set; }

    public GameObject selectedCharacterPrefab; // ������ ĳ���� ������

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // �ߺ� ����
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // �� ���濡�� �ı����� ����
    }

    // ���õ� ĳ���� �������� �����ϴ� �޼���
    public void SetSelectedCharacter(GameObject characterPrefab)
    {
        selectedCharacterPrefab = characterPrefab;
    }

    // ���õ� ĳ���� �������� ��ȯ�ϴ� �޼���
    public GameObject GetSelectedCharacter()
    {
        return selectedCharacterPrefab;
    }
}
