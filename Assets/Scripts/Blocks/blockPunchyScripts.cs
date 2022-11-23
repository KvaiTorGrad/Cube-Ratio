using UnityEngine;
public class blockPunchyScripts : MonoBehaviour
{
    private int kick;
    public Sprite blockState;
    private void Start()
    {
        kick = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            kick++;
            if (kick == 1)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = blockState;
                ConfigurableParameters.collision = false;
                gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            kick++;
            if (kick == 2)
            {
                ConfigurableParameters.collision = false;
                gameObject.SetActive(false);
            }
        }
    }
}
