using UnityEngine;
using System.Collections;

public class Fps : MonoBehaviour
{
    private float count;
    private WaitForSeconds countWait;

    private IEnumerator Start()
    {
        countWait = new WaitForSeconds(0.1f);
        GUI.depth = 2;
        while (true)
        {
            count = 1f / Time.unscaledDeltaTime;
            yield return countWait;
        }
    }

    private void OnGUI()
    {
        Rect location = new Rect(100, 40, 200, 45);
        string text = $"  FPS: {Mathf.Round(count)}";
        Texture black = Texture2D.linearGrayTexture;
        GUI.DrawTexture(location, black, ScaleMode.StretchToFill);
        GUI.color = Color.black;
        GUI.skin.label.fontSize = 40;
        GUI.Label(location, text);
    }
}