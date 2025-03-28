using UnityEngine;
using UnityEngine.UI;

public class MonsterStatusUI : MonoBehaviour
{
    private int curValue;
    private int maxValue;
    public Slider uiBar;

    // 몬스터 데이터 설정
    public void SetMonsterData(MonsterData monsterData)
    {
        if (monsterData != null)
        {
            maxValue = monsterData.monsterHP;
            curValue = maxValue;
            uiBar.maxValue = maxValue;
            uiBar.value = curValue;
            Debug.Log($"몬스터 체력: {curValue}");
        }
    }

    //public void UpdateHP(int hp)
    //{
    //    curValue = hp;
    //    uiBar.value = curValue;
    //}
    void Update()
    {
        uiBar.value = GetPercentage();
    }

    public int GetPercentage()
    {
        return maxValue > 0 ? curValue / maxValue : 0;
    }
}
