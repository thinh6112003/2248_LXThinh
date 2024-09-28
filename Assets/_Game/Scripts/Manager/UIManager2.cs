using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager2 : Singleton<UIManager2>
{
    [SerializeField] private GameObject loadCanvas;

    [SerializeField] private Slider loadSlider;
    [SerializeField] private TextMeshProUGUI textLoad;

    [SerializeField] private float speed;
    private float slidervalue;
    private void Start()
    {
        slidervalue = 0;
        textLoad.text = "0%";
    }

    private void Update()
    {
        slidervalue = slidervalue+  speed;
        loadSlider.value = slidervalue;
        textLoad.text = Mathf.Round(loadSlider.value) + "%";

        if (loadSlider.value >= 100f)
        {
            loadCanvas.SetActive(false);
            UIManager.Instance.HomeCanvas.SetActive(true);
        }
    }
}
