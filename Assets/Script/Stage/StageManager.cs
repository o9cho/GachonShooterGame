using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StageManager : MonoBehaviour
{
    public StageData[] stages; // ���� �������� ������ �迭
    public TextMeshProUGUI stageUIText; // �������� ��ȣ�� ǥ���� �ؽ�Ʈ UI

    private int currentStageIndex = 0; // ���� ���� ���� �������� �ε���
    private StageData currentStage;

    void Start()
    {
        // ù ��° �������� �ε�
        LoadStage(currentStageIndex);
    }

    void LoadStage(int stageIndex)
    {
        currentStage = stages[stageIndex]; // �������� ���� ��������
        Debug.Log($"Stage {currentStage.stageNumber} ����!");

        // TMP �ؽ�Ʈ UI�� �������� ��ȣ ǥ��
        if (stageUIText != null)
        {
            stageUIText.text = $"Stage {currentStage.stageNumber}";
        }

        // ���� ����
        foreach (GameObject monsterPrefab in currentStage.Enemys)
        {
            Instantiate(monsterPrefab, Vector3.zero, Quaternion.identity); // ���� �������� (0,0,0) ��ġ�� ����
        }
    }

    // �������� ���� �� ���� ��������
    public void NextStage()
    {
        if (currentStageIndex < stages.Length - 1)
        {
            currentStageIndex++;
            LoadStage(currentStageIndex);
        }
        else
        {
            Debug.Log("���� Ŭ����");
        }
    }
}
