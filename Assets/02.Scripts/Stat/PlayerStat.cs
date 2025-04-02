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

    public TextMeshProUGUI weaponInfoText; // ���� ���� UI �ؽ�Ʈ

    private void Awake()
    {
        if (GameManager.Instance == null || GameManager.Instance.playerData == null)
        {
            Debug.Log("GameManager �Ǵ� PlayerData�� �ʱ�ȭ���� �ʾҽ��ϴ�.");
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

    private void UpdateUI() // �÷��̾� ���� ������Ʈ
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

    private void UpdateWeaponUI() // ���� ��ȭ ������Ʈ
    {
        weaponInfoText.text = "��ȭ�ϱ�";
        weaponNeedGoldText.text = $"{TotalCost(playerData.weaponUpgrade):N0}";
        powerText.text = $"{playerData.attackPower.ToString("N0")}";
    }

    public int TotalCost(int upgradeLevel) // ��ȭ�� ���� ��� ����
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

    public void OnClickPowerUp() // �Ŀ��� ��ư
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

    public void OnClickCriticalUp() // ũ��Ƽ�� Ȯ���� ��ư
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

    public void OnClickCriticalDamageUp() // ũ��Ƽ�� �������� ��ư
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

    public void OnClickGoldUp() // ��� ȹ�淮�� ��ư
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

    IEnumerator ShowPanel() // �� ������ ���� �ǳ�
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Fail);
        panel.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        panel.SetActive(false);
    }

    public void OnClickSave() // ���̺� ��ư
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Button);
        GameManager.Instance.SaveData();
    }

    public void OnClickEQPanel() // ���â ��ư
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Button);
        equipPanel.SetActive(true);
        Btns.SetActive(false);
    }

    public void OnClickEscapeInventory() // ���â ������ ��ư
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Button);
        equipPanel.SetActive(false);
        Btns.SetActive(true);
    }

    public void DisplayWeapon() // ������ ��� ����ִ� ��ư
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Button);

        if(playerData.Eqiup == false) // ��� ���� �� ���׷��̵忡 ���� ��������
        {
            WeaponStatUpgrade();
        }

        playerData.Eqiup = true;
        weaponIcon.SetActive(true);
        UpdateWeaponUI();
    }

    public void WeaponUpgrade() // ��� ��ȭ ��ư
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

    public void WeaponStatUpgrade() // ��� ���� �� ���׷��̵忡 ���� ��������
    {
        playerData.attackPower += playerData.weaponUpgrade * 5;
        playerData.critical += playerData.weaponUpgrade * 0.5f;
    }
}

