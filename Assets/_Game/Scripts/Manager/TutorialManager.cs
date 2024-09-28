using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : Singleton<TutorialManager>
{
    [SerializeField] private TutorialSO tutorialSO;

    [SerializeField] private Button previousBtn;
    [SerializeField] private Button nextBtn;
    [SerializeField] private Button escBtb;
    [SerializeField] private int max;

    [SerializeField] private Image tutImage;
    [SerializeField] private TextMeshProUGUI tutTMP;

    [SerializeField] private int index;

    private void Start()
    {
        index = 0;
        ChangeImageText();
        escBtb.onClick.AddListener(OnClickEcsBtn);
        previousBtn.onClick.AddListener(OnClickPreviousBtn);
        nextBtn.onClick.AddListener(OnClickNextBtn);
    }

    public void OnClickEcsBtn()
    {
        UIManager.Instance.GamePlay.SetActive(true);
        UIManager.Instance.TutorialCanvas.SetActive(false);
    }
    public void OnClickNextBtn()
    {
        index++;
        if (index > max) index = 0;
        ChangeImageText();
    }

    public void OnClickPreviousBtn()
    {
        index--;
        if(index<0) index = max;
        ChangeImageText();
    }

    public void ChangeImageText()
    {
        tutImage.sprite = tutorialSO.listTut[index].tutorialSprite;
        tutTMP.text = tutorialSO.listTut[index].tutorialText;
    }
}
