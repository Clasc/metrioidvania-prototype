using System;
using Godot;

public class HeroMoveLogic
{
    private float _gravity = 1000;
    private float _speed = 1200;
    private float _maxMovementSpeed = 200;
    private float _friction = 0.7f;
    private float _acceleration = 0.5f;

    public Vector2 SnapVector;

    HeroStateMachine Hero;

    public HeroMoveLogic(HeroStateMachine heroStateMachine)
    {
        Hero = heroStateMachine;
    }

    public void MoveHero()
    {
        Hero.MoveAndSlide();
    }

    public void UpdateMovement(double delta)
    {
        var xVelocity = Input.GetAxis("MoveLeft", "MoveRight") * _speed;
        if (xVelocity != 0)
        {
            UpdateX(Lerp(xVelocity, xVelocity * _speed, _acceleration));
        }
        else
        {
            UpdateX(Lerp(Hero.Velocity.X, 0.0f, _friction));
        }

        UpdateX(Mathf.Clamp(Hero.Velocity.X, -_maxMovementSpeed, _maxMovementSpeed));

        Flip(xVelocity);
        IsMoving();
    }

    public void ApplyGravity(double delta)
    {
        UpdateY(Hero.Velocity.Y + (float)(_gravity * delta));
    }

    private void Flip(float xVelocity)
    {
        Hero.HeroAnimations.FlipH = xVelocity < 0;
    }

    private void IsMoving()
    {
        Hero.IsMoving = Hero.Velocity.X != 0;
    }

    private bool IsHeroOnSlope()
    {
        return Hero.GetFloorNormal().X != 0;
    }

    float Lerp(float firstFloat, float secondFloat, float by)
    {
        return firstFloat * (1 - by) + secondFloat * by;
    }

    public void UpdateX(float x)
    {
        Hero.Velocity = new Vector2(x, Hero.Velocity.Y);
    }

    public void UpdateY(float y)
    {
        Hero.Velocity = new Vector2(Hero.Velocity.X, y);
    }

}