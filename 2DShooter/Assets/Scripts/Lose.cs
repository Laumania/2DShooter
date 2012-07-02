using UnityEngine;
using System.Collections;

public class Lose : MonoBehaviour 
{
    public Texture BackgroundTexture;

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), BackgroundTexture);

        if (Input.anyKeyDown)
        {
            Player.Score = 0;
            Player.Lives = 3;
            Player.Missed = 0;
            Application.LoadLevel("Level1");
        }
    }
}
