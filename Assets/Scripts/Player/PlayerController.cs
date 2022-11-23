using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [HideInInspector] public static Vector2 movement;
    public Rigidbody2D playeres;
    public static Animator anim;
    public Animator Eya;
    private void Awake()
    {
        playeres = GetComponent<Rigidbody2D>();
        anim = Eya.GetComponent<Animator>();
    }
    void Start()
    {
        gameObject.transform.position = new Vector2(0.39f, -3.53f);
        SwipeTouch.SwipeEvent += OnSwipe;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && ConfigurableParameters.collision == false)
        {
            Move(Vector2.left);
            anim.SetBool("Left", true);
            ConfigurableParameters.collision = true;
        }
        else if (Input.GetKey(KeyCode.R) && ConfigurableParameters.collision == false)
        {
            Move(Vector2.right);
            anim.SetBool("Right", true);
            ConfigurableParameters.collision = true;
        }
        else if (Input.GetKey(KeyCode.W) && ConfigurableParameters.collision == false)
        {
            Move(Vector2.up);
            anim.SetBool("Up", true);
            ConfigurableParameters.collision = true;
        }
        else if (Input.GetKey(KeyCode.S) && ConfigurableParameters.collision == false)
        {
            Move(Vector2.down);
            anim.SetBool("Down", true);
            ConfigurableParameters.collision = true;
        }
    }
    private void Move(Vector2 direction)
    {
        movement = new Vector2(ConfigurableParameters.speed * Time.deltaTime, ConfigurableParameters.speed * Time.deltaTime);
        movement = transform.TransformDirection(movement);
        playeres.AddForce(direction * movement);
        gameObject.GetComponentInChildren<ParticleSystem>().Play();
        ConfigurableParameters.timeIdle = 0;
    }
    private void OnSwipe(Vector2 direction)
    {
        if (ConfigurableParameters.play)
        {
            if (ConfigurableParameters.collision == false)
            {
                Vector2 dir = direction;
                Move(dir);
                ConfigurableParameters.collision = true;
            }
        }
    }
    private void FixedUpdate()
    {
        ConfigurableParameters.timeIdle++;
        if (ConfigurableParameters.timeIdle >= 100)
        {
            anim.SetBool("timeIdle", true);
        }
        else
        {
            anim.SetBool("timeIdle", false);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Polyline"))
        {
            Ondeleg();
            collision.gameObject.GetComponentInChildren<ParticleSystem>().Play();
        }
        else if (collision.gameObject.CompareTag("Wall"))
            Ondeleg();
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Polyline"))
        {
            OndelegTwo();
            collision.gameObject.GetComponentInChildren<ParticleSystem>().Play();
        }
        else if (collision.gameObject.CompareTag("Wall"))
            OndelegTwo();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SuperPoint"))
            collision.gameObject.SetActive(false);
    }
    private void Ondeleg()
    {
        ConfigurableParameters.collision = false;
        AnimaOff();
        gameObject.GetComponentInChildren<ParticleSystem>().Stop();
    }
    private void OndelegTwo()
    {
        ConfigurableParameters.collision = true;
    }

    public static void AnimaOff()
    {
        anim.SetBool("Left", false);
        anim.SetBool("Down", false);
        anim.SetBool("Up", false);
        anim.SetBool("Right", false);
    }
    private void OnDisable()
    {
        SwipeTouch.SwipeEvent -= OnSwipe;
    }
}

