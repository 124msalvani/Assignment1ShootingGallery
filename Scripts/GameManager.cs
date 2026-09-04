/********************************************************************************************/
/*  File: GameManager.cs
/*  Author:  Maggie Salvani
/*  Major:   Game Development
/*  Creation Date:   9/2/26
/*  Last Modified:   9/4/26
/*  Section: CPSC320 
/*  Professor Name:  Prof. Jacklitsch
/*  Assignment: Assignment 1
/*  Purpose:		Demonstrate your understanding of Godot by creating a simple shooting gallery game.
/********************************************************************************************/
using Godot;
using System;

public partial class GameManager : Node
{

    [Export] //relying on exports can make code tangled!!!
    private TimerBar _timerBar;

    [Export] //relying on exports can make code tangled!!!
    private LoseScreen _gameOverScreen;

    [Export]
    private WinScreen _winScreen;

    
    private int targetsRemaining;


/* 
* Name: _Ready
* Description: On initialization, hides the gameOverScreen and winScreen, counts the remaining targets
*              in the scene, and starts the timer.
* Parameters: None
* Returns: None
*/
    public override void _Ready()
    {
        _gameOverScreen.Visible = false;
        _winScreen.Visible = false;

        //Google: Godot C# see how many items are in a group
        targetsRemaining = GetTree().GetNodesInGroup("target_group").Count; 
        _timerBar.StartTimer();
    }

/* 
* Name: _Process
* Description: Listens every frame for the targets remaining to be 0, or for the timer to run out, then stops
* Parameters: double deltaTime - time in seconds since prev frame
* Returns: None
*/
    public override void _Process(double delta)
    {
        targetsRemaining = GetTree().GetNodesInGroup("target_group").Count;
        if (targetsRemaining == 0)
        {
            ShowWinScreen();
            _timerBar.StopTimer();
            //Google: Checking every frame;
            GD.Print("Targets cleared");
            SetProcess(false);
        }

        if (_timerBar.HasTimedOut())
        {
            ShowLoseScreen();
            GD.Print("You lose");
            SetProcess(false);
        }
  
    }

/* 
* Name: ShowWinScreen
* Description: Makes WinScreen visible
* Parameters: None
* Returns: None
*/
    private void ShowWinScreen()
    {
        _winScreen.Visible = true;
    }
/* 
* Name: ShowLoseScreen
* Description: Makes LoseScreen visible
* Parameters: None
* Returns: None
*/
    private void ShowLoseScreen()
    {
        _gameOverScreen.Visible = true;
    }
}
