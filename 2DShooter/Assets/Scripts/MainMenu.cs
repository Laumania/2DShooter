using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
    private string _instructionText = "Instructions:\nPress Left and Right arrows to move.\nPress Space to fire";
    private int _buttonWidth = 200;
    private int _buttonHeight = 50;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 250, 200), _instructionText);

        if (GUI.Button(new Rect(Screen.width / 2 - _buttonWidth / 2,
                            Screen.height / 2 - _buttonHeight / 2,
                            _buttonWidth,
                            _buttonHeight),
                            "Start"))
        {
            Application.LoadLevel("Level1");
        }
    }
}
