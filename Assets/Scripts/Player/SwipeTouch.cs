using UnityEngine;

public class SwipeTouch : MonoBehaviour
{
    public delegate void OnSwipeInput(Vector2 direction);
    public static event OnSwipeInput SwipeEvent;
    private Vector2 tapPosition;
    private Vector2 swipeDelta;
    private float deadZone = 5;
    private bool isSwaiping;
    private bool isMobile;

    void Start()
    {
        isMobile = Application.isMobilePlatform;
    }
    void Update()
    {
        if (!isMobile)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isSwaiping = true;
                tapPosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                ResetSwipe();
            }
        }
        else
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    isSwaiping = true;
                    tapPosition = Input.GetTouch(0).position;
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Canceled || Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    ResetSwipe();
                }
            }
        }

        CheckSwipe();
    }
    private void CheckSwipe()
    {
        swipeDelta = Vector2.zero;
        if (isSwaiping)
        {
            if (!isMobile && Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - tapPosition;
            }
            else if (Input.touchCount > 0)
            {
                swipeDelta = Input.GetTouch(0).position - tapPosition;
            }
        }
        if (swipeDelta.magnitude > deadZone)
        {
            if (SwipeEvent != null)
            {
                if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
                {
                    SwipeEvent.Invoke(swipeDelta.x > 0 ? Vector2.right : Vector2.left);
                    if (swipeDelta.x > 0)
                        PlayerController.anim.SetBool("Right", true);
                    else
                        PlayerController.anim.SetBool("Left", true);
                }
                else
                {
                    SwipeEvent.Invoke(swipeDelta.y > 0 ? Vector2.up : Vector2.down);
                    if (swipeDelta.y > 0)
                        PlayerController.anim.SetBool("Up", true);
                    else
                        PlayerController.anim.SetBool("Down", true);
                }
            }
            ResetSwipe();
        }
    }
    private void ResetSwipe()
    {
        isSwaiping = false;
        tapPosition = Vector2.zero;
        swipeDelta = Vector2.zero;
    }

}
