public interface IHeroState
{
    IHeroState DoState(HeroStateMachine hero, double deltaTime);
}