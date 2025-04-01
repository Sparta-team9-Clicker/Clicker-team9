using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonsterStatusUI : MonoBehaviour
{
    private int curValue;
    private int maxValue;
    public TextMeshProUGUI monsterName;
    public Slider uiBar;

    public void SetMonsterData(MonsterData monsterData)
    {
        if (monsterData != null)
        {
            maxValue = monsterData.monsterHP;
            curValue = maxValue;
            uiBar.maxValue = maxValue;
            uiBar.value = curValue;
            monsterName.text = monsterData.monsterName;
            Debug.Log($"���� ü��: {curValue}");
        }
    }

    public void UpdateHP(int hp)
    {
        curValue = hp;
        uiBar.value = curValue;
    }
}
