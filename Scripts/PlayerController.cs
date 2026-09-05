/********************************************************************************************/
/*  File: PlayerController.cs
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

//Most code reused from Shootio Project
public partial class PlayerController : CharacterBody2D
{
    public const float UnitsPerMeter = 200; //something you do in preproduction
    private float _movementSpeed = 5;
    public float _bulletSpeed = 10;

/* 
* Name: _Process
* Description: Listens every frame for shoot input action to instantiate a new SimpleBullet
* Parameters: double deltaTime - time in seconds since prev frame
* Returns: None
*/
    public override void _Process(double deltaTime)
    {
        if (Input.IsActionJustPressed("ShootGun")) {

            Vector2 spawnLocation = this.GetNode<Node2D>("MuzzlePosition").GlobalPosition;

            Vector2 direction = Vector2.Right.Rotated(Rotation);

            Vector2 bulletVelocity = direction * UnitsPerMeter * _bulletSpeed;
            
            Node2D newBullet = SimpleBullet.InitalizeObject(spawnLocation,bulletVelocity);
            newBullet.AddToGroup("bullet");
            GetTree().CurrentScene.AddChild(newBullet);
        }
    }
/* 
* Name: _PhysicsProcess
* Description: Updates player movement every physics frame
* Parameters: double deltaTime - time in seconds since prev frame
* Returns: None
*/
	public override void _PhysicsProcess(double deltaTime)
	{
        HandleMovement(deltaTime);
        HandleRotation();
    }
/* 
* Name: HandleMovement
* Description: Translates input into a normalized Vector2 and then moves the player
* Parameters: double deltaTime - time in seconds since prev frame
* Returns: None
*/
    private void HandleMovement(double deltaTime)
    {
        Vector2 movementVector = Vector2.Zero;

        if (Input.IsActionPressed("MoveUp"))
        {
            movementVector += new Vector2(0, -1);
        }
        if (Input.IsActionPressed("MoveLeft"))
        {
            movementVector += new Vector2(-1, 0);
        }

        if (Input.IsActionPressed("MoveDown"))
        {
            movementVector += new Vector2(0, 1);
        }

        if (Input.IsActionPressed("MoveRight"))
        {
            movementVector += new Vector2(1, 0);
            //movementVector += Vector2.Right is the same
            //as movementVector += new Vector2(1,0);
        }

        MoveAndCollide(movementVector.Normalized() * UnitsPerMeter * (float)deltaTime * _movementSpeed);
    }

/* 
* Name: HandleRotation
* Description: Rotates player to look at the global mouse position
* Parameters: None
* Returns: None
*/
    private void HandleRotation()
    {
        LookAt(GetGlobalMousePosition()); //Uses global coordinates
        //GetGlobalMousePosition(); In space of entire game, where is the mouse relative to the scene, not in relation to anything else
        //GetLocalMousePosition(); Returns position relative to the parent, this would make the mouse aim the wrong direction

    }

/* 
* Name: StartIFrames
* Description: Disables the player's collision layer, starts countdown, calls EndIFrames after countdown ends
* Parameters: None
* Returns: None
*/
    public void StartIFrames()
    {
        this.SetCollisionLayerValue(6, false);
        Timer iframeDuration = new Timer();
        this.AddChild(iframeDuration);
        iframeDuration.Start(1);
        //iframeDuration.OneShot = true;
        iframeDuration.Timeout += EndIFrames;
        iframeDuration.Timeout += iframeDuration.QueueFree;
    }
/* 
* Name: EndIFrames
* Description: Reenables the player's collision layer
* Parameters: None
* Returns: None
*/
    public void EndIFrames()
    {
        this.SetCollisionLayerValue(6, true);

    }
}
