using Godot;

public class HighScoreManager
{
	private const string SaveFilePath = "user://MultitaskGame.save";

	public int HighScore => GetHighScore();

	public void SaveHighScore(int highscore)
	{
		using var saveFile = FileAccess.Open(SaveFilePath, FileAccess.ModeFlags.Write);
		// Store the save dictionary as a new line in the save file.
		saveFile.StoreLine(highscore.ToString());
	}
	int GetHighScore()
	{
		if (!FileAccess.FileExists(SaveFilePath))
		{
			return 0;
		}

		using var saveFile = FileAccess.Open(SaveFilePath, FileAccess.ModeFlags.Read);

		while (saveFile.GetPosition() < saveFile.GetLength())
		{
			var highscore = saveFile.GetLine();
			return highscore.ToInt();
		}

		return 0;
	}
}
