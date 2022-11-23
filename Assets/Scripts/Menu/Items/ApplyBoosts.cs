using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Trainings
{
    public class ApplyBoosts : MonoBehaviour
    {
        
        public Toggle[] BoostApply;
        private bool OnisWings;
        public static List<Collider2D> listTartgetTwoLife = new List<Collider2D>();

        public delegate void BoostX2andTimeSlow(bool X2andTimeSlow);
        public static event BoostX2andTimeSlow BoostX2andTimeSlows;

        private void Awake()
        {
            Trainings.PowerStone.powSt = FindObjectOfType<PowerStone>();
        }
        void Start()
        {
            ConfigurableParameters.coinsX2 = false;
            ConfigurableParameters.ScaleTime = false;
            OnisWings = false;
            FailDel.Lives += WingsPlay;
            BoostX2andTimeSlows += X2;
            BoostX2andTimeSlows += TimeSlow;
        }
        void Update()
        {
            WingsPlay(OnisWings);
        }
        #region Wings
        public void Wings(bool On)
        {
            if (PlayerPrefs.GetInt("Wings") > 0)
            {
                if (BoostApply[0].isOn)
                {
                    BoostApply[0].GetComponent<Image>().color = Color.green;
                    OnisWings = true;
                    FailDel.PLayOnWings = OnisWings;
                    ConfigurableParameters.BoostWingsLot = PlayerPrefs.GetInt("Wings") - 1;
                }
                else
                {
                    BoostApply[0].GetComponent<Image>().color = Color.white;
                    ConfigurableParameters.BoostWingsLot = PlayerPrefs.GetInt("Wings") + 1;
                    OnisWings = false;
                    FailDel.PLayOnWings = OnisWings;
                }
                PlayerPrefs.SetInt("Wings", ConfigurableParameters.BoostWingsLot);
                PlayerPrefs.Save();
            }
        }
        private void WingsPlay(bool onplay)
        {
            if (onplay)
            {
                if (FailDel.PLCuratinWings)
                    StartCoroutine(TwoLive());
               
            }
        }
        private IEnumerator TwoLive()
        {
            Vector2 explosionPos = Trainings.PowerStone.powSt.Player.transform.position;
            Collider2D[] colliders2D = Physics2D.OverlapCircleAll(explosionPos, 100f);
            Trainings.PowerStone.powSt.Player.GetComponent<Rigidbody2D>().velocity = Trainings.PowerStone.powSt.Player.GetComponent<Rigidbody2D>().velocity * 0 * Time.deltaTime;
            foreach (Collider2D hit in colliders2D)
            {
                if (hit != null && hit.CompareTag("SuperPoint"))
                {
                    listTartgetTwoLife.Add(hit);
                }
            }
            for (int i = 0; i < listTartgetTwoLife.Count; i++)
            {
                Trainings.PowerStone.powSt.Player.tag = "Untagged";
                Trainings.PowerStone.powSt.Player.transform.position = listTartgetTwoLife[i].transform.position;


                listTartgetTwoLife.RemoveRange(0, listTartgetTwoLife.Count);
            }
           
            PlayerController.AnimaOff();
            ConfigurableParameters.collision = false;
            FailDel.PLayOnWings = false;
            OnisWings = false;
            Trainings.PowerStone.powSt.Player.tag = "Player";
            yield return null;
        }
        #endregion

        #region X2
        public void X2(bool On)
        {
            if (BoostX2andTimeSlows != null)
            {
                if (PlayerPrefs.GetInt("x2") > 0)
                {
                    if (BoostApply[1].isOn)
                    {
                        BoostApply[1].GetComponent<Text>().color = Color.green;
                        ConfigurableParameters.BoostX2Lot = PlayerPrefs.GetInt("x2") - 1;
                        StartCoroutine(X2CUR());
                    }
                    else
                    {
                        BoostApply[1].GetComponent<Text>().color = Color.white;
                        ConfigurableParameters.BoostX2Lot = PlayerPrefs.GetInt("x2") + 1;
                        StopCoroutine(X2CUR());
                    }
                    PlayerPrefs.SetInt("x2", ConfigurableParameters.BoostX2Lot);
                    PlayerPrefs.Save();
                }
            }
        }
        private IEnumerator X2CUR()
        {
            yield return null;
            ConfigurableParameters.coinsX2 = true;
        }
        #endregion

        #region TimeSlow
        public void TimeSlow(bool On)
        {
            if (BoostX2andTimeSlows != null)
            {
                if (PlayerPrefs.GetInt("Time") > 0)
                {
                    if (BoostApply[2].isOn)
                    {
                        BoostApply[2].GetComponent<Image>().color = Color.green;
                        StartCoroutine(TimeSlowCor());
                        ConfigurableParameters.ScaleTime = true;
                        ConfigurableParameters.BoostTimeLot = PlayerPrefs.GetInt("Time") - 1;
                    }
                    else
                    {
                        BoostApply[2].GetComponent<Image>().color = Color.white;
                        ConfigurableParameters.ScaleTime = false;
                        ConfigurableParameters.BoostTimeLot = PlayerPrefs.GetInt("Time") + 1;
                    }
                    PlayerPrefs.SetInt("Time", ConfigurableParameters.BoostTimeLot);
                    PlayerPrefs.Save();
                }
            }
        }
        private IEnumerator TimeSlowCor()
        {
            yield return null;
            ConfigurableParameters.ScaleTime = true;
        }

        #endregion
        private void OnDisable()
        {
            FailDel.Lives -= WingsPlay;
            BoostX2andTimeSlows -= X2;
            BoostX2andTimeSlows -= TimeSlow;
        }
    }
}