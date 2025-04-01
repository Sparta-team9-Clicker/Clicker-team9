using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // PlayerStats 스크립트를 할당할 변수
    public PlayerStats playerStats;

    // 버튼들을 인스펙터에서 연결
    public Button increaseAttackPowerButton;
    public Button increaseAutoAttackPowerButton;
    public Button decreaseAutoAttackIntervalButton;

    void Start()
    {
        // 버튼 클릭 시 메서드 호출
        increaseAttackPowerButton.onClick.AddListener(IncreaseAttackPower);
        increaseAutoAttackPowerButton.onClick.AddListener(IncreaseAutoAttackPower);
        decreaseAutoAttackIntervalButton.onClick.AddListener(DecreaseAutoAttackInterval);
    }

    // 공격력 강화 버튼 클릭 시
    void IncreaseAttackPower()
    {
        playerStats.IncreaseAttackPower(5);  // 예시로 5만큼 공격력을 증가시킴
    }

    // 자동 공격력 강화 버튼 클릭 시
    void IncreaseAutoAttackPower()
    {
        playerStats.IncreaseAutoAttackPower(2f);  // 예시로 자동 공격력을 2만큼 증가시킴
    }

    // 자동 공격 딜레이 감소 버튼 클릭 시
    void DecreaseAutoAttackInterval()
    {
        playerStats.DecreaseAutoAttackInterval(0.2f);  // 예시로 자동 공격 간격을 0.2초 감소
    }
}

