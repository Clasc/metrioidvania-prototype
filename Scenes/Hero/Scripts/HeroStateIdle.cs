public class HeroStateIdle : IHeroState
{
    public IHeroState DoState(HeroStateMachine hero, double deltaTime)
    {
        if (!hero.IsOnFloor())
        {
            return HeroState.FALL;
        }
        if (hero.IsMoving)
        {
            return HeroState.RUN;
        }
        if (!hero.IsMoving)
        {
            hero.HeroAnimations.Play("Idle");
            return HeroState.IDLE;
        }
        return HeroState.IDLE;
    }
}