internal static class HeroState
{
    public static HeroStateIdle IDLE = new HeroStateIdle();
    public static HeroStateRun RUN = new HeroStateRun();
    public static HeroStateFall FALL = new HeroStateFall();
    public static HeroStateInitJump INIT_JUMP = new HeroStateInitJump();
    public static HeroStateJump JUMP = new HeroStateJump();
}