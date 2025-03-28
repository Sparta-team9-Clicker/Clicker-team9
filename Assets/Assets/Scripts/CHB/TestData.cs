using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestData : MonoBehaviour
{
    public static TestData instance;
    public MonsterData monsterData;
    public Slider scoreSlider;
    public List<MonsterData> monsterDataList;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        scoreSlider.maxValue = monsterData.monsterHP;
        UpdateUI();
    }

    public void UpdateUI()
    {
        scoreSlider.value = monsterData.monsterHP;
    }

    public void Damage(int damage)
    {
        monsterData.monsterHP -= damage;
        UpdateUI();
    }
}
