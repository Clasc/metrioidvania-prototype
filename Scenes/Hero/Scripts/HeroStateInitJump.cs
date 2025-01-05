public class HeroStateInitJump : IHeroState
{
    private bool _jumpInitiated = false;
    public IHeroState DoState(HeroStateMachine hero, double deltaTime)
    {
        hero.DisableSnap();
        if (!_jumpInitiated)
        {
            _jumpInitiated = true;
            hero.Jump();
        }

        hero.HeroAnimations.Play(HeroAnimation.INIT_JUMP);

        if (hero.LastPlayedHeroAnimation.Equals(HeroAnimation.INIT_JUMP))
        {
            _jumpInitiated = false;
            return HeroState.JUMP;
        }

        return HeroState.INIT_JUMP;
    }
}