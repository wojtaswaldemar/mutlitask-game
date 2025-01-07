using Godot;
using System;

public partial class Game2Pipe : Area2D
{
	[Signal]
	public delegate void HitEventHandler(Node2D body);
	
	private void _on_body_entered(Node2D body){
		EmitSignal("Hit", body);
	}
}
