using System;
using UnityEngine;
using UnityEngine.UI;
namespace Trainings
{
    public class ScorePlus : MonoBehaviour
    {
        public Text[] ScoreUi;
        private float scoreGame;
        private float time;

        public static event Scoredel ScoreEvs;
        public delegate void Scoredel(float scoredel);
        void Start()
        {
            scoreGame = 0;
            ScoreAll();
            ScoreEvs += ScoreinGame;
        }

        void FixedUpdate()
        {
            ScoreAll();
            ScoreinGame(1);
        }

        private void ScoreAll()
        {
            if (PlayerPrefs.GetString("language") == "Ru")
            {
                if (PlayerPrefs.HasKey("score"))
                    ScoreUi[0].text = $"Очки: {PlayerPrefs.GetFloat("score")}";
                else
                    ScoreUi[0].text = $"Очки: {ConfigurableParameters.scoreText = 0}";

                ScoreUi[1].text = $"Набрано очков: {Math.Round(scoreGame)}";
            }
            else if (PlayerPrefs.GetString("language") == "Eng")
            {
                if (PlayerPrefs.HasKey("score"))
                    ScoreUi[0].text = $"Score: {PlayerPrefs.GetFloat("score")}";
                else
                    ScoreUi[0].text = $"Score: {ConfigurableParameters.scoreText = 0}";

                ScoreUi[1].text = $"Points scored: {Math.Round(scoreGame)}";
            }
            else if (PlayerPrefs.GetString("language") == "DE")
            {
                if (PlayerPrefs.HasKey("score"))
                    ScoreUi[0].text = $"Brille: {PlayerPrefs.GetFloat("score")}";
                else
                    ScoreUi[0].text = $"Brille: {ConfigurableParameters.scoreText = 0}";

                ScoreUi[1].text = $"Punkte gesammelt: {Math.Round(scoreGame)}";
            }
            else if (PlayerPrefs.GetString("language") == "ZH")
            {
                if (PlayerPrefs.HasKey("score"))
                    ScoreUi[0].text = $"眼镜: {PlayerPrefs.GetFloat("score")}";
                else
                    ScoreUi[0].text = $"眼镜: {ConfigurableParameters.scoreText = 0}";

                ScoreUi[1].text = $"得分: {Math.Round(scoreGame)}";
            }
        }
        private void ScoreinGame(float scoreG)
        {
            if (ScoreEvs != null)
            {
                if (ConfigurableParameters.play)
                {
                    time = scoreG;
                    scoreGame += time * Time.deltaTime;
                    ConfigurableParameters.scoreText = Mathf.Round(scoreGame);
                    if (scoreGame > PlayerPrefs.GetFloat("score"))
                    {
                        PlayerPrefs.SetFloat("score", ConfigurableParameters.scoreText);
                    }
                    PlayerPrefs.Save();
                }
            }
        }
        private void OnDisable()
        {
            ScoreEvs -= ScoreinGame;
        }
    }
}