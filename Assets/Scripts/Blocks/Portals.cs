using UnityEngine;
public class Portals : MonoBehaviour
{
    public Transform[] Portal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = Portal[1].transform.position;
            collision.gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(Portal[1].transform.forward * PlayerController.movement);
        }
    }

}
