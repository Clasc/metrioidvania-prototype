public class HeroStateIdle : IHeroState
{
    public IHeroState DoState(HeroStateMachine hero, double deltaTime)
    {
        hero.HeroAnimations.Play("Idle");
        return hero.stateIdle;
    }
}