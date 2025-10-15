using Godot;
using System;

public partial class StartGame : Control
{
	void OnStartPressed()
	{
		GetTree().ChangeSceneToFile("res://scenes/game.tscn");
	}
	
	void OnQuitPressed()
	{
		GetTree().Quit();
	}
}
