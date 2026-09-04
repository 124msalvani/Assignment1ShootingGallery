/********************************************************************************************/
/*  File: LoseScreen.cs
/*  Author:  Maggie Salvani
/*  Major:   Game Development
/*  Creation Date:   8/31/26
/*  Last Modified:   9/4/26
/*  Section: CPSC320 
/*  Professor Name:  Prof. Jacklitsch
/*  Assignment: Assignment 1
/*  Purpose:		Demonstrate your understanding of Godot by creating a simple shooting gallery game.
/********************************************************************************************/


using Godot;
using System;

public partial class LoseScreen : Control
{
    [Export]
    private Button _quitButton;

    [Export]
    private Button _switchButton;

/* 
* Name: _Ready
* Description: On initialization, connects the buttons to their functions
* Parameters: None
* Returns: None
*/
    public override void _Ready()
    {
        _quitButton.Pressed += ExitGame;
        _switchButton.Pressed += ReturnToMainMenu;
        //When the button is pressed, sends a signal to exitgame
    }
    
/* 
* Name: ReturnToMainMenu
* Description: Changes the scene to the start menu
* Parameters: None
* Returns: None
*/
    public void ReturnToMainMenu()
    {
        GetTree().ChangeSceneToFile("res://Scenes/start.tscn");
    }
/* 
* Name: ExitGame
* Description: Closes the game
* Parameters: None
* Returns: None
*/
    public void ExitGame()
    {
        GetTree().Quit();
    }
}
