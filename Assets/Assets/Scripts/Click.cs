using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    private float autoAttackTime = 0f;
    public int criticalChance = 5;
    private Coroutine autoAttackCoroutine;
    public ParticleSystem attackParticle;
    public ParticleSystem criticalParticle;
    //[SerializeField] Button Upgrade;

    private void Start()
    {
        autoAttackCoroutine = StartCoroutine(AutoAttack());
        StopCoroutine(AutoAttack());
        //Upgrade.onClick.AddListener(UpgradeBtn);
    }
    public void AttackBtn()
    {
        if (Random.Range(0, 100) < criticalChance)
        {
            Debug.Log("Critical");
            criticalParticle.Play();
        }
        else
        {
            Debug.Log("Attack");
            attackParticle.Play();
        }
    }
    
    IEnumerator AutoAttack()
    {
        while (true) 
        { 
            yield return new WaitForSeconds(1f / autoAttackTime);
            AttackBtn(); 
        }
    }

    public void AutoUpgradeBtn()
    {
        autoAttackTime += 0.3f;
        Debug.Log("Upgrade");

        StopCoroutine(autoAttackCoroutine);
        autoAttackCoroutine = StartCoroutine(AutoAttack());
    }

    public void CriUpgradeBtn()
    {
        criticalChance += 5;
        Debug.Log("Upgrade Critical");
    }
}

