using Godot;
using System;

public partial class HurtLogic : Node
{

	TextureRect[] hearts;

	int health;

	public override void _Ready()
	{
		var heartContainer = GetNode<HBoxContainer>("../CanvasLayer/HeartContainer");
		hearts = new TextureRect[heartContainer.GetChildCount()];
		health = hearts.Length;
		for (int i = 0; i < heartContainer.GetChildCount(); i++)
		{
			hearts[i] = heartContainer.GetChild(i) as TextureRect;
		}
	}

	void OnEnter(Node other)
	{
		health--;
		TakeDamage();
	}

	void TakeDamage()
	{
		for (int i = 0; i < hearts.Length; i++)
		{
			if (i < health)
			{
				hearts[i].Visible = true;
			}
			else
			{
				hearts[i].Visible = false;
			}
		}
		if (health <= 0)
		{
			GetTree().ChangeSceneToFile("res://scenes/mainMenu.tscn");
		}
	}
}
