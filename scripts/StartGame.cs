using Godot;
using System;
using System.Threading.Tasks;

public partial class StartGame : Control
{
	async void OnStartPressed()
	{
		GetTree().Paused = false;

		await ToSignal(GetTree().CreateTimer(.2), "timeout");

		GetTree().ChangeSceneToFile("res://scenes/game.tscn");
		return;
	}
	
	async void OnQuitPressed()
	{
		await ToSignal(GetTree().CreateTimer(.2), "timeout");
		GetTree().Quit();
		return;
	}
}
