using Godot;
using System;

public partial class HurtLogic : Node
{

	TextureRect[] hearts;

	int health;

	[Export]
	VBoxContainer gameOver;

	[Export]
	ColorRect fade;

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

		SFX sfx = GetNode<SFX>("../SFX/HurtSFX");
		if (sfx != null)
		{
			sfx.PlaySFX();
		}

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
			int round = GetNode<Spawn>("../Spawn").round;
			Label score = gameOver.GetNode<Label>("Score");

			GetTree().Paused = true;

			score.Text = "You survived " + round + " rounds!";

			gameOver.Visible = true;
			fade.Visible = true;
		}
	}
}
