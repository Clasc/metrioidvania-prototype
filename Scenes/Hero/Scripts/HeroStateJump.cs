public class HeroStateJump : IHeroState
{
    public IHeroState DoState(HeroStateMachine hero, double deltaTime)
    {
        hero.DisableSnap();
        hero.HeroAnimations.Play(HeroAnimation.JUMP);
        if (hero.IsOnFloor())
        {
            return HeroState.IDLE;
        }

        if (hero.Velocity.Y < 0)
        {
            return HeroState.JUMP;
        }

        if (hero.Velocity.Y > 0)
        {
            return HeroState.FALL;
        }

        return HeroState.JUMP;
    }
}