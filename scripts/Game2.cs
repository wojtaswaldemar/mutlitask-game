using Godot;
using System;

public partial class Game2 : Node2D
{
	[Export]
	public PackedScene pipe;
	private Node pipeNode;
	private GameManager GM;

	const double MOVESPEED = 100.0f;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GM = GetNode<GameManager>("../../Main/GameManager");
		GeneratePipe();
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
		if (pipeNode != null)
		{
			
			if (pipeNode is Area2D area2D)
				{
					area2D.Position = new Vector2((float)(area2D.Position.X - (MOVESPEED * delta)), 0);
				}
		}
	}

	private void GeneratePipe()
	{
		pipeNode = pipe.Instantiate();
		CallDeferred("add_child",pipeNode);

		if (pipeNode is Game2Pipe game2Pipe)
		{
			game2Pipe.Position = new Vector2(280, 0); // Example position
			game2Pipe.Hit += Game2Pipe_Hit;
		}
	}

	private void Game2Pipe_Hit(Node2D body)
	{
		if (body.Name == "Game2Character"){
			GM.Lose("Top Right Game");
		}
		if (body.Name == "Board"){
			RemoveAllPipe();
			GeneratePipe();
		}
	}

	private void RemoveAllPipe()
	{
		pipeNode.QueueFree();
		pipeNode = null;
	}
}
