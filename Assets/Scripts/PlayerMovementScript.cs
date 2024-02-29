using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovementScript : MonoBehaviour
{
    private Vector3 position1;
    private Vector3 position2;
    private Vector3 diff;
    private float width;
    private float height;
    public UIManagerScript UImanagerscript;
    private Vector3 currPosition;
    private Vector3 endPosition;
    [SerializeField] private float speed;
    private float relativeSpeed;

    void Awake()
    {
        Application.targetFrameRate = 120;
    }
    void Start()
    {
        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;
        transform.position = new Vector3(0, 0.5f, 0);
        currPosition = transform.position;
        //Debug.Log(Screen.currentResolution.refreshRate);
    }
    void Update()
    {
        if (UImanagerscript.gameplayscreen)     // Move Only If GamePlayScreen Bool Is True
        {
            if(Input.mousePresent)
            {
                if (Input.GetMouseButtonDown(0))    // When First Clicked At A Point On Screen
                {
                    if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        Vector2 pos = Input.mousePosition;
                        JoystickStartingLocation(pos);
                    }
                }
                else if (Input.GetMouseButton(0))   // When The Joystick Is Being Moved
                {
                    if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        Vector2 pos = Input.mousePosition;
                        JoystickMovedToLocation(pos);
                    }
                }
            }
            else if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (!EventSystem.current.IsPointerOverGameObject(0))
                {
                    if (touch.phase == TouchPhase.Began)    // When First Clicked At A Point On Screen
                    {
                        Vector2 pos = touch.position;
                        JoystickStartingLocation(pos);
                    }
                    else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)   // When The Joystick Is Being Moved Or Is Stationary
                    {
                        Vector2 pos = touch.position;
                        JoystickMovedToLocation(pos);
                    }
                }               
            }
        }
    }
    void JoystickStartingLocation(Vector2 pos)
    {
        pos.x = (pos.x - width) / width;
        pos.y = (pos.y - height) / height;
        position1 = new Vector3(pos.x, 0.0f, pos.y);
    }
    void JoystickMovedToLocation(Vector2 pos)
    {
        pos.x = (pos.x - width) / width;
        pos.y = (pos.y - height) / height;
        position2 = new Vector3(pos.x, 0.0f, pos.y);
        diff = (position2 - position1);                           // Difference In Vector3
        relativeSpeed = Mathf.Clamp(diff.magnitude, 0.3f, 0.7f);  // Clamps The Magnitude Of Difference (Float Value Of Difference) Between Required Min,Max Values
        currPosition = transform.position;
        endPosition = currPosition + diff;
        transform.LookAt(endPosition);                            // Cube Looks Towards The Desired Area According To Movement Of Joystick
        transform.position = Vector3.MoveTowards(currPosition, endPosition, speed * relativeSpeed * Time.deltaTime);    // For Actual Movement Of Cube
    }
}