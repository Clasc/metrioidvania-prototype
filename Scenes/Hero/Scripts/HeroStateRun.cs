using System.Text;

public class HeroStateRun : IHeroState
{
    public IHeroState DoState(HeroStateMachine hero, double deltaTime)
    {
        hero.HeroAnimations.Play("HeroRun");
        if (!hero.IsOnFloor())
        {
            return hero.heroStateFall;
        }

        if (hero.IsOnFloor() && !hero.IsMoving)
        {
            return hero.heroStateRun;
        }

        return hero.heroStateIdle;
    }
}