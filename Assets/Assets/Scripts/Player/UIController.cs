using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // PlayerStats ��ũ��Ʈ�� �Ҵ��� ����
    public PlayerStats playerStats;

    // ��ư���� �ν����Ϳ��� ����
    public Button increaseAttackPowerButton;
    public Button increaseAutoAttackPowerButton;
    public Button decreaseAutoAttackIntervalButton;

    void Start()
    {
        // ��ư Ŭ�� �� �޼��� ȣ��
        increaseAttackPowerButton.onClick.AddListener(IncreaseAttackPower);
        increaseAutoAttackPowerButton.onClick.AddListener(IncreaseAutoAttackPower);
        decreaseAutoAttackIntervalButton.onClick.AddListener(DecreaseAutoAttackInterval);
    }

    // ���ݷ� ��ȭ ��ư Ŭ�� ��
    void IncreaseAttackPower()
    {
        playerStats.IncreaseAttackPower(5);  // ���÷� 5��ŭ ���ݷ��� ������Ŵ
    }

    // �ڵ� ���ݷ� ��ȭ ��ư Ŭ�� ��
    void IncreaseAutoAttackPower()
    {
        playerStats.IncreaseAutoAttackPower(2f);  // ���÷� �ڵ� ���ݷ��� 2��ŭ ������Ŵ
    }

    // �ڵ� ���� ������ ���� ��ư Ŭ�� ��
    void DecreaseAutoAttackInterval()
    {
        playerStats.DecreaseAutoAttackInterval(0.2f);  // ���÷� �ڵ� ���� ������ 0.2�� ����
    }
}

