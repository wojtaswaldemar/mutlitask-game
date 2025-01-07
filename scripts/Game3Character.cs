using Godot;
using System;

public partial class Game3Character : CharacterBody2D
{
	int Y_position = 0;
	int Y_MIN_POSITION = -2;
	int Y_MAX_POSITION = 2;
	int Y_CHANGE_PER_MOVE = 60;
	Vector2 initPosition;

	public override void _Ready()
	{
		initPosition = GlobalPosition;
		base._Ready();
	}

	public override void _PhysicsProcess(double delta)
	{

		if (Input.IsActionJustPressed("arrow_up") && Y_position > Y_MIN_POSITION)
		{
			Y_position--;
		}
		if (Input.IsActionJustPressed("arrow_down") && Y_position < Y_MAX_POSITION)
		{
			Y_position++;
		}

		GlobalPosition = new Vector2(initPosition.X, initPosition.Y + (Y_CHANGE_PER_MOVE * Y_position));
		
		
	}
}
