using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStatus : MonoBehaviour
{
    public MonsterData monsterData;
    private int currentHP;
    public MonsterStatusUI monsterStatusUI;

    public void SetMonsterData(MonsterData data)
    {
        monsterData = data;
        currentHP = monsterData.monsterHP;

        // UI에 데이터 전달
        if (monsterStatusUI != null)
        {
            monsterStatusUI.SetMonsterData(monsterData);
        }
    }

    //public void TakeDamage(int damage)
    //{
    //    currentHP = Mathf.Max(currentHP - damage, 0);

    //    if (monsterStatusUI != null)
    //    {
    //        monsterStatusUI.UpdateHP(currentHP);
    //    }

    //    if (currentHP <= 0)
    //    {
    //        Die();
    //    }
    //}

    //private void Die()
    //{
    //    Debug.Log($"{monsterData.monsterName}이(가) 사망했습니다.");
    //    //GameManager.Instance.AddGold(monsterData.rewardGold);
    //    Stage.Instance.OnMonsterKilled();
    //    Destroy(gameObject);
    //}
}

