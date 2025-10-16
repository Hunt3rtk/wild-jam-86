using Godot;
using System;

public partial class Return : Node
{
    void OnPressed()
	{
		GetTree().Paused = false;
		GetTree().ChangeSceneToFile("res://scenes/mainMenu.tscn");
	}
}
