using System.Text.RegularExpressions;

public class HeroStateFall : IHeroState
{
    public IHeroState DoState(HeroStateMachine hero, double deltaTime)
    {
        hero.HeroAnimations.Play("HeroFall");
        if (hero.IsOnFloor() && hero.IsMoving)
        {
            return HeroState.RUN;
        }
        if (hero.IsOnFloor() && !hero.IsMoving)
        {
            return HeroState.IDLE;
        }
        if (!hero.IsOnFloor())
        {
            return HeroState.FALL;
        }
        return HeroState.FALL;
    }
}