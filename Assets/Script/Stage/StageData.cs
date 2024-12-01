using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageData", menuName = "ScriptableObject/StageData")]
public class StageData : ScriptableObject
{
    public int stageNumber; // �������� ��ȣ
    public GameObject[] Enemys; // ������������ ������ ��
}