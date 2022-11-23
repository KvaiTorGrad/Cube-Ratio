using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Trainings
{
    public class PowerStone : MonoBehaviour
    {
       public static PowerStone powSt = new PowerStone();
        [SerializeField] private ParticleSystem[] parkUltra;
        private float timeRecharge;
        private SpriteRenderer Eays;
        [HideInInspector] public GameObject Player, powerEnd;
        [SerializeField] private Button but;
        private bool startPower;

       public static List<Collider2D> listTartgetPlus = new List<Collider2D>();
       [SerializeField] private Transform[] TargetSuper;
        
        public delegate void StartPowerStone(float power);
        public static event StartPowerStone StartPS;
        private void Awake()
        {
            Eays = gameObject.GetComponent<SpriteRenderer>();
        }
        void Start()
        {
            timeRecharge = 0;
            StartPS += StonePowerStart;
        }
        private void Update()
        {
            but.transform.position = Player.transform.position;
            if (ConfigurableParameters.play)
            {
                timeRecharge += Time.deltaTime;
                Eays.color = Color.Lerp(new Color(255f, 255f, 255f), new Color(255f, 0f, 74f), timeRecharge / 30);
            }
            if (startPower)
            {
                PowerKick();
            }
            
        }
        public void StonePowerStart(float a)
        {
            if (timeRecharge >= a)
            {
                StartCoroutine(StartPower());
            }
        }
        private IEnumerator StartPower()
        {
            Vector2 explosionPos = Player.transform.position;
            Collider2D[] colliders2D = Physics2D.OverlapCircleAll(explosionPos, 100f);

            foreach (Collider2D hit in colliders2D)
            {
                if (hit != null && hit.CompareTag("SuperPoint"))
                {
                    listTartgetPlus.Add(hit);
                }
            }
            yield return null;
            parkUltra[0].Pause();
            parkUltra[1].Play();
            Player.GetComponent<BoxCollider2D>().isTrigger = true;
            startPower = true;
            yield return new WaitForSeconds(0.5f);
            Player.GetComponent<BoxCollider2D>().isTrigger = false;
            parkUltra[1].Pause();
            parkUltra[0].Play();
            timeRecharge = 0;
            ConfigurableParameters.collision = false;
            startPower = false;
            listTartgetPlus.RemoveRange(0,listTartgetPlus.Count);

        }
        private void PowerKick()
        {
            for(int i = 0; i< listTartgetPlus.Count;i++)
            Player.transform.position = Vector2.MoveTowards(Player.transform.position, listTartgetPlus[i].transform.position, 10f);
        }
        private void OnDisable()
        {
            StartPS -= StonePowerStart;
        }
    }
}