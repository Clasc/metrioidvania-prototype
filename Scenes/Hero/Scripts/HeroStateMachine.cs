using Godot;

public partial class HeroStateMachine : CharacterBody2D
{
	public HeroStateIdle stateIdle = new HeroStateIdle();

	public AnimatedSprite2D HeroAnimations;

	private IHeroState currentState;
	private bool isInitialized;

	public override void _Ready()
	{
		isInitialized = InitHeroStateMachine();
	}

	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta);
		if (isInitialized)
		{
			UpdateHeroState(delta);
		}
	}

	private bool InitHeroStateMachine()
	{
		currentState = stateIdle;
		return HasHeroAnimationsNode();
	}

	private bool HasHeroAnimationsNode()
	{
		HeroAnimations = GetNode<AnimatedSprite2D>("./HeroAnimations");

		if (HeroAnimations is null)
		{
			GD.PrintErr("HeroStatemachine.cs -- GetAnimationsNode() -- HeroAnimations is null");
			return false;
		}
		return true;
	}

	private void UpdateHeroState(double delta)
	{
		currentState = currentState.DoState(this, delta);
	}
}
