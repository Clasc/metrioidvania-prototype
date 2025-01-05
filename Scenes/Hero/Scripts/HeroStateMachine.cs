using Godot;

public partial class HeroStateMachine : CharacterBody2D
{

	[Export]
	public string AnimationNode;

	public AnimatedSprite2D HeroAnimations;

	private IHeroState _currentState;

	private HeroMoveLogic _heroMoveLogic;

	private bool _isInitialized;

	public bool IsMoving { get; internal set; }

	public string LastPlayedHeroAnimation = string.Empty;
	private float DefaultSnap = 0.0f;

	public override void _Ready()
	{
		_isInitialized = InitHeroStateMachine();
		DefaultSnap = FloorSnapLength;
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
		_currentState = HeroState.IDLE;
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
		_currentState = _currentState.DoState(this, delta);
	}

	internal void Jump()
	{
		_heroMoveLogic.Jump();
	}

	private void SetLastPlayedAnimation()
	{
		LastPlayedHeroAnimation = HeroAnimations.Animation.ToString();
	}

	internal void EnableSnap()
	{
		FloorSnapLength = DefaultSnap;
	}

	internal void DisableSnap()
	{
		FloorSnapLength = 0;
	}
}
