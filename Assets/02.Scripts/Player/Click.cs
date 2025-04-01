using System.Collections;
using UnityEngine;

public class Click : MonoBehaviour
{
    private float autoAttackTime = 0f;    
    private Coroutine autoAttackCoroutine;
    public ParticleSystem attackParticle;
    public ParticleSystem criticalParticle;
    public MonsterData monsterData;
    public MonsterStatus monsterStatus;

    public GameObject panel;

    private void Start()
    {
        StopCoroutine(AutoAttack());
        autoAttackCoroutine = StartCoroutine(AutoAttack());        
        monsterStatus = FindObjectOfType<MonsterStatus>();
    }
    public void SetTarget(MonsterStatus newTarget)
    {
        monsterStatus = newTarget;
    }

    public void AttackBtn()
    {
        TouchPos();
        Attack();
    }

    void Attack()
    {
        if (monsterStatus == null) return;
        if (Random.Range(0, 100) < GameManager.Instance.playerData.critical)
        {
            AudioManager.instance.PlaySfx(AudioManager.Sfxs.Attack);            
            criticalParticle.Play();
            monsterStatus.TakeDamage(GameManager.Instance.playerData.criticalDamage);
        }
        else
        {
            AudioManager.instance.PlaySfx(AudioManager.Sfxs.Attack);            
            attackParticle.Play();
            monsterStatus.TakeDamage(GameManager.Instance.playerData.attackPower);
        }
    }

    IEnumerator AutoAttack()
    {
        while (true)
        {
            AutoPos();
            yield return new WaitForSeconds(1f / autoAttackTime);
            Attack();
        }
    }

    public void AutoUpgradeBtn()
    {
        if (GameManager.Instance.playerData.gold >= 10000)
        {
            GameManager.Instance.playerData.gold -= 10000;
            AudioManager.instance.PlaySfx(AudioManager.Sfxs.Button);

            autoAttackTime += 0.3f;
            GameManager.Instance.SaveData();
            
            StopCoroutine(autoAttackCoroutine);
            autoAttackCoroutine = StartCoroutine(AutoAttack());
        }
        else
        {            
            StartCoroutine(ShowPanel());
        }
    }

    IEnumerator ShowPanel()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfxs.Fail);
        panel.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        panel.SetActive(false);
    }    

    void TouchPos()
    {        
        Vector2 pos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height / 2));
        attackParticle.transform.position = pos;
        criticalParticle.transform.position = pos;
    }

    void AutoPos()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height / 2));        
        attackParticle.transform.position = pos;
        criticalParticle.transform.position = pos;
    }
}

