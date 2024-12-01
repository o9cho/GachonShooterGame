using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class StageManager : MonoBehaviour
{
    public StageData[] stages; // 모든 스테이지 데이터 배열
    public EnemyManager enemyManager; // EnemyManager 참조
    public TMP_Text stageText; // TextMeshPro

    private int currentStageIndex = 0; // 현재 스테이지 인덱스

    private void Start()
    {
        LoadStage(currentStageIndex); // 시작 시 첫 스테이지 로드
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
            LoadStage(currentStageIndex); // 다음 스테이지 로드
        }
        else
        {
            // 모든 스테이지 클리어 시 처리 로직
            Debug.Log("모든 스테이지를 클리어했습니다!");
            stageText.text = "모든 스테이지 클리어!";
        }
    }

    private void LoadStage(int stageIndex)
    {
        StageData stageData = stages[stageIndex];
        enemyManager.SpawnEnemies(stageData.Enemys);
        stageText.text = "Stage: " + stageData.stageNumber; // 스테이지 번호 텍스트 업데이트
    }
}
