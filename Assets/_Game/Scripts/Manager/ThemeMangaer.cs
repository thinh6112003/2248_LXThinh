using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ThemeMangaer : Singleton<ThemeMangaer> 
{
    [SerializeField] private GameObject homeCanvas;
    [SerializeField] private GameObject playCanvas;
    [SerializeField] private GameObject themeCanvas;
    [SerializeField] private GameObject shopCanvas;

    [SerializeField] private ThemeSO themeSO;
    [SerializeField] private TextMeshProUGUI themeTMP;

    [SerializeField] private Image W;
    [SerializeField] private Button buyBtn;
    [SerializeField] private Button equidBtn;
    [SerializeField] private Button equidedBtn;
    [SerializeField] private Button previousBtn;
    [SerializeField] private Button nextBtn;
    [SerializeField] private Button escBtb;
    [SerializeField] private int max;

    private int index;

    public GameObject HomeCanvas { get => homeCanvas; set => homeCanvas = value; }
    public GameObject PlayCanvas { get => playCanvas; set => playCanvas = value; }
    public GameObject ThemeCanvas { get => themeCanvas; set => themeCanvas = value; }
    public ThemeSO ThemeSO { get => themeSO; set => themeSO = value; }
    public GameObject ShopCanvas { get => shopCanvas; set => shopCanvas = value; }
    private void Start()
    {
        index = DataManager.Instance.dataDynamic.currentTheme;
        ChangeTheme();
        ChangeThemeInTheme();
        OnEquipedBtn();
        escBtb.onClick.AddListener(OnClickEcsBtn);
        previousBtn.onClick.AddListener(OnClickPreviousBtn);
        nextBtn.onClick.AddListener(OnClickNextBtn);
        buyBtn.onClick.AddListener(OnClickBuyBtn);
        equidBtn.onClick.AddListener(OnClickEquipBtn);
    }
    public void OnClickBuyBtn()
    {
        if(DataManager.Instance.dataDynamic.currentDynament>= 150)
        {
            OnEquipBtn();
            DataManager.Instance.dataDynamic.buyingSatus[index] = BuyingStatus.BUY;
            DataManager.Instance.dataDynamic.currentDynament -= 150;
            UIManager.Instance.UpdateScoreDyamon();
        }
    }
    public void OnClickEquipBtn()
    {
        DataManager.Instance.dataDynamic.currentTheme = index;
        ChangeTheme();
        OnEquipedBtn();
    }
    public void OnClickEcsBtn()
    {
        homeCanvas.SetActive(true);
        themeCanvas.SetActive(false);
    }
    public void OnClickNextBtn()
    {
        index++;
        if (index > max) index = 0;
        ChangeThemeInTheme();
        ShowBuyingStatus();
    }
    public void ShowBuyingStatus()
    {
        if (index == DataManager.Instance.dataDynamic.currentTheme) OnEquipedBtn() ;
        else
        {
            if (DataManager.Instance.dataDynamic.buyingSatus[index] == BuyingStatus.BUY) OnEquipBtn();
            else OnBuybtn();
        }
    }
    public void OnBuybtn()
    {
        buyBtn.gameObject.SetActive(true);
        equidBtn.gameObject.SetActive(false);
        equidedBtn.gameObject.SetActive(false);
    }
    public void OnEquipBtn()
    {

        buyBtn.gameObject.SetActive(false);
        equidBtn.gameObject.SetActive(true);
        equidedBtn.gameObject.SetActive(false);
    }
    public void OnEquipedBtn()
    {

        buyBtn.gameObject.SetActive(false);
        equidBtn.gameObject.SetActive(false);
        equidedBtn.gameObject.SetActive(true);
    }
    public void OnClickPreviousBtn()
    {
        index--;
        if (index < 0) index = max;
        ChangeThemeInTheme();
        ShowBuyingStatus();
    }


    public void ChangeThemeInTheme()
    {
        W.sprite = themeSO.listTheme[index].themeSprite;
        themeTMP.text = themeSO.listTheme[index].themeName;
    }

    public void ChangeTheme()
    {
        HomeCanvas.GetComponent<Image>().sprite = ThemeSO.listTheme[index].themeSprite;
        PlayCanvas.GetComponent<Image>().sprite = ThemeSO.listTheme[index].themeSprite;
        ThemeCanvas.GetComponent<Image>().sprite = ThemeSO.listTheme[index].themeSprite;
        ShopCanvas.GetComponent<Image>().sprite = ThemeSO.listTheme[index].themeSprite;
    }
}
