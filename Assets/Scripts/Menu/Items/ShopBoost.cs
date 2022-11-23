using UnityEngine;
using UnityEngine.UI;

public class ShopBoost : MonoBehaviour
{
    private int coinsPriceWings, coinsPriceX2, timeslow;
    public Text[] coinsPriceText;

    public static event WingsBuys Wingsbuy, X2Buy, TimeBuy;
    public delegate void WingsBuys(int buywings);
    private void Start()
    {
        coinsPriceWings = 1000;
        coinsPriceX2 = 1500;
        timeslow = 500;
        coinsPriceText[0].text = coinsPriceWings.ToString();
        coinsPriceText[1].text = coinsPriceX2.ToString();
        coinsPriceText[2].text = timeslow.ToString();
        Wingsbuy += WingsBuy;
        X2Buy += X2buy;
        TimeBuy += TimeBuyLot;
    }
    public void WingsBuy(int count)
    {
        count = 1;
        if (Wingsbuy != null)
        {
            if (PlayerPrefs.GetInt("CoinsAll") > coinsPriceWings)
            {
                ConfigurableParameters.BoostWingsLot = PlayerPrefs.GetInt("Wings") + count;
                ConfigurableParameters.coinAll = PlayerPrefs.GetInt("CoinsAll") - coinsPriceWings;
                PlayerPrefs.SetInt("CoinsAll", ConfigurableParameters.coinAll);
                PlayerPrefs.SetInt("Wings", ConfigurableParameters.BoostWingsLot);
                PlayerPrefs.Save();
            }
        }
    }
    public void X2buy(int count)
    {
        count = 1;
        if (X2Buy != null)
        {
            if (PlayerPrefs.GetInt("CoinsAll") > coinsPriceX2)
            {
                ConfigurableParameters.BoostX2Lot = PlayerPrefs.GetInt("x2") + count;
                ConfigurableParameters.coinAll = PlayerPrefs.GetInt("CoinsAll") - coinsPriceX2;
                PlayerPrefs.SetInt("CoinsAll", ConfigurableParameters.coinAll);
                PlayerPrefs.SetInt("x2", ConfigurableParameters.BoostX2Lot);
                PlayerPrefs.Save();
            }
        }
    }
    public void TimeBuyLot(int count)
    {
        count = 1;
        if (TimeBuy != null)
        {
            if (PlayerPrefs.GetInt("CoinsAll") > timeslow)
            {
                ConfigurableParameters.BoostTimeLot = PlayerPrefs.GetInt("Time") + count;
                ConfigurableParameters.coinAll = PlayerPrefs.GetInt("CoinsAll") - timeslow;
                PlayerPrefs.SetInt("CoinsAll", ConfigurableParameters.coinAll);
                PlayerPrefs.SetInt("Time", ConfigurableParameters.BoostTimeLot);
                PlayerPrefs.Save();
            }
        }
    }

    private void OnDisable()
    {
        Wingsbuy -= WingsBuy;
        X2Buy -= X2buy;
        TimeBuy -= TimeBuyLot;
    }
}
