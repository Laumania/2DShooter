using UnityEngine;
using System.Collections;

public class Lose : MonoBehaviour 
{
    private int _buttonWidth = 200;
    private int _buttonHeight = 50;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - _buttonWidth / 2,
                            Screen.height / 2 - _buttonHeight / 2,
                            _buttonWidth,
                            _buttonHeight),
                            "Game Over\nPress to play"))
        {
            Player.Score = 0;
            Player.Lives = 3;
            Player.Missed = 0;
            Application.LoadLevel("Level1");
        }
    }
}
