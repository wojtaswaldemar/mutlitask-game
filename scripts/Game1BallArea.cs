using Godot;
using System;

public partial class Game1BallArea : Area2D
{
	public const float speed = 200.0f;
	private Vector2 _direction;
	private RayCast2D RCDown;
	private RayCast2D RCUp;
	private RayCast2D RCLeft;
	private RayCast2D RCRight;
	private GameManager GM;

	//private ShapeCast2D _shapeCast;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		RCDown = GetNode<RayCast2D>("RayCast2DDown");
		RCUp = GetNode<RayCast2D>("RayCast2DUp");
		RCLeft = GetNode<RayCast2D>("RayCast2DLeft");
		RCRight = GetNode<RayCast2D>("RayCast2DRight");
		GM = GetNode<GameManager>("../../../Main/GameManager");
		

		Random random = new Random();
		float ran1 = (float)(0.8f + random.NextDouble() * 0.2f);
		float ran2 = (float)(0.8f + random.NextDouble() * 0.2f);
		_direction = new Vector2(ran1, ran2).Normalized();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

		if (RCDown.IsColliding())
		{
			if (RCDown.GetCollider().GetType() != typeof(Game1Character))
			{
				GM.Lose("Top Left Game");

			}

			transformDirection(0, Math.Abs(_direction.Y) * 1);
		}
		if (RCUp.IsColliding())
		{
			transformDirection(0, Math.Abs(_direction.Y) * -1);
		}
		if (RCLeft.IsColliding())
		{
			transformDirection(Math.Abs(_direction.X) * -1, 0);
		}
		if (RCRight.IsColliding())
		{
			transformDirection(Math.Abs(_direction.X) * 1, 0);
		}
		Position = new Vector2(Position.X - (float)(_direction.X * speed * delta), Position.Y - (float)(_direction.Y * speed * delta));
	}

	public void transformDirection(float x, float y)
	{
		float newX = x == 0 ? _direction.X : x;
		float newY = y == 0 ? _direction.Y : y;
		_direction = new Vector2(newX, newY);
	}
}
