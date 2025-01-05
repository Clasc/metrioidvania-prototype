using Godot;

public class HeroStateIdle : IHeroState
{
    public IHeroState DoState(HeroStateMachine hero, double deltaTime)
    {
        if (!hero.IsOnFloor())
        {
            return HeroState.FALL;
        }

        if (Input.IsActionJustPressed("Jump"))
        {
            return HeroState.INIT_JUMP;
        }

        if (hero.IsMoving)
        {
            return HeroState.RUN;
        }
        if (!hero.IsMoving)
        {
            hero.HeroAnimations.Play(HeroAnimation.IDLE);
            return HeroState.IDLE;
        }
        return HeroState.IDLE;
    }
}