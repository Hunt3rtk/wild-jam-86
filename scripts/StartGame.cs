using Godot;
using System;

public partial class StartGame : Control
{
	async void OnStartPressed()
	{
		GetTree().Paused = false;

		await ToSignal(GetTree().CreateTimer(.3), "timeout");
		
		GetTree().ChangeSceneToFile("res://scenes/game.tscn");
	}
	
	void OnQuitPressed()
	{
		GetTree().Quit();
	}
}
