/********************************************************************************************/
/*  File: GameManager.cs
/*  Author:  Maggie Salvani
/*  Major:   Game Development
/*  Creation Date:   8/31/26
/*  Last Modified:   9/4/26
/*  Section: CPSC320 
/*  Professor Name:  Prof. Jacklitsch
/*  Assignment: Assignment 1
/*  Purpose:		Demonstrate your understanding of Godot by creating a simple shooting gallery game.
/********************************************************************************************/

/********************************************************************************************/
/*  File: TimerBar.cs
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

//Google Godot C# Timer
public partial class TimerBar : Control
{
    [Export]
    //Export: you can assign the thing you exported in Godot
    private Label _timerBarLabel;
    [Export]
    private Timer _timer;

    //Boolean to let GameManager know if time is up
    private bool _isTimedOut = false;


 /* 
* Name: _Ready
* Description: On initialization, connects the timer's timeout to its handler
* Parameters: None
* Returns: None
*/
    public override void _Ready()
    {
        _timer.Timeout += OnTimerTimout;
    }

/* 
* Name: StartTimer
* Description: Starts countdown timer, sets isTimedOut flag to false
* Parameters: None
* Returns: None
*/
    public void StartTimer()
    {
        _isTimedOut = false;
        _timer.Start();
    }

/* 
* Name: _Process
* Description: Updates UI to display time left every frame
* Parameters: double deltaTime - time in seconds since prev frame
* Returns: None
*/
    public override void _Process(double delta)
    {
        //Google: How to format Godot Timer C#
        double _timeLeft = _timer.TimeLeft;
        int minutes = (int)(_timeLeft / 60);
        int seconds = (int)(_timeLeft % 60);

        _timerBarLabel.Text = "Time Left:" + $"{minutes:D2}:{seconds:D2}";
        
    }

/* 
* Name: HasTimedOut
* Description: Returns true if the timer's time is up
* Parameters: None
* Returns: bool _isTimedOut
*/
    public bool HasTimedOut()
    {
        return _isTimedOut;
    }
/* 
* Name: StopTimer
* Description: Stops the timer
* Parameters: None
* Returns: None
*/
    public void StopTimer()
    {
        _timer.Stop();
    }
/* 
* Name: OnTimerTimeout
* Description: Stops the timer, sets timer label to 0:00, sets isTimedOut bool to true
* Parameters: None
* Returns: None
*/
    public void OnTimerTimout()
    {
        _timer.Stop();
        _timerBarLabel.Text = "0:00";
        _isTimedOut = true;
    }
}
