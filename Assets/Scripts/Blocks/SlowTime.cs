using System.Collections;
using UnityEngine;
public class SlowTime : MonoBehaviour
{
    public delegate void SlowTimer(Collider2D coll);
    public static event SlowTimer SlowTimers;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SlowTimers += OnTriggerEnter2D;
            StartCoroutine(Time());
        }
    }
    private IEnumerator Time()
    {
        ConfigurableParameters.noCamGo = true;
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = -5;
        yield return new WaitForSeconds(1.5f);
        ConfigurableParameters.noCamGo = false;
        gameObject.SetActive(false);

    }
    private void OnDisable()
    {
        SlowTimers -= OnTriggerEnter2D;
    }
}
