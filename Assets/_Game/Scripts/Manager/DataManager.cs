using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public DataDynamic dataDynamic;
    // Start is called before the first frame update
    private void Awake()
    {
        GetPlayerpref();
        if (dataDynamic == null)
        {

            dataDynamic = new DataDynamic();
            dataDynamic.firstTimePlaying = true;
            dataDynamic.currentDynament = 0;
            dataDynamic.currentHighScore = 0;
            dataDynamic.currentHighBlock = 0;
            dataDynamic.currentTheme = 4;
            dataDynamic.buyingSatus = new BuyingStatus[5];
            for(int i=0;i<= 3; i++)
            {
                dataDynamic.buyingSatus[i] = BuyingStatus.NOTBUY;
            }
            dataDynamic.buyingSatus[4] = BuyingStatus.USING;
            SetPlayerpref();
        }
    }
    public void GetPlayerpref()
    {
        string dynamicDataString = PlayerPrefs.GetString("datadynamic");
        dataDynamic = JsonUtility.FromJson<DataDynamic>(dynamicDataString);
    }
    public void SetPlayerpref()
    {
        string dynamicDataString = JsonUtility.ToJson(dataDynamic);
        PlayerPrefs.SetString("datadynamic", dynamicDataString);
    }
    private void OnApplicationQuit()
    {
        SetPlayerpref();
        dataDynamic.firstTimePlaying = false;
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            SetPlayerpref();
        }
    }

}
public class DataDynamic
{
    public bool firstTimePlaying;
    public int currentDynament;
    public int currentHighScore;
    public int currentHighBlock;
    public int currentTheme;
    public BuyingStatus[] buyingSatus;
}
public enum BuyingStatus
{
    NOTBUY,
    BUY,
    USING,
}
