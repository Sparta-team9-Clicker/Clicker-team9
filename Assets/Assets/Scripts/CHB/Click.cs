using System.Collections;
using UnityEngine;

public class Click : MonoBehaviour
{
    private float autoAttackTime = 0f;
    public int criticalChance = 5;
    private Coroutine autoAttackCoroutine;
    public ParticleSystem attackParticle;
    public ParticleSystem criticalParticle;
    public AudioClip[] touchSound;
    public AudioSource audioSource;
    public MonsterData monsterData;
    public MonsterStatus monsterStatus;

    public GameObject HammerPrefab;

    //[SerializeField] Button Upgrade;

    private void Start()
    {
        StopCoroutine(AutoAttack());
        autoAttackCoroutine = StartCoroutine(AutoAttack());
        //Upgrade.onClick.AddListener(UpgradeBtn);
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
        if (Random.Range(0, 100) < criticalChance)
        {
            audioSource.PlayOneShot(touchSound[0]);
            Debug.Log("Critical");
            criticalParticle.Play();
            //TestData.instance.Damage(20);
            monsterStatus.TakeDamage(GameManager.Instance.playerData.criticalDamage);
        }
        else
        {
            audioSource.PlayOneShot(touchSound[1]);
            Debug.Log("Attack");
            attackParticle.Play();
            //TestData.instance.Damage(10);
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

    void TouchPos()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Instantiate(HammerPrefab, pos, Quaternion.identity);
        pos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height / 2));
        attackParticle.transform.position = pos;
        criticalParticle.transform.position = pos;

    }

    void AutoPos()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height / 2));
        //Instantiate(HammerPrefab, pos, Quaternion.identity);
        attackParticle.transform.position = pos;
        criticalParticle.transform.position = pos;
    }
}

