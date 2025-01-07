using Godot;
using System;

public partial class Game1 : Node2D
{
	private Game1BallArea _ballArea;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_ballArea = GetNode<Game1BallArea>("Game1BallArea");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private void _on_game_1_ball_area_body_entered(Node body){


		//GD.Print("tutaj jetesmy");
		//_ballArea.transformDirection();

	}
}
