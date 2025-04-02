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

    public TextMeshProUGUI powerNeedGoldText;
    public TextMeshProUGUI goldNeedGoldText;
    public TextMeshProUGUI criticalNeedGoldText;
    public TextMeshProUGUI criticalDamageNeedGoldText;
    public TextMeshProUGUI weaponNeedGoldText;

    public GameObject Btns;
    public GameObject panel;
    public GameObject equipPanel;
    public GameObject escapeInventory;
    public GameObject weaponIcon;
    public GameObject weaponUpgrade;

    public WeaponManager weaponManager;

    public TextMeshProUGUI weaponInfoText; // 무기 정보 UI 텍스트

    private void Awake()
    {
        if (GameManager.Instance == null || GameManager.Instance.playerData == null)
        {
            Debug.Log("GameManager 또는 PlayerData가 초기화되지 않았습니다.");
            return;
        }

        playerData = GameManager.Instance.playerData;

        powerStat = new PowerStat(playerData, this);
        criticalStat = new CriticalStat(playerData, this);
        criticalDamageStat = new CriticalDamageStat(playerData, this);
        goldStat = new GoldStat(playerData, this);

        panel.SetActive(false);
        equipPanel.SetActive(false);
        weaponIcon.SetActive(false);
    }

    private void Start()
    {
        playerData.Eqiup = false;
        UpdateUI();
        UpdateWeaponUI();
    }

    private void Update()
    {
        if (goldStat != null)
            goldStat.Gold();

        if (playerData != null && goldText != null)
            goldText.text = $"{playerData.gold.ToString("N0")}";
    }

    private void UpdateUI() // 플레이어 스탯 업데이트
    {
        if (playerData == null) return;

        powerText.text = $"{playerData.attackPower.ToString("N0")}";
        criticalText.text = $"{playerData.critical.ToString("N2")}%";
        criticalDamageText.text = $"{playerData.criticalDamage.ToString("N0")}%";
        powerNeedGoldText.text = $"{TotalCost(playerData.attackUpgrade):N0}";
        goldNeedGoldText.text = $"{TotalCost(playerData.goldBonusUpgrade):N0}";
        criticalNeedGoldText.text = $"{TotalCost(playerData.criticalUpgrade):N0}";
        criticalDamageNeedGoldText.text = $"{TotalCost(playerData.criticalDamageUpgrade):N0}";

        GameManager.Instance.SaveData();
    }

    private void UpdateWeaponUI() // 무기 강화 업데이트
    {
        weaponInfoText.text = "강화하기";
        weaponNeedGoldText.text = $"{TotalCost(playerData.weaponUpgrade):N0}";
        powerText.text = $"{playerData.attackPower.ToString("N0")}";
    }

    public int TotalCost(int upgradeLevel) // 강화에 따른 비용 증가
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

    public void OnClickPowerUp() // 파워업 버튼
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

    public void OnClickCriticalUp() // 크리티컬 확률업 버튼
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

    public void OnClickCriticalDamageUp() // 크리티컬 데미지업 버튼
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

    public void OnClickGoldUp() // 골드 획득량업 버튼
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

    IEnumerator ShowPanel() // 돈 부족시 띄우는 판넬
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Fail);
        panel.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        panel.SetActive(false);
    }

    public void OnClickSave() // 세이브 버튼
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Button);
        GameManager.Instance.SaveData();
    }

    public void OnClickEQPanel() // 장비창 버튼
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Button);
        equipPanel.SetActive(true);
        Btns.SetActive(false);
    }

    public void OnClickEscapeInventory() // 장비창 나가기 버튼
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Button);
        equipPanel.SetActive(false);
        Btns.SetActive(true);
    }

    public void DisplayWeapon() // 착용한 장비 띄워주는 버튼
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Button);

        if(playerData.Eqiup == false) // 장비 착용 시 업그레이드에 따른 스탯증가
        {
            WeaponStatUpgrade();
        }

        playerData.Eqiup = true;
        weaponIcon.SetActive(true);
        UpdateWeaponUI();
    }

    public void WeaponUpgrade() // 장비 강화 버튼
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Button);
        int totalCost = TotalCost(playerData.weaponUpgrade);

        if (playerData.gold >= totalCost)
        {
            playerData.gold -= totalCost;
            playerData.weaponUpgrade++;
            playerData.attackPower += 5;
            playerData.critical += 0.5f;
            GameManager.Instance.SaveData();
            if (playerData.Eqiup == true)
            {
                UpdateWeaponUI();
            }
        }
        else
        {
            StartCoroutine(ShowPanel());
        }
    }

    public void WeaponStatUpgrade() // 장비 착용 시 업그레이드에 따른 스탯증가
    {
        playerData.attackPower += playerData.weaponUpgrade * 5;
        playerData.critical += playerData.weaponUpgrade * 0.5f;
    }
}

