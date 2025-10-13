using Godot;
using System;

public partial class Spawn : Node
{
	[Export]
	public PackedScene[] spawnScene;

	public override void _Process(double delta)
	{
		foreach (PackedScene scene in spawnScene)
		{
			Sprite3D sprite = scene.Instantiate<Sprite3D>();
			sprite.Position = new Vector3((GD.Randf()-0.5f) * 10, (GD.Randf()-0.5f) * 10, 0);
			
			AddChild(sprite);
		}
	}

}
