using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float xOffset;
    [SerializeField] private float yOffset;
    [SerializeField] private float zOffset;

    void Start()
    {
        transform.position = new Vector3(playerTransform.position.x + xOffset, playerTransform.position.y + yOffset, playerTransform.position.z + zOffset);
    }
    void Update()
    {
        transform.position = new Vector3(playerTransform.position.x + xOffset, playerTransform.position.y + yOffset, playerTransform.position.z + zOffset);
    }
}
