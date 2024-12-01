using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageData", menuName = "ScriptableObject/StageData")]
public class StageData : ScriptableObject
{
    public int stageNumber; // 스테이지 번호
    public GameObject[] Enemys; // 스테이지에서 등장할 적
}