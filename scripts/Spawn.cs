using Godot;
using System;

public partial class Spawn : Node
{
	[Export]
	internal PackedScene[] spawnScene;

	[Export]
	int minSpawn = 1;

	[Export]
	int maxSpawn = 5;

	internal double timeout = 0;

	[Export]
	internal double timeoutInterval = 2;

	[Export]
	public int round = -1;

	double difficulty = 0;

	double difficultyInterval = 10;
	
	[Export]
	public int difficultyLevel = 0;

	public override void _Process(double delta)
	{
		timeout += delta;
		difficulty += delta;

		SetDifficulty();
		SetRound();
	}

	void SetDifficulty()
	{
		if (difficulty > difficultyInterval)
		{
			difficulty = 0;
			if (timeoutInterval > 0.5)
			{
				difficultyLevel++;
				timeoutInterval -= 0.1;
			}
		}
	}
	
	internal virtual void SetRound()
	{
		if (timeout > timeoutInterval)
		{
			round++;
			timeout = 0;
			SpawnScenes();
		}
	}

	void SpawnScenes()
	{
		int spawnCount = GD.RandRange(minSpawn, maxSpawn);
		for (int i = 0; i < spawnCount; i++)
		{
			int sceneIndex = (int)(GD.Randi() % spawnScene.Length);
			PackedScene scene = spawnScene[sceneIndex];
			if (scene == null)
				continue;
			SpawnScene(scene);
		}
	}
	
	internal virtual void SpawnScene(PackedScene scene)
	{
		Sprite3D sprite = scene.Instantiate<Sprite3D>();

		sprite.Position = new Vector3((GD.Randf() - 0.5f) * 20, (GD.Randf() - 0.5f) * 20, -20);
		//sprite.GetNode<Clickable>("Clickable").speed += difficultyLevel * 2;

		AddChild(sprite);
	}
}
