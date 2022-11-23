using UnityEngine;
using UnityEngine.UI;
namespace Trainings
{
    public class Translate : MonoBehaviour
    {
        public static string language;
        private Image Flag;
        public Sprite[] Flags;
        public Text Text;

        public static int i;
        private void Awake()
        {
            Flag = gameObject.GetComponent<Image>();
        }
        private void Start()
        {
            if (PlayerPrefs.HasKey("number"))
            {
                i = PlayerPrefs.GetInt("number");
                language = PlayerPrefs.GetString("language");
                Flag.sprite = Flags[PlayerPrefs.GetInt("number")];
                Text.text = PlayerPrefs.GetString("text");
            }
            else
            {
                i = 0;
                language = "Eng";
                Flag.sprite = Flags[i];
                Text.text = "Restart training";
            }
        }
        public void LanguageChange()
        {
            i++;
            if (i == 0)
            {
                language = "Eng";
                Flag.sprite = Flags[i];
                Text.text = "Restart training";

            }
            else if (i == 1)
            {
                language = "DE";
                Flag.sprite = Flags[i];
                Text.text = "Neu lernen";
            }
            else if (i == 2)
            {
                language = "Ru";
                Flag.sprite = Flags[i];
                Text.text = "Заново обучиться";
            }
            else if (i == 3)
            {
                language = "ZH";
                Flag.sprite = Flags[i];
                Text.text = "重新学习";
            }
            else
            {
                i = 0;
                language = "Eng";
                Flag.sprite = Flags[i];
                Text.text = "Restart training";

            }
            PlayerPrefs.SetInt("number", i);
            PlayerPrefs.SetString("language", language);
            PlayerPrefs.SetString("text", Text.text);
            PlayerPrefs.Save();
        }

        }
    }
