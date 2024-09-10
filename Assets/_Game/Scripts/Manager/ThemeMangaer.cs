using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ThemeMangaer : Singleton<ThemeMangaer> 
{
    [SerializeField] private GameObject homeCanvas;
    [SerializeField] private GameObject playCanvas;
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private Sprite sprite1;
    [SerializeField] private Sprite sprite2;
    [SerializeField] private Sprite sprite3;
    [SerializeField] private Sprite sprite4;

    [SerializeField] private Button w1Btn;
    [SerializeField] private Button w2Btn;
    [SerializeField] private Button w3Btn;
    [SerializeField] private Button w4Btn;

    private void Start()
    {
        w1Btn.onClick.AddListener(OnClickW1Btn);
        w2Btn.onClick.AddListener(OnClickW2Btn);
        w3Btn.onClick.AddListener(OnClickW3Btn);
        w4Btn.onClick.AddListener(OnClickW4Btn);
    }

    public void OnClickW1Btn()
    {
        homeCanvas.GetComponent<Image>().sprite = sprite1;
        playCanvas.GetComponent<Image>().sprite = sprite1;
        playCanvas.GetComponent<Image>().sprite = sprite1;

        w1Btn.GetComponent<Image>().color = Color.green;
        w2Btn.GetComponent<Image>().color = Color.white;
        w3Btn.GetComponent<Image>().color = Color.white;
        w4Btn.GetComponent<Image>().color = Color.white;
    }
    public void OnClickW2Btn()
    {
        homeCanvas.GetComponent<Image>().sprite = sprite2;
        playCanvas.GetComponent<Image>().sprite = sprite2;
        pauseCanvas.GetComponent<Image>().sprite = sprite2;

        w1Btn.GetComponent<Image>().color = Color.white;
        w2Btn.GetComponent<Image>().color = Color.green;
        w3Btn.GetComponent<Image>().color = Color.white;
        w4Btn.GetComponent<Image>().color = Color.white;
    }
    public void OnClickW3Btn()
    {
        homeCanvas.GetComponent<Image>().sprite = sprite3;
        playCanvas.GetComponent<Image>().sprite = sprite3;
        pauseCanvas.GetComponent<Image>().sprite = sprite3;

        w1Btn.GetComponent<Image>().color = Color.white;
        w2Btn.GetComponent<Image>().color = Color.white;
        w3Btn.GetComponent<Image>().color = Color.green;
        w4Btn.GetComponent<Image>().color = Color.white;
    }
    public void OnClickW4Btn()
    {
        homeCanvas.GetComponent<Image>().sprite = sprite4;
        playCanvas.GetComponent<Image>().sprite = sprite4;
        pauseCanvas.GetComponent<Image>().sprite = sprite4;

        w1Btn.GetComponent<Image>().color = Color.white;
        w2Btn.GetComponent<Image>().color = Color.white;
        w3Btn.GetComponent<Image>().color = Color.white;
        w4Btn.GetComponent<Image>().color = Color.green;
    }

}
