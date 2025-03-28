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
    public AudioClip[] touchSound;
    public AudioSource audioSource;
    //[SerializeField] Button Upgrade;

    private void Start()
    {
        autoAttackCoroutine = StartCoroutine(AutoAttack());
        StopCoroutine(AutoAttack());
        //Upgrade.onClick.AddListener(UpgradeBtn);
    }
    public void AttackBtn()
    {
        Touch();
        if (Random.Range(0, 100) < criticalChance)
        {
            audioSource.PlayOneShot(touchSound[0]);
            Debug.Log("Critical");
            criticalParticle.Play();
        }
        else
        {
            audioSource.PlayOneShot(touchSound[1]);
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

    void Touch()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        attackParticle.transform.position = pos;
        criticalParticle.transform.position = pos;
    }
}

