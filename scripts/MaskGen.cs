using Godot;
using System;

public partial class MaskGen : Node
{
	[Export]
	internal PackedScene[] maskScenes;

	[Export]
	internal int minAmount = 1;

	[Export]
	internal int maxAmount = 5;

	public override void _Ready()
	{
		SpawnMasks();
	}

	void SpawnMasks()
	{
		int spawnCount = GD.RandRange(minAmount, maxAmount);
		int offset = 0;
		for (int i = 0; i < spawnCount; i++)
		{
			offset++;
			SpawnMask(offset);
		}
	}

	void SpawnMask(int offset)
	{
		int index = (int)GD.Randi() % maskScenes.Length;
		var maskInstance = maskScenes[index].Instantiate<Mask>();

		AddChild(maskInstance);
		maskInstance.Position = new Vector3(0, 0, offset);
	}
}
