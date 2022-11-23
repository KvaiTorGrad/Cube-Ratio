using System.Collections;
using UnityEngine;
namespace Trainings
{
    public class FailDel : MonoBehaviour
    {
        UiMenu uimenu;

        public static bool PLayOnWings, PLCuratinWings, PlayOnX2, PlayOnX2Curat;

        public delegate void Live(bool live);
        public static event Live Lives;

        private int ToolDead;

        private void Awake()
        {
            uimenu = FindObjectOfType<UiMenu>();
            Lives += OnTwoLive;
        }
        private void Start()
        {
            if (PlayerPrefs.HasKey("ToolDead"))
                ToolDead = PlayerPrefs.GetInt("ToolDead");
            else
                ToolDead = 0;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                OnTwoLive(PLayOnWings);
            }
        }

        private void OnTwoLive(bool go)
        {
            if (Lives != null)
            {
                if (go)
                    PLCuratinWings = true;
                else
                    StartCoroutine(Relaod());
            }
        }
        IEnumerator Relaod()
        {
            PLCuratinWings = false;
            yield return null;
            if (PlayerPrefs.HasKey("ads"))
            {
            }
            else
            {
                ToolDead++;
                PlayerPrefs.SetInt("ToolDead", ToolDead);
                PlayerPrefs.Save();
                //ads
            }
            uimenu.LossPanelButton();
        }
    }


}