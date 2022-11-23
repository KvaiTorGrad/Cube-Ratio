using UnityEngine;

public class Coin : MonoBehaviour
{
    private int coin;

    public delegate void CoinPlusdel(int coins);
    public static event CoinPlusdel CoinPlusdels;

    private void Update()
    {
        if (ConfigurableParameters.coinsX2)
            coin = 2;
        else
            coin = 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (PlayerPrefs.HasKey("CoinsAll"))
            {
                if (Coin.CoinPlusdels != null)
                {
                    CoinPlusdels(coin);
                }
            }
            PlayerPrefs.SetInt("CoinsAll", ConfigurableParameters.coinAll);
            PlayerPrefs.Save();
            gameObject.SetActive(false);
        }
    }

}
