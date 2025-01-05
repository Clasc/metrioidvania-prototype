using Godot;

public class HeroStateRun : IHeroState
{
    public IHeroState DoState(HeroStateMachine hero, double deltaTime)
    {
        hero.HeroAnimations.Play(HeroAnimation.RUN);
        if (!hero.IsOnFloor())
        {
            return HeroState.FALL;
        }

        if (Input.IsActionJustPressed("Jump"))
        {
            return HeroState.INIT_JUMP;
        }

        if (hero.IsOnFloor() && !hero.IsMoving)
        {
            return HeroState.RUN;
        }

        return HeroState.RUN;
    }
}