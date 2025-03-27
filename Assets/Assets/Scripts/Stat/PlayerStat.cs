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
    //public int powerNeedGold;

    public GameObject panel;

    //무기공격력, 추후 무기 스크립트 만들어지면 가져올 예정
    //public int equipPower = 10;

    private void Start()
    {
        playerData = GameManager.Instance.playerData;

        //playerData.Eqiup = false;        

        powerStat = new PowerStat(playerData);
        criticalStat = new CriticalStat(playerData);
        criticalDamageStat = new CriticalDamageStat(playerData);
        goldStat = new GoldStat(playerData);

        panel.SetActive(false);
        UpdateUI();

        //powerText.text = $"Power {playerData.attackPower.ToString()}";
        //goldText.text = $"Gold {playerData.gold.ToString("N0")}";
        //criticalText.text = $"Critical {playerData.critical.ToString()}%";
        //criticalDamageText.text = $"CriticalDamage {playerData.criticalDamage.ToString()}%";
        //stageText.text = $"Stage {playerData.stage}";

        //powerNeedGold = 100;
        //powerNeedGoldText.text = $"Power ({powerNeedGold.ToString("N0")})";
    }

    private void Update()
    {
        goldStat.Gold();
        goldText.text = $"Gold {playerData.gold.ToString("N0")}";
    }

    private void UpdateUI()
    {
        powerText.text = $"Power {playerData.attackPower}";
        criticalText.text = $"Critical {playerData.critical}%";
        criticalDamageText.text = $"CriticalDamage {playerData.criticalDamage}%";
        powerNeedGoldText.text = $"Power ({playerData.attackUpgrade * 100:N0})";
    }

    //public void AttackPower()
    //{
    //    if (!playerData.Eqiup)
    //    {
    //        if (playerData.attackUpgrade >= 2)
    //            playerData.attackPower += 10;
    //    }
    //    else
    //    {
    //        playerData.attackPower += equipPower + playerData.attackUpgrade;
    //    }
    //}

    //public void Gold()
    //{
    //    playerData.gold += playerData.goldBonusUpgrade;
    //}

    //public void Critical()
    //{        
    //    if (playerData.criticalUpgrade >= 2)
    //    {
    //        playerData.critical += playerData.critical * (playerData.criticalUpgrade / 10);
    //    }
    //}

    //public void CriticalDamage()
    //{        
    //    if (playerData.criticalDamageUpgrade >= 2)
    //    {
    //        playerData.criticalDamage += playerData.criticalDamage * (playerData.criticalDamageUpgrade / 10);
    //    }
    //}

    public void OnClickPowerUp()
    {
        //if (playerData.gold >= powerNeedGold)
        //{
        //    playerData.gold -= powerNeedGold;
        //    powerNeedGold += 100;
        //    playerData.attackUpgrade++;
        //    AttackPower();
        //    powerText.text = $"Power {playerData.attackPower.ToString()}";
        //    powerNeedGoldText.text = $"Power ({powerNeedGold.ToString("N0")})";
        //}
        //else
        //{
        //    StartCoroutine(ShowPanel());
        //}
        powerStat.Upgrade();
        UpdateUI();
    }

    public void OnClickCriticalUp()
    {
        //if (playerData.gold >= 100)
        //{
        //    playerData.gold -= 100;
        //    playerData.criticalUpgrade++;
        //    Critical();
        //    criticalText.text = $"Critical {playerData.critical.ToString()}%";
        //}
        //else
        //{
        //    StartCoroutine(ShowPanel());
        //}
        criticalStat.Upgrade();
        UpdateUI();
    }

    public void OnClickCriticalDamageUp()
    {
        //if (playerData.gold >= 100)
        //{
        //    playerData.gold -= 100;
        //    playerData.criticalDamageUpgrade++;
        //    CriticalDamage();
        //    criticalDamageText.text = $"CriticalDamage {playerData.criticalDamage.ToString()}%";
        //}
        //else
        //{
        //    StartCoroutine(ShowPanel());
        //}
        criticalDamageStat.Upgrade();
        UpdateUI();
    }

    public void OnClickGoldUp()
    {
        //if (playerData.gold >= 100)
        //{
        //    playerData.gold -= 100;
        //    playerData.goldBonusUpgrade++;
        //}
        //else
        //{
        //    StartCoroutine(ShowPanel());
        //}
        goldStat.Upgrade();
        UpdateUI();
    }

    public void OnClickEquip()
    {
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
    }

    public void OnClickMain()
    {
        playerData.gold += 100;
    }

    IEnumerator ShowPanel()
    {
        panel.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        panel.SetActive(false);
    }
}
