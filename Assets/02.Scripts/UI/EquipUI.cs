using UnityEngine;

public class EquipUI : MonoBehaviour
{
    public GameObject upBtn;
    public GameObject downBtn;

    public Animator equipPanel;

    public GameObject layout;
    public GameObject escape;
    public GameObject weapon;

    private void Start()
    {
        upBtn.gameObject.SetActive(false);
        downBtn.gameObject.SetActive(true);
    }

    public void OnClickUpBtn()
    {
        upBtn.gameObject.SetActive(false);
        downBtn.gameObject.SetActive(true);
        equipPanel.SetBool("IsDown", false);
        BtnTrue();
    }

    public void OnClickDownBtn()
    {
        upBtn.gameObject.SetActive(true);
        downBtn.gameObject.SetActive(false);
        equipPanel.SetBool("IsDown", true);
        BtnFalse();
    }

    public void BtnFalse()
    {
        layout.SetActive(false);
        escape.SetActive(false);
        weapon.SetActive(false);
    }

    public void BtnTrue()
    {
        layout.SetActive(true);
        escape.SetActive(true);
        weapon.SetActive(true);
    }
}
