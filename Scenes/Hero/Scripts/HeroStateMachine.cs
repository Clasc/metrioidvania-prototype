using Godot;

public partial class HeroStateMachine : CharacterBody2D
{
	public HeroStateIdle heroStateIdle = new HeroStateIdle();
	public HeroStateRun heroStateRun = new HeroStateRun();
	public HeroStateFall heroStateFall = new HeroStateFall();


	[Export]
	public string AnimationNode;

	public AnimatedSprite2D HeroAnimations;

	private IHeroState currentState;

	private HeroMoveLogic _heroMoveLogic;

	private bool _isInitialized;

	public bool IsMoving { get; internal set; }

	public override void _Ready()
	{
		_isInitialized = InitHeroStateMachine();
	}

	public override void _PhysicsProcess(double delta)
	{
		if (_isInitialized)
		{
			UpdateHeroState(delta);
			_heroMoveLogic.ApplyGravity(delta);
			_heroMoveLogic.UpdateMovement(delta);
			_heroMoveLogic.MoveHero();
		}
	}

	private bool InitHeroStateMachine()
	{
		currentState = heroStateIdle;
		_heroMoveLogic = new HeroMoveLogic(this);
		return HasHeroAnimationsNode();
	}

	private bool HasHeroAnimationsNode()
	{
		HeroAnimations = GetNode<AnimatedSprite2D>(AnimationNode);

		if (HeroAnimations is null)
		{
			GD.PrintErr("AnimationNode cannot be found", AnimationNode);
			return false;
		}
		return true;
	}

	private void UpdateHeroState(double delta)
	{
		currentState = currentState.DoState(this, delta);
	}

	internal void EnableSnap()
	{
		_heroMoveLogic.SnapVector = new Vector2(0, 15);
	}

	internal void DisableSnap()
	{
		_heroMoveLogic.SnapVector = Vector2.Zero;
	}
}
