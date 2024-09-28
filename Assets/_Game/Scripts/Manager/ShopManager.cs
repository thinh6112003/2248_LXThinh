using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : Singleton<ShopManager>
{
    [SerializeField] private GameObject homePanel;
    [SerializeField] private GameObject shopPanel;

    [SerializeField] private Button m180Btn;
    [SerializeField] private Button m500Btn;
    [SerializeField] private Button m1200Btn;
    [SerializeField] private Button m6500Btn;
    [SerializeField] private Button m15000Btn;

    [SerializeField] private Button escBtn;

    [SerializeField] private TextMeshProUGUI diamondShopText;

    private int index;

    public TextMeshProUGUI DiamondShopText { get => diamondShopText; set => diamondShopText = value; }

    private void Start()
    {
        m180Btn.onClick.AddListener(OnClickAdm180Btn);
        m500Btn.onClick.AddListener(OnClickAdm500Btn);
        m1200Btn.onClick.AddListener (OnClickAdm1200Btn);
        m6500Btn.onClick.AddListener(OnClickAdm6500Btn);
        m15000Btn.onClick.AddListener(OnClickAdm15000Btn);
        escBtn.onClick.AddListener(OnClickECSBtn);
    }
    public void OnClickAdm180Btn()
    {
        index = 180;
        OnClickBuyBtn();
    }

    public void OnClickAdm500Btn()
    {
        index = 500;
        OnClickBuyBtn();
    }

    public void OnClickAdm1200Btn()
    {
        index = 1200;
        OnClickBuyBtn();
    }

    public void OnClickAdm6500Btn()
    {
        index = 6500;
        OnClickBuyBtn();
    }

    public void OnClickAdm15000Btn()
    {
        index = 15000;
        OnClickBuyBtn();

    }
    public void OnClickBuyBtn()
    {
        DataManager.Instance.dataDynamic.currentDynament += index;
        UIManager.Instance.UpdateScoreDyamon();
    }

    public void OnClickECSBtn()
    {
        shopPanel.SetActive(false);
        homePanel.SetActive(true);
    }
}
