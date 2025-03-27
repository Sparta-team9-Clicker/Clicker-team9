using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    private float autoAttackTime = 0f;
    private Coroutine autoAttackCoroutine;
    public ParticleSystem myParticleSystem;
    //[SerializeField] Button Upgrade;

    private void Start()
    {
        autoAttackCoroutine = StartCoroutine(AutoAttack());
        StopCoroutine(AutoAttack());
        //Upgrade.onClick.AddListener(UpgradeBtn);
    }
    public void AttackBtn()
    {
        Debug.Log("Attack");
        myParticleSystem.Play();
    }
    
    IEnumerator AutoAttack()
    {
        while (true) 
        { 
            yield return new WaitForSeconds(1f / autoAttackTime);
            AttackBtn(); 
        }
    }

    public void UpgradeBtn()
    {
        autoAttackTime += 0.3f;
        Debug.Log("Upgrade");

        StopCoroutine(autoAttackCoroutine);
        autoAttackCoroutine = StartCoroutine(AutoAttack());
    }
}

