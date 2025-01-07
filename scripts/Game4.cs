using Godot;
using System;
using System.Diagnostics.CodeAnalysis;

public partial class Game4 : Node2D
{
	ProgressBar progressBar;
	Label Problem;
	Label Result;
	Timer _timerForProcessBar;
	private GameManager GM;
	Game4MathProblem Game4MathProblem;

	const double SECONDS_TO_100PROCENT = 15;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GM = GetNode<GameManager>("../../Main/GameManager");
		Problem = GetNode<Label>("UI/Problem");
		Result = GetNode<Label>("UI/Result");
		progressBar = GetNode<ProgressBar>("UI/ProgressBar");
		progressBar.ValueChanged += ProgressBar_ValueChanged;
		_timerForProcessBar = buildAndAddTimer();
		_timerForProcessBar.Start();
		restartGame();

	}

	private void ProgressBar_ValueChanged(double value)
	{
		if (value >= 100)
		{
			evaluateGameConditions();
		}
	}

	private void evaluateGameConditions()
	{
		if (Result.Text.Trim() == Game4MathProblem.result.ToString())
			restartGame();
		else
			GM.Lose("Bottom Right Game");
	}

	private void restartGame()
	{
		progressBar.Value = 0;
		Game4MathProblem = new Game4MathProblem();
		Problem.Text = $"{Game4MathProblem.Number1} {Game4MathProblem.OperateSymbol} {Game4MathProblem.Number2}";
		Result.Text = "";
	}

	private void _timerForProcessBar_Timeout()
	{
		progressBar.Value += (100 / SECONDS_TO_100PROCENT);
	}

	private Timer buildAndAddTimer()
	{
		Timer timerToReturn = new Timer();
		AddChild(timerToReturn);
		timerToReturn.WaitTime = 1;
		timerToReturn.Timeout += _timerForProcessBar_Timeout;
		return timerToReturn;
	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Result.Text.Length < 6 ){
			if (Input.IsActionJustPressed("0"))
				Result.Text += "0";
			if (Input.IsActionJustPressed("1"))
				Result.Text += "1";
			if (Input.IsActionJustPressed("2"))
				Result.Text += "2";
			if (Input.IsActionJustPressed("3"))
				Result.Text += "3";
			if (Input.IsActionJustPressed("4"))
				Result.Text += "4";
			if (Input.IsActionJustPressed("5"))
				Result.Text += "5";
			if (Input.IsActionJustPressed("6"))
				Result.Text += "6";
			if (Input.IsActionJustPressed("7"))
				Result.Text += "7";
			if (Input.IsActionJustPressed("8"))
				Result.Text += "8";
			if (Input.IsActionJustPressed("9"))
				Result.Text += "9";
		}
		if (Input.IsActionJustPressed("backspace"))
		{
			
			if (Result.Text.Length > 0){
				Result.Text = Result.Text.Remove(Result.Text.Length - 1);
			}
		}
			

	}
}
