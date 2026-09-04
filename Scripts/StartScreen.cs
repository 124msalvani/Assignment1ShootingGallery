/********************************************************************************************/
/*  File: StartScreen.cs
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

public partial class StartScreen : Control
{
    //Google Godot C# How to switch scenes

    [Export]
    private Button _startButton;

/* 
* Name: _Ready
* Description: On initialization, connects start button to the SwitchToNextScene function
* Parameters: None
* Returns: None
*/
    public override void _Ready()
    {
        _startButton.Pressed += SwitchToNextScene;
    }
/* 
* Name: SwitchToNextScene
* Description: Changes the scene to the main scene
* Parameters: None
* Returns: None
*/
    public void SwitchToNextScene()
    {
        // Automatically frees the current scene and loads the new one
        GetTree().ChangeSceneToFile("res://Scenes/main_scene.tscn");

    }

}
