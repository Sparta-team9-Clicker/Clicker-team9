using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonsterStatusUI : MonoBehaviour
{
    private int curValue; // 현재 몬스터의 체력
    private int maxValue; // 몬스터의 최대 체력
    public TextMeshProUGUI monsterName; // 몬스터 이름을 표시하는 UI
    public Slider uiBar; // 몬스터 체력을 표시하는 UI

    // UI 요소 초기화
    public void SetMonsterDataUI(MonsterData monsterData)
    {
        if (monsterData != null)
        {
            maxValue = monsterData.monsterHP; // 최대 체력 설정
            curValue = maxValue; // 최대 체력 설정
            uiBar.maxValue = maxValue; // UI 바의 최대값과 현재 체력 동기화
            uiBar.value = curValue; 
            monsterName.text = monsterData.monsterName; // 몬스터 이름 표시
        }
    }

    // 체력 UI 업데이트 함수
    public void UpdateHP(int hp)
    {
        curValue = hp; // 현재 체력을 Hp값으로 갱신
        uiBar.value = curValue; // UI 바의 값을 업데이트 하여 체력 표시
    }
}
