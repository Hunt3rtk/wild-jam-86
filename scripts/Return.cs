using Godot;
using System;

public partial class Return : Node
{
	async void OnPressed()
	{
		GetTree().Paused = false;
		await ToSignal(GetTree().CreateTimer(.2), "timeout");
		GetTree().ChangeSceneToFile("res://scenes/mainMenu.tscn");
		return;
	}
}
