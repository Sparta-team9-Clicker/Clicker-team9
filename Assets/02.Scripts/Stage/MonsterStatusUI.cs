using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonsterStatusUI : MonoBehaviour
{
    private int curValue; // 현재 몬스터 체력
    private int maxValue; // 몬스터 최대 체력
    public TextMeshProUGUI monsterName; // 몬스터 이름 표시 UI
    public Slider uiBar; // 몬스터 체력을 표시하는 UI

    //UI 요소(체력 바, 몬스터 이름)를 초기화하는 역할
    public void SetMonsterData(MonsterData monsterData)
    {
        if (monsterData != null)
        {
            maxValue = monsterData.monsterHP;
            curValue = maxValue;

            // UI 바의 최대값과 현재 체력 동기화
            uiBar.maxValue = maxValue;
            uiBar.value = curValue;

            // 몬스터 이름 표시
            monsterName.text = monsterData.monsterName;
        }
    }

    // 체력 UI를 업데이트하는 함수
    public void UpdateHP(int hp)
    {
        curValue = hp; // 전달받은 hp 값으로 갱신
        uiBar.value = curValue; // UI 바의 값을 업데이트하여 체력 표시
    }
}
