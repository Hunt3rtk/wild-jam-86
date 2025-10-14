using Godot;
using System;

public partial class HurtLogic : Area3D
{
	public void OnEnter()
	{
		GD.Print("You got hurt!");
	}
}
