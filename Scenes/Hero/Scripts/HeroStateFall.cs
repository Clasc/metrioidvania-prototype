using System.Text.RegularExpressions;

public class HeroStateFall : IHeroState
{
    public IHeroState DoState(HeroStateMachine hero, double deltaTime)
    {
        hero.EnableSnap();
        hero.HeroAnimations.Play("HeroFall");
        if (hero.IsOnFloor() && hero.IsMoving)
        {
            return hero.heroStateRun;
        }
        if (hero.IsOnFloor() && !hero.IsMoving)
        {
            return hero.heroStateIdle;
        }
        if (!hero.IsOnFloor())
        {
            return hero.heroStateFall;
        }
        return hero.heroStateFall;
    }
}