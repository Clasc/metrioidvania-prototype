using System.Text;

public class HeroStateRun : IHeroState
{
    public IHeroState DoState(HeroStateMachine hero, double deltaTime)
    {
        hero.HeroAnimations.Play("HeroRun");
        if (!hero.IsOnFloor())
        {
            return HeroState.FALL;
        }

        if (hero.IsOnFloor() && !hero.IsMoving)
        {
            return HeroState.RUN;
        }

        return HeroState.RUN;
    }
}