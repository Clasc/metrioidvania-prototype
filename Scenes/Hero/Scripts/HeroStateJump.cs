using Godot;

public class HeroStateJump : IHeroState
{
    public IHeroState DoState(HeroStateMachine hero, double deltaTime)
    {
        hero.HeroAnimations.Play(HeroAnimation.JUMP);
        GD.Print("Jump pressed");
        if (hero.IsOnFloor())
        {
            return HeroState.IDLE;
        }

        if (hero.Velocity.Y < 0)
        {
            return HeroState.JUMP;
        }

        if (hero.Velocity.Y > 0)
        {
            return HeroState.FALL;
        }

        return HeroState.JUMP;
    }
}