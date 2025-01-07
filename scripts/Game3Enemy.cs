using Godot;
using System;

public partial class Game3Enemy : Area2D
{
	[Signal]
	public delegate void HitEventHandler(Node2D body, Game3Enemy selfObejctToFree);
	const double MOVESPEED = 120.0f;
	int direction = -1;



	private void _on_body_entered(Node2D body){
		EmitSignal("Hit", body, this);
	}

	public void flip()
	{
		this.GetNode<Sprite2D>("Sprite2D").FlipH = true;
		this.GetNode<CollisionPolygon2D>("CollisionPolygon2D").Scale =new Vector2(-1,1);
		direction = 1;
	}

	public override void _Process(double delta)
	{
		
		Position = new Vector2((float)(Position.X - (MOVESPEED * delta * direction)), Position.Y);
		base._Process(delta);
	}
}
