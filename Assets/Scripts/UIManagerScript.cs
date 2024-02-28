using UnityEngine;

public class UIManagerScript : MonoBehaviour
{
    [SerializeField] private Canvas HomeScreenCanvas;
    [SerializeField] private Canvas GamePlayCanvas;
    [SerializeField] private Canvas PauseCanvas;
    public bool gameplayscreen=false;
    public Transform playerTransform;

    void Start()
    {
        HomeScreenCanvas.enabled = true;
        GamePlayCanvas.enabled = false;
        PauseCanvas.enabled = false;
    }
    public void GamePlayScreen()
    {
        gameplayscreen = true;
        GamePlayCanvas.enabled = true;
        HomeScreenCanvas.enabled = false;
    }
    public void HomeScreen()
    {
        gameplayscreen = false;
        GamePlayCanvas.enabled = false;
        HomeScreenCanvas.enabled = true;
        PauseCanvas.enabled = false;
        playerTransform.position = new Vector3(0,0.5f,0);
        playerTransform.rotation = Quaternion.identity;
    }
    public void OnPause()
    {
        gameplayscreen = false;
        GamePlayCanvas.enabled = false;
        PauseCanvas.enabled = true;
    }
    public void OnResume()
    {
        gameplayscreen = true;
        GamePlayCanvas.enabled = true;
        PauseCanvas.enabled = false;
    }
}
