using Godot;
using System;
using static Godot.TextServer;

public partial class Game1Ball : RigidBody2D
{
	public const float speed = 230.0f;
	private Vector2 _direction;
	private ShapeCast2D _shapeCast;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_shapeCast = GetNode<ShapeCast2D>("ShapeCast2D");
		_direction = new Vector2(-100,-100);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		LinearVelocity = _direction;
		if (_shapeCast.IsColliding())
		{
			//GD.Print(_direction.X * -1, _direction.Y * -1);
			//_direction = new Vector2((_direction.X * -1), (_direction.Y * -1));
		}
		


	}
	
	
}
