public class HeroStateInitJump : IHeroState
{
    private bool _jumpInitiated = false;
    public IHeroState DoState(HeroStateMachine hero, double deltaTime)
    {
        if (!_jumpInitiated)
        {
            _jumpInitiated = true;
            hero.Jump();
        }
        hero.HeroAnimations.Play(HeroAnimation.INIT_JUMP);
        return HeroState.INIT_JUMP;
    }
}