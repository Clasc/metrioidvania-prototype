using Godot;
using System;

public partial class Parallax : ParallaxBackground
{
	private float ScrollSpeed = 100f;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		this.ScrollOffset += new Vector2((ScrollSpeed * (float)delta), 0);
	}
}
