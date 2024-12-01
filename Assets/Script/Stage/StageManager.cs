using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StageManager : MonoBehaviour
{
    public StageData[] stages; // 여러 스테이지 데이터 배열
    public TextMeshProUGUI stageUIText; // 스테이지 번호를 표시할 텍스트 UI

    private int currentStageIndex = 0; // 현재 진행 중인 스테이지 인덱스
    private StageData currentStage;

    void Start()
    {
        // 첫 번째 스테이지 로드
        LoadStage(currentStageIndex);
    }

    void LoadStage(int stageIndex)
    {
        currentStage = stages[stageIndex]; // 스테이지 정보 가져오기
        Debug.Log($"Stage {currentStage.stageNumber} 시작!");

        // TMP 텍스트 UI에 스테이지 번호 표시
        if (stageUIText != null)
        {
            stageUIText.text = $"Stage {currentStage.stageNumber}";
        }

        // 몬스터 스폰
        foreach (GameObject monsterPrefab in currentStage.Enemys)
        {
            Instantiate(monsterPrefab, Vector3.zero, Quaternion.identity); // 몬스터 프리팹을 (0,0,0) 위치에 스폰
        }
    }

    // 스테이지 진행 후 다음 스테이지
    public void NextStage()
    {
        if (currentStageIndex < stages.Length - 1)
        {
            currentStageIndex++;
            LoadStage(currentStageIndex);
        }
        else
        {
            Debug.Log("게임 클리어");
        }
    }
}
