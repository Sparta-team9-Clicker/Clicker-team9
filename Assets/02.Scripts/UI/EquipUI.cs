using UnityEngine;

public class EquipUI : MonoBehaviour
{
    public GameObject upBtn;
    public GameObject downBtn;

    public Animator equipPanel;

    public GameObject layout;
    public GameObject escape;
    public GameObject weapon;
    public GameObject needMoney;

    private void Start()
    {
        upBtn.gameObject.SetActive(false);
        downBtn.gameObject.SetActive(true);
    }

    public void OnClickUpBtn() // ��ȭâ �ø��� ��ư
    {
        upBtn.gameObject.SetActive(false);
        downBtn.gameObject.SetActive(true);
        equipPanel.SetBool("IsDown", false);
        BtnTrue();
    }

    public void OnClickDownBtn() // ��ȭâ ������ ��ư
    {
        upBtn.gameObject.SetActive(true);
        downBtn.gameObject.SetActive(false);
        equipPanel.SetBool("IsDown", true);
        BtnFalse();
    }

    public void BtnFalse() // ��ȭâ UI�� ����
    {
        layout.SetActive(false);
        escape.SetActive(false);
        weapon.SetActive(false);
        needMoney.SetActive(false);
    }

    public void BtnTrue() // ��ȭâ UI�� �ѱ�
    {
        layout.SetActive(true);
        escape.SetActive(true);
        weapon.SetActive(true);
        needMoney.SetActive(true);
    }
}
