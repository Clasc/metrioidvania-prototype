using Godot;

public class HeroMoveLogic
{
    private readonly float _gravity = 1000;
    private readonly float _speed = 1200;
    private readonly float _maxMovementSpeed = 200;
    private readonly float _jumpForce = 500;
    private readonly float _friction = 0.7f;
    private readonly float _acceleration = 0.5f;
    private readonly HeroStateMachine _hero;

    public HeroMoveLogic(HeroStateMachine heroStateMachine)
    {
        _hero = heroStateMachine;
    }

    public void MoveHero()
    {
        _hero.MoveAndSlide();
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
            UpdateX(Lerp(_hero.Velocity.X, 0.0f, _friction));
        }

        UpdateX(Mathf.Clamp(_hero.Velocity.X, -_maxMovementSpeed, _maxMovementSpeed));

        Flip(xVelocity);
        IsMoving();
    }

    public void ApplyGravity(double delta)
    {
        UpdateY(_hero.Velocity.Y + (float)(_gravity * delta));
    }

    private void Flip(float xVelocity)
    {
        _hero.HeroAnimations.FlipH = xVelocity < 0;
    }

    private void IsMoving()
    {
        _hero.IsMoving = _hero.Velocity.X != 0;
    }

    private bool IsHeroOnSlope()
    {
        return _hero.GetFloorNormal().X != 0;
    }

    float Lerp(float firstFloat, float secondFloat, float by)
    {
        return firstFloat * (1 - by) + secondFloat * by;
    }

    public void UpdateX(float x)
    {
        _hero.Velocity = new Vector2(x, _hero.Velocity.Y);
    }

    public void UpdateY(float y)
    {
        _hero.Velocity = new Vector2(_hero.Velocity.X, y);
    }
    public void Jump()
    {
        UpdateY(_jumpForce);
    }
}