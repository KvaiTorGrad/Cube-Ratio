using UnityEngine;
namespace Trainings
{
    public class ColliderUpDown : MonoBehaviour
    {
        private PlatformCreat plcam;

        private void Awake()
        {
            plcam = FindObjectOfType<PlatformCreat>();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
                if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Untagged") )
                    plcam.Camera.transform.position = new Vector3(plcam.Camera.transform.position.x, plcam.Camera.transform.position.y - 10f, plcam.Camera.transform.position.z);
            gameObject.SetActive(false);
        }
    }
}