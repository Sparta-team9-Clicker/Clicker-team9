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

        powerStat = new PowerStat(playerData);
        criticalStat = new CriticalStat(playerData);
        criticalDamageStat = new CriticalDamageStat(playerData);
        goldStat = new GoldStat(playerData);

        panel.SetActive(false);
        UpdateUI();
    }

    private void Update()
    {
        goldStat.Gold();
        goldText.text = $"Gold {playerData.gold.ToString("N0")}";
    }

    private void UpdateUI()
    {
        powerText.text = $"Power {playerData.attackPower.ToString("N0")}";
        criticalText.text = $"Critical {playerData.critical.ToString("N2")}%";
        criticalDamageText.text = $"CriticalDamage {playerData.criticalDamage.ToString("N0")}%";
        powerNeedGoldText.text = $"Power ({playerData.attackUpgrade * 100:N0})";
        goldNeedGoldText.text = $"Gold ({playerData.goldBonusUpgrade * 100:N0})";
        criticalNeedGoldText.text = $"Critical ({playerData.criticalUpgrade * 100:N0})";
        criticalDamageNeedGoldText.text = $"Critical Damage ({playerData.criticalDamageUpgrade * 100:N0})";
        GameManager.Instance.SaveData();
    }

    public void OnClickPowerUp()
    {        
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Button);
        powerStat.Upgrade();
        if (playerData.gold < powerStat.needGold)
        {
            StartCoroutine(ShowPanel());
        }
        UpdateUI();
    }

    public void OnClickCriticalUp()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Button);
        criticalStat.Upgrade();
        if (playerData.gold < criticalStat.needgold)
        {
            StartCoroutine(ShowPanel());
        }
        UpdateUI();
    }

    public void OnClickCriticalDamageUp()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Button);
        criticalDamageStat.Upgrade();
        if (playerData.gold < criticalDamageStat.needGold)
        {
            StartCoroutine(ShowPanel());
        }
        UpdateUI();
    }

    public void OnClickGoldUp()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Button);
        goldStat.Upgrade();
        if (playerData.gold < goldStat.needGold)
        {
            StartCoroutine(ShowPanel());
        }        
        UpdateUI();
    }

    public void OnClickEquip()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Button);
        playerData.Eqiup = !playerData.Eqiup;
        if (playerData.Eqiup)
        {
            playerData.attackPower += powerStat.equipPower;
            powerText.text = $"Power {playerData.attackPower.ToString()}";
        }
        else
        {
            playerData.attackPower -= powerStat.equipPower;
            powerText.text = $"Power {playerData.attackPower.ToString()}";
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
