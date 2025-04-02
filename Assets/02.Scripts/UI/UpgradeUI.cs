using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    public GameObject upBtn;
    public GameObject downBtn;

    public Animator btnAnim;

    public GameObject btns;
    public GameObject equip;

    private void Start()
    {
        upBtn.gameObject.SetActive(false);
        downBtn.gameObject.SetActive(true);
    }

    public void OnClickUpBtn() // 강화창 올리기 버튼
    {
        upBtn.gameObject.SetActive(false);
        downBtn.gameObject.SetActive(true);
        btnAnim.SetBool("IsDown", false);
        BtnTrue();
    }

    public void OnClickDownBtn() // 강화창 내리기 버튼
    {
        upBtn.gameObject.SetActive(true);
        downBtn.gameObject.SetActive(false);
        btnAnim.SetBool("IsDown", true);
        BtnFalse();
    }

    public void BtnFalse() // 강화창 UI들 끄기
    {
        btns.SetActive(false);
        equip.SetActive(false);
    }

    public void BtnTrue() // 강화창 UI들 켜기
    {
        btns.SetActive(true);
        equip.SetActive(true);
    }
}
