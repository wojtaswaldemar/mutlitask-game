using Godot;
using System;

public partial class GameManager : Node
{
	public int Points { get; set; } = 0;
	ColorRect LostScreen;
	Label LostTo;
	Label Score;
	Label HighScore;
	Button Restart;
	private double _score = 0;
	private bool gameLost = false;
	private bool canRestart = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		LostScreen = GetNode<ColorRect>("%LostScreen");
		LostTo = GetNode<Label>("%LostScreen/Lost/LostTo");
		Score = GetNode<Label>("%LostScreen/Lost/Score");
		Restart = GetNode<Button>("%LostScreen/RestartButton");
		HighScore = GetNode<Label>("%LostScreen/Lost/HighScore");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_score += delta;
		if (LostScreen.Visible && Input.IsActionJustPressed("jump"))
		{
			RestartGame();
		}
	}

	public void Lose(string DiedTo)
	{
		if (!gameLost)
		{
			HighScoreManager highScoreManager = new HighScoreManager();
			int hs = highScoreManager.HighScore;
			if (hs < (int)_score){
				highScoreManager.SaveHighScore((int)_score);
				hs = (int)_score;
			}

			Timer timerToReturn = CreateLostTimer();
			timerToReturn.Start();

			LostScreen.Visible = true;
			LostTo.Text = $"Died to: {DiedTo}";
			Score.Text = $"Survived {(int)_score} seconds.";
			HighScore.Text = $"Highest Score is {highScoreManager.HighScore}.";
			gameLost = true;
		}

	}

	public Timer CreateLostTimer()
	{
		Timer timerToReturn = new Timer();
		AddChild(timerToReturn);
		timerToReturn.Timeout += LostTimerToReturn_Timeout;
		timerToReturn.WaitTime = 0.5d;
		timerToReturn.OneShot = true;
		return timerToReturn;
	}

	private void LostTimerToReturn_Timeout()
	{
		canRestart = true;
		Restart.Visible = true;

	}

	private void RestartGame()
	{
		if (canRestart)
		GetTree().ReloadCurrentScene();
	}

	public void AddPoint()
	{
		Points++;
	}
	public void AddPoints(int points)
	{
		Points += points;
	}
}
