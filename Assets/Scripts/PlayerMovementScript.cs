using UnityEngine;

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

    void Awake()
    {
        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;
    }
    void Start()
    {
        Application.targetFrameRate = 120;   
        transform.position = new Vector3(0, 0.5f, 0);
        currPosition = transform.position;

        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.orientation = ScreenOrientation.AutoRotation;
    }
    void Update()
    {
        if (UImanagerscript.gameplayscreen)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 pos = Input.mousePosition;
                pos.x = (pos.x - width) / width;
                pos.y = (pos.y - height) / height;
                position1 = new Vector3(pos.x, 0.0f, pos.y);
            }
            else if (Input.GetMouseButton(0))
            {
                Vector2 pos = Input.mousePosition;
                pos.x = (pos.x - width) / width;
                pos.y = (pos.y - height) / height;
                position2 = new Vector3(pos.x, 0.0f, pos.y);
                diff = (position2 - position1);
                currPosition = transform.position;
                endPosition = currPosition + diff;
                transform.LookAt(endPosition);
                transform.position = Vector3.MoveTowards(currPosition, endPosition, speed * Time.deltaTime);
            }
        }
    }
}
