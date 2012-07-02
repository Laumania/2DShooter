using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
    public Texture BackgroundTexture;

    private string _instructionText = "Instructions:\nPress Left and Right arrows to move.\nPress Space to fire";

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), BackgroundTexture);

        GUI.Label(new Rect(10, 10, 250, 200), _instructionText);

        if(Input.anyKeyDown)
        {
            Application.LoadLevel("Level1");
        }
    }
}
