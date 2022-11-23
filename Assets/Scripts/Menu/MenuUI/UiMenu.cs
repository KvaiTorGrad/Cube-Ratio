using UnityEngine;
using UnityEngine.SceneManagement;
namespace Trainings
{
    public class UiMenu : MonoBehaviour
    {
        public GameObject MenuPanel, LossPanel, SocPanel, PlayCount;
        public GameObject[] SetPanel;
        public RectTransform SetPanelBackGround;
        public Canvas canvas;
        private bool SETactive, SOCactive;
        private void Awake()
        {
            canvas = gameObject.GetComponent<Canvas>();
            SetPanelBackGround = SetPanelBackGround.GetComponent<RectTransform>();
        }
        void Start()
        {
            canvas.sortingOrder = 105;
            MenuPanel.SetActive(true);
            LossPanel.SetActive(false);
            SetPanelBackGround.sizeDelta = new Vector2(55f, 50f);
            SocPanel.SetActive(false);
            PlayCount.SetActive(false);
            foreach (GameObject joint in SetPanel)
            {
                joint.gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            PausBlock(ConfigurableParameters.play);
        }
        public void StartButton()
        {
            MenuPanel.SetActive(false);
            canvas.sortingOrder = 0;
            if (PlayerPrefs.HasKey("TrainingStart"))
            {
                ConfigurableParameters.play = true;
                Time.timeScale = 1;
                ConfigurableParameters.trainingBool = PlayerPrefs.GetInt("TrainingStart") == 1 ? true : false;
            }
            else
            {
                ConfigurableParameters.trainingBool = false;
                StartCoroutine(Trainings.TrainingStart.TrainingIE);
            }
        }
        public void LossPanelButton()
        {
            ConfigurableParameters.play = false;
            LossPanel.SetActive(true);
            canvas.sortingOrder = 105;
            Time.timeScale = 0;
            PlayCount.SetActive(false);
        }
        public void BackMenu()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Start();
            ConfigurableParameters.res = true;

        }
        public void SettingMenu()
        {
            SETactive = !SETactive;
            if (SETactive)
            {
                SetPanelBackGround.sizeDelta = new Vector2(329f, 50f);
                foreach (GameObject joint in SetPanel)
                {
                    joint.gameObject.SetActive(true);
                }

            }
            else
            {
                SetPanelBackGround.sizeDelta = new Vector2(55f, 50f);
                foreach (GameObject joint in SetPanel)
                {
                    joint.gameObject.SetActive(false);
                }

            }
        }
        public void SocPanelBlock()
        {
            SOCactive = !SOCactive;
            if (SOCactive)
                SocPanel.SetActive(true);
            else
                SocPanel.SetActive(false);
        }
        public void ExitButton()
        {
            Application.Quit();
        }

        private void PausBlock(bool pl)
        {
            if (pl)
            {
                if (Input.touchCount > 1 && Input.touchCount < 3)
                {
                    LossPanelButton();
                    PlayCount.SetActive(true);
                }
            }
        }
        public void PlayCounty()
        {
            ConfigurableParameters.play = true;
            LossPanel.SetActive(false);
            canvas.sortingOrder = 0;
            if (PlayerPrefs.HasKey("timeSkale"))
                Time.timeScale = PlayerPrefs.GetFloat("timeSkale");
            else
                Time.timeScale = 1;
        }

        public void RestartTraining()
        {
            PlayerPrefs.DeleteKey("TrainingStart");
            ConfigurableParameters.trainingBool = false;
            Time.timeScale = 0;
        }
    }
}