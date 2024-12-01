using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class StageManager : MonoBehaviour
{
    public StageData[] stages; // ��� �������� ������ �迭
    public EnemyManager enemyManager; // EnemyManager ����
    public TMP_Text stageText; // TextMeshPro

    private int currentStageIndex = 0; // ���� �������� �ε���

    private void Start()
    {
        LoadStage(currentStageIndex); // ���� �� ù �������� �ε�
    }

    private void Update()
    {
        if (enemyManager.AreAllEnemiesDefeated())
        {
            NextStage();
        }
    }

    private void NextStage()
    {
        currentStageIndex++;
        if (currentStageIndex < stages.Length)
        {
            LoadStage(currentStageIndex); // ���� �������� �ε�
        }
        else
        {
            // ��� �������� Ŭ���� �� ó�� ����
            Debug.Log("��� ���������� Ŭ�����߽��ϴ�!");
            stageText.text = "��� �������� Ŭ����!";
        }
    }

    private void LoadStage(int stageIndex)
    {
        StageData stageData = stages[stageIndex];
        enemyManager.SpawnEnemies(stageData.Enemys);
        stageText.text = "Stage: " + stageData.stageNumber; // �������� ��ȣ �ؽ�Ʈ ������Ʈ
    }
}
