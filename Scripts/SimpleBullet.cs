/********************************************************************************************/
/*  File: SimpleBullet.cs
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
using System.Security.Cryptography.X509Certificates;

//Most code reused from Shootio Project
public partial class SimpleBullet : CharacterBody2D
{
    public Vector2 BulletVelocity { get; set; }
    //public, static can only change other static, same across all instances of the class

    public static SimpleBullet InitalizeObject(Vector2 spawnPosition, Vector2 initalVelocity)
    {
        
        SimpleBullet newBullet = (SimpleBullet)ResourceLoader.Load<PackedScene>("res://Scenes/simple_bullet.tscn").Instantiate();
       
        //ResourceLoader is a handler, creates new instances of scenes
        //We are constructing a packedscene type, not a simplebullet type
        //We are loading the simplebullet scene, so we put the path in the quotes
        // .instantiate creates a new instance of that scene
        //Put SimpleBullet in front so that we can actually make a new bullet

        newBullet.GlobalPosition = spawnPosition;
        newBullet.TopLevel = true; //Position and movement is not dependant on its parents
        newBullet.BulletVelocity = initalVelocity;
        return newBullet;
    }

/* 
* Name: _PhysicsProcess
* Description: Checks for collision with the bullet every physics frame, if collision is found then it deletes the bullet
* Parameters: double deltaTime - time in seconds since prev frame
* Returns: None
*/
    public override void _PhysicsProcess(double deltaTime)
    {
        KinematicCollision2D collidedObject = this.MoveAndCollide(BulletVelocity * (float)deltaTime);
        
        if (collidedObject != null) {
            GD.Print("IS COLLISION");
            this.QueueFree(); //deletes the bullet
            //Was going to do something with groups here, decided not to
            if (collidedObject.GetCollider() is Target hitTarget)
            {   
                GD.Print("IS TARGET");
                //delete target
                hitTarget.QueueFree();


            } else if (collidedObject.GetCollider() is SimpleBullet)
            {
                GD.Print("IS BULLET");
            }
        }
    }


}


