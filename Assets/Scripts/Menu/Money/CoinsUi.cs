using UnityEngine;
using UnityEngine.UI;
namespace Trainings
{
    public class CoinsUi : MonoBehaviour
    {
        public Text[] CoinsText;
        void Start()
        {
            Coins();
        }
        void Update()
        {
            Coins();
            CoinsGame(ConfigurableParameters.play);
        }
        private void Coins()
        {

                if (PlayerPrefs.GetString("language") == "Ru")
                {
                if (PlayerPrefs.HasKey("CoinsAll"))
                    CoinsText[0].text = $"Монеты: {PlayerPrefs.GetInt("CoinsAll")}";
                else
                    CoinsText[0].text = $"Монеты: {ConfigurableParameters.coinAll = 0}";
                }
                else if (PlayerPrefs.GetString("language") == "Eng")
                 {
                if (PlayerPrefs.HasKey("CoinsAll"))
                    CoinsText[0].text = $"Coins: {PlayerPrefs.GetInt("CoinsAll")}";
                else
                    CoinsText[0].text = $"Coins: {ConfigurableParameters.coinAll = 0}";
                 }
                else if (PlayerPrefs.GetString("language") == "DE")
                 {
                if (PlayerPrefs.HasKey("CoinsAll"))
                    CoinsText[0].text = $"Münzen: {PlayerPrefs.GetInt("CoinsAll")}";
                else
                    CoinsText[0].text = $"Münzen: {ConfigurableParameters.coinAll = 0}";
                 }
                else if (PlayerPrefs.GetString("language") == "ZH")
                 {
                if (PlayerPrefs.HasKey("CoinsAll"))
                    CoinsText[0].text = $"硬币: {PlayerPrefs.GetInt("CoinsAll")}";
                else
                    CoinsText[0].text = $"硬币: {ConfigurableParameters.coinAll = 0}";
                 }
        }

        private void CoinsGame(bool pl)
        {
            if (pl)
            {
                if (PlayerPrefs.GetString("language") == "Ru")
                    CoinsText[1].text = $"Собрано монет: {CoinsPlus.gamecoin}";
                else if(PlayerPrefs.GetString("language") == "Eng")
                    CoinsText[1].text = $"Collected coins: {CoinsPlus.gamecoin}";
                else if(PlayerPrefs.GetString("language") == "DE")
                    CoinsText[1].text = $"Münzen gesammelt: {CoinsPlus.gamecoin}";
                else if(PlayerPrefs.GetString("language") == "ZH")
                    CoinsText[1].text = $"收集硬币: {CoinsPlus.gamecoin}";

            }
        }
    }
}
