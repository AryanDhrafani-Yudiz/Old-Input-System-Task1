using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
   
    void Start()
    {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + 1f, playerTransform.position.z - 5f);
    }
    void Update()
    {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + 1f, playerTransform.position.z - 5f);
    }
}
