using System;
using UnityEngine;
using UnityEngine.UI;
public class FreeCoins : MonoBehaviour
{
    public Text timetext;
    private int time;
    private bool timeStart;
    DateTime ts;
    TimeSpan tss;

    public delegate void FreecoinTime();
    public static event FreecoinTime feecoinTime;
    private void Awake()
    {
        feecoinTime += OnClick;
        feecoinTime += CheckOffline;
        if (PlayerPrefs.HasKey("LastSession"))
            ts = DateTime.Parse(PlayerPrefs.GetString("LastSession"));
    }
    private void Start()
    {
        if (PlayerPrefs.HasKey("TimeStart"))
        {
            timeStart = true;

        }
        else
        {
            timetext.text = "Ads";
        }
    }
    public void OnClick()
    {
        timeStart = true;
        time = 3600;
        ts = DateTime.Now;
        ts = ts.AddSeconds(time);
        PlayerPrefs.SetInt("TimeStart", timeStart ? 1 : 0);
        PlayerPrefs.Save();
        ConfigurableParameters.coinAll = PlayerPrefs.GetInt("CoinsAll") + 50;
        PlayerPrefs.SetInt("CoinsAll", ConfigurableParameters.coinAll);
        PlayerPrefs.Save();
    }
    private void Update()
    {
        if (timeStart)
        {
            if (ts <= DateTime.Now)
            {
                PlayerPrefs.DeleteKey("TimeStart");
                timetext.text = "Ads";
                timeStart = false;
                gameObject.GetComponent<Button>().interactable = true;
            }
            else
            {
                gameObject.GetComponent<Button>().interactable = false;
                CheckOffline();
            }
        }
    }

    private void CheckOffline()
    {
        tss = ts - DateTime.Now;
        timetext.text = string.Format("{0}:{1}:{2}", tss.Hours, tss.Minutes, tss.Seconds);
        PlayerPrefs.SetString("LastSession", ts.ToString());
        PlayerPrefs.Save();
    }
    private void OnDisable()
    {
        feecoinTime -= OnClick;
        feecoinTime -= CheckOffline;
    }
    private void OnApplicationQuit()
    {
        CheckOffline();
    }
    private void OnApplicationPause(bool pause)
    {
        CheckOffline();
    }

}

