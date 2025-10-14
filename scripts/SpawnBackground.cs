using Godot;
using System;

public partial class SpawnBackground : Spawn
{
	public override void _Process(double delta)
	{
		timeout += delta;
		SetRound();
	}

	internal override void SetRound()
	{
		if (timeout > timeoutInterval)
		{
			timeout = 0;
			SpawnScene(scene: spawnScene[GD.Randi() % spawnScene.Length]);
		}
	}
	
	internal override void SpawnScene(PackedScene scene)
	{
		Sprite3D sprite = scene.Instantiate<Sprite3D>();

		//sprite.GetNode<Clickable>("Clickable").speed += difficultyLevel * 2;

		AddChild(sprite);
	}
}
