using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    PlayerData playerData;

    public TextMeshProUGUI powerText;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI criticalText;
    public TextMeshProUGUI criticalDamageText;
    public TextMeshProUGUI stageText;

    public GameObject panel;

    //무기공격력, 추후 무기 스크립트 만들어지면 가져올 예정
    public int equipPower = 10;

    private void Start()
    {
        playerData = GameManager.Instance.playerData;
        playerData.Eqiup = false;        

        panel.SetActive(false);

        powerText.text = $"Power {playerData.attackPower.ToString()}";
        goldText.text = $"Gold {playerData.gold.ToString("N0")}";
        criticalText.text = $"Critical {playerData.critical.ToString()}%";
        criticalDamageText.text = $"CriticalDamage {playerData.criticalDamage.ToString()}%";
        stageText.text = $"Stage {playerData.stage}";
    }

    private void Update()
    {
        Gold();
        goldText.text = $"Gold {playerData.gold.ToString("N0")}";
    }

    public void AttackPower()
    {
        if (!playerData.Eqiup)
        {
            if (playerData.attackUpgrade >= 2)
                playerData.attackPower += 10;            
        }
        else
        {
            playerData.attackPower += equipPower + playerData.attackUpgrade;
        }
    }

    public void Gold()
    {
        playerData.gold += playerData.goldBonusUpgrade;
    }

    public void Critical()
    {        
        if (playerData.criticalUpgrade >= 2)
        {
            playerData.critical += playerData.critical * (playerData.criticalUpgrade / 10);
        }
    }

    public void CriticalDamage()
    {        
        if (playerData.criticalDamageUpgrade >= 2)
        {
            playerData.criticalDamage += playerData.criticalDamage * (playerData.criticalDamageUpgrade / 10);
        }
    }

    public void OnClickPowerUp()
    {
        if (playerData.gold >= 100)
        {
            playerData.gold -= 100;
            playerData.attackUpgrade++;
            AttackPower();
            powerText.text = $"Power {playerData.attackPower.ToString()}";
        }
        else
        {
            StartCoroutine(ShowPanel());
        }
    }

    public void OnClickCriticalUp()
    {
        if (playerData.gold >= 100)
        {
            playerData.gold -= 100;
            playerData.criticalUpgrade++;
            Critical();
            criticalText.text = $"Critical {playerData.critical.ToString()}%";
        }
        else
        {
            StartCoroutine(ShowPanel());
        }
    }

    public void OnClickCriticalDamageUp()
    {
        if (playerData.gold >= 100)
        {
            playerData.gold -= 100;
            playerData.criticalDamageUpgrade++;
            CriticalDamage();
            criticalDamageText.text = $"CriticalDamage {playerData.criticalDamage.ToString()}%";
        }
        else
        {
            StartCoroutine(ShowPanel());
        }
    }

    public void OnClickGoldUp()
    {
        if (playerData.gold >= 100)
        {
            playerData.gold -= 100;
            playerData.goldBonusUpgrade++;
        }
        else
        {
            StartCoroutine(ShowPanel());
        }
    }

    public void OnClickEquip()
    {
        playerData.Eqiup = !playerData.Eqiup;
        if (playerData.Eqiup)
        {
            playerData.attackPower += equipPower;
            powerText.text = $"Power {playerData.attackPower.ToString()}";
        }
        else
        {
            playerData.attackPower -= equipPower;
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
