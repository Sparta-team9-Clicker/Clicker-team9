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

    public void OnClickUpBtn() // 강화창 올리기 버튼
    {
        upBtn.gameObject.SetActive(false);
        downBtn.gameObject.SetActive(true);
        equipPanel.SetBool("IsDown", false);
        BtnTrue();
    }

    public void OnClickDownBtn() // 강화창 내리기 버튼
    {
        upBtn.gameObject.SetActive(true);
        downBtn.gameObject.SetActive(false);
        equipPanel.SetBool("IsDown", true);
        BtnFalse();
    }

    public void BtnFalse() // 강화창 UI들 끄기
    {
        layout.SetActive(false);
        escape.SetActive(false);
        weapon.SetActive(false);
        needMoney.SetActive(false);
    }

    public void BtnTrue() // 강화창 UI들 켜기
    {
        layout.SetActive(true);
        escape.SetActive(true);
        weapon.SetActive(true);
        needMoney.SetActive(true);
    }
}
