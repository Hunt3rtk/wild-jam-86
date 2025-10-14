using Godot;
using System;

public partial class Mask : Node
{

	private Node3D model;

	public void OnHit()
	{
		GD.Print("Mask hit!");
	}
}
