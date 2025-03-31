using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    PlayerData playerData;

    PowerStat powerStat;
    CriticalStat criticalStat;
    CriticalDamageStat criticalDamageStat;
    GoldStat goldStat;

    public TextMeshProUGUI powerText;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI criticalText;
    public TextMeshProUGUI criticalDamageText;
    public TextMeshProUGUI stageText;

    public TextMeshProUGUI powerNeedGoldText;
    public TextMeshProUGUI goldNeedGoldText;
    public TextMeshProUGUI criticalNeedGoldText;
    public TextMeshProUGUI criticalDamageNeedGoldText;

    public GameObject panel;

    private void Start()
    {
        playerData = GameManager.Instance.playerData;

        powerStat = new PowerStat(playerData, this);
        criticalStat = new CriticalStat(playerData, this);
        criticalDamageStat = new CriticalDamageStat(playerData, this);
        goldStat = new GoldStat(playerData, this);

        panel.SetActive(false);
        UpdateUI();
    }

    private void Update()
    {
        goldStat.Gold();
        goldText.text = $"{playerData.gold.ToString("N0")}";
    }

    private void UpdateUI()
    {
        powerText.text = $"{playerData.attackPower.ToString("N0")}";
        criticalText.text = $"Critical {playerData.critical.ToString("N2")}%";
        criticalDamageText.text = $"CriticalDamage {playerData.criticalDamage.ToString("N0")}%";
        powerNeedGoldText.text = $"Power ({TotalCost(playerData.attackUpgrade):N0})";
        goldNeedGoldText.text = $"Gold ({TotalCost(playerData.goldBonusUpgrade):N0})";
        criticalNeedGoldText.text = $"Critical ({TotalCost(playerData.criticalUpgrade):N0})";
        criticalDamageNeedGoldText.text = $"Critical Damage ({TotalCost(playerData.criticalDamageUpgrade):N0})";
        GameManager.Instance.SaveData();
    }

    public int TotalCost(int upgradeLevel)
    {
        int baseGold = 100;
        float multiplier = 1.2f;
        int totalCost = 0;

        for (int i = 0; i <= upgradeLevel; i++)
        {
            totalCost += (int)(baseGold * MathF.Pow(multiplier, i));
        }

        return totalCost;
    }

    public void OnClickPowerUp()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Button);
        if (playerData.gold < TotalCost(playerData.attackUpgrade))
        {
            StartCoroutine(ShowPanel());
        }
        else
        {
            powerStat.Upgrade();
            UpdateUI();
        }
    }

    public void OnClickCriticalUp()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Button);
        if (playerData.gold < TotalCost(playerData.criticalUpgrade))
        {
            StartCoroutine(ShowPanel());
        }
        else
        {
            criticalStat.Upgrade();
            UpdateUI();
        }
    }

    public void OnClickCriticalDamageUp()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Button);
        if (playerData.gold < TotalCost(playerData.criticalDamageUpgrade))
        {
            StartCoroutine(ShowPanel());
        }
        else
        {
            criticalDamageStat.Upgrade();
            UpdateUI();
        }
    }

    public void OnClickGoldUp()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Button);
        if (playerData.gold < TotalCost(playerData.goldBonusUpgrade))
        {
            StartCoroutine(ShowPanel());
        }
        else
        {
            goldStat.Upgrade();
            UpdateUI();
        }
    }

    public void OnClickEquip()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Button);
        playerData.Eqiup = !playerData.Eqiup;
        if (playerData.Eqiup)
        {
            playerData.attackPower += powerStat.equipPower;
            powerText.text = $"{playerData.attackPower.ToString()}";
        }
        else
        {
            playerData.attackPower -= powerStat.equipPower;
            powerText.text = $"{playerData.attackPower.ToString()}";
        }
        GameManager.Instance.SaveData();
    }

    public void OnClickMain()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Attack);
        playerData.gold += 100;
        GameManager.Instance.SaveData();
    }

    IEnumerator ShowPanel()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Fail);
        panel.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        panel.SetActive(false);
    }

    public void OnClickSave()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Button);
        GameManager.Instance.SaveData();
    }
}
