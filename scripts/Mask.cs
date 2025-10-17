using Godot;
using System;

public partial class Mask : Clickable
{

	private int x;
	private int y;

	private Node3D model;

	public override void _Ready()
	{
		x = GD.RandRange(-1f, 1f) > 0 ? 1 : -1;
		y = GD.RandRange(-1f, 1f) > 0 ? 1 : -1;
	}

	public override void FlyBy(double delta)
	{
		return;
	}


	public override void Fall(double delta)
	{
		//GetParent<Node3D>().RemoveChild(this);
		Position += new Vector3(x * 25 * (float)delta, y * 25 * (float)delta, 0);
		Rotation += new Vector3(0, 0, (float)-delta * 50);
		if (Position.Y < -50)
		{
			QueueFree();
		}
	}
}
