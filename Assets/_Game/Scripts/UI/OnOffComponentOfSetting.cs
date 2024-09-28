using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OnOffComponentOfSetting : MonoBehaviour
{ 
    [SerializeField] private Button musicOnOffBtn;
    [SerializeField] private GameObject fill1;
    [SerializeField] private GameObject onHandle1;
    [SerializeField] private GameObject offHandle1;
    void Start()
    {
        musicOnOffBtn.onClick.AddListener(MusicOnOffOnclick);
    }
    private void MusicOnOffOnclick()
    {
        bool t = onHandle1.activeInHierarchy;
        fill1.SetActive(!t);
        onHandle1.SetActive(!t);
        offHandle1.SetActive(t);
    }
}
