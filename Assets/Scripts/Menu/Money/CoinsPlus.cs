using UnityEngine;

public class CoinsPlus : MonoBehaviour
{
    public static int gamecoin;

    private void Start()
    {
        gamecoin = 0;
        Coin.CoinPlusdels += CoinPlusdeldel;
    }
    private void CoinPlusdeldel(int cons)
    {
        gamecoin += cons;
        ConfigurableParameters.coinAll = PlayerPrefs.GetInt("CoinsAll") + cons;
    }
    private void OnDisable()
    {
        Coin.CoinPlusdels -= CoinPlusdeldel;
    }
}

