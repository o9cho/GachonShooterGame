using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameManager : MonoBehaviour
{
    public Transform spawnPoint; // ĳ���Ͱ� ������ ��ġ

    void Start()
    {
        GameObject selectedCharacter = CharacterSelectManager.Instance.GetSelectedCharacter();
        if (selectedCharacter != null)
        {
            // ���õ� ĳ���� �������� ����
            Instantiate(selectedCharacter, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Debug.LogError("ĳ���� �������� �����ϴ�.");
        }
    }
}
