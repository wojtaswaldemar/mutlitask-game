using Godot;
using System;

public partial class Game1Character : CharacterBody2D
{
	public const float Speed = 300.0f;
	
	private RayCast2D _rayCastRight;
	private RayCast2D _rayCastLeft;

	public override void _Ready()
	{
		_rayCastRight = GetNode<RayCast2D>("RayCast2DRight");
		_rayCastLeft = GetNode<RayCast2D>("RayCast2DLeft");
		base._Ready();
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		float direction = Input.GetAxis("arrow_left", "arrow_right");

		//TURNS OUT BELOW IS NOT NEEDED WHEN Having boundires
		// STOP IF COLLIDING WITH BOUNDRIES
		//if (_rayCastLeft.IsColliding() || _rayCastRight.IsColliding())
		//{
				//direction = 0;
		//}

		if (direction != 0){
			velocity.X = direction * Speed;
		}



		Velocity = velocity;
		MoveAndSlide();
	}
}
