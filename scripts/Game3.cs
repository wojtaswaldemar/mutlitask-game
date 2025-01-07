using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Game3 : Node2D
{
	[Export]
	public PackedScene EnemyScene;
	private GameManager GM;
	private Timer STimer;
	private List<Marker2D> MarkerList = new List<Marker2D>();


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GM = GetNode<GameManager>("../../Main/GameManager");
		STimer = GetNode<Timer>("%SpawnerTimer");
		var left = GetNode<Node>("Spawners/Left");
		var right = GetNode<Node>("Spawners/Right");

		foreach (var marker in left.GetChildren())
		{
			if (marker is Marker2D marker2D)
			{
				MarkerList.Add(marker2D);
			}
		}
		foreach (var marker in right.GetChildren())
		{
			if (marker is Marker2D marker2D)
			{
				MarkerList.Add(marker2D);
			}
		}

		STimer.Start();

	}
	
	public void _on_spawner_timer_timeout(){
		SpawnEnemyAtRandomPoint();
	}

	public void SpawnEnemyAtRandomPoint()
	{
		Random ran = new Random();
		var randomPoint = MarkerList[ran.Next(MarkerList.Count - 1)];

		
		Game3Enemy enemy = EnemyScene.Instantiate<Game3Enemy>();
		this.AddChild(enemy);
		if (enemy is Game3Enemy game3Enemy)
		{
			enemy.Position = randomPoint.Position;
			if (randomPoint.Name.ToString().Contains("Right")){
				enemy.flip();
			}
			enemy.Hit += Game3Enemy_Hit;
		}
		
		/* PROBA BEZ PAckedScene

		Game3Enemy enemy = new Game3Enemy();
		this.AddChild(enemy);
		if (enemy is Game3Enemy game3Enemy)
		{
			GD.Print("Enemy w srodku");
			enemy.Position = randomPoint.Position;
			if (randomPoint.Name.ToString().Contains("Right"))
			{
				enemy.flip();
			}
			enemy.Hit += Game3Enemy_Hit;
		}

		GD.Print(enemy);
 		*/
	}

	private void Game3Enemy_Hit(Node2D body, Game3Enemy selfObejctToFree)
	{
		if (body.Name == "Game3Character"){
			GM.Lose("Bottom Left Game");
		}
		else{
			selfObejctToFree.QueueFree();
		}
	}

	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
