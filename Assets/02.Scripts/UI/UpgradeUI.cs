using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    public GameObject upBtn;
    public GameObject downBtn;

    public Animator btnAnim;

    public GameObject btns;
    public GameObject equip;
    public GameObject save;

    private void Start()
    {
        upBtn.gameObject.SetActive(false);
        downBtn.gameObject.SetActive(true);
    }

    public void OnClickUpBtn()
    {
        upBtn.gameObject.SetActive(false);
        downBtn.gameObject.SetActive(true);
        btnAnim.SetBool("IsDown", false);
        BtnTrue();
    }

    public void OnClickDownBtn()
    {
        upBtn.gameObject.SetActive(true);
        downBtn.gameObject.SetActive(false);
        btnAnim.SetBool("IsDown", true);
        BtnFalse();
    }

    public void BtnFalse()
    {
        btns.SetActive(false);
        equip.SetActive(false);
        save.SetActive(false);
    }

    public void BtnTrue()
    {
        btns.SetActive(true);
        equip.SetActive(true);
        save.SetActive(true);
    }
}
