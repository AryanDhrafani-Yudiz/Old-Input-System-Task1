using System.Collections;
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
    [SerializeField] private float duration;

    void Awake()
    {
        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;
    }
    void Start()
    {
        transform.position = new Vector3(0, 0.5f, 0);
        currPosition = transform.position;
    }
    void Update()
    {
        //if (UImanagerscript.gameplayscreen)
        //{
        if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    Debug.Log("Touch Begin");
                    Vector2 pos = touch.position;
                    pos.x = (pos.x - width) / width;
                    pos.y = (pos.y - height) / height;
                    position1 = new Vector3(pos.x, 0.0f, pos.y);
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    Debug.Log("Touch Ended");
                    Vector2 pos = touch.position;
                    pos.x = (pos.x - width) / width;
                    pos.y = (pos.y - height) / height;
                    position2 = new Vector3(pos.x, 0.0f, pos.y);
                    diff = (position2 - position1);
                    currPosition=transform.position;
                    StartCoroutine(MoveCube(currPosition+diff, duration));
                }
            }
        //}
    }
    
    IEnumerator MoveCube(Vector3 endPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = currPosition;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = endPosition;
        currPosition = endPosition;
    }
}
