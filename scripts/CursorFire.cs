using Godot;
using System;

public partial class CursorFire : Node
{
	Resource cursorFireLeft = ResourceLoader.Load("res://sprites/crosshairFireRed.png");
	Resource cursorFireRight = ResourceLoader.Load("res://sprites/crosshairFireBlue.png");
	Resource cursorFireBoth = ResourceLoader.Load("res://sprites/crosshairFirePurple.png");
	Resource cursor = ResourceLoader.Load("res://sprites/crosshairNeutral.png");


	public override void _Input(InputEvent @event)
	{
		/*if (@event is InputEventMouseButton eventMouseButtonLeft && eventMouseButtonLeft.Pressed && eventMouseButtonLeft.ButtonIndex == MouseButton.Left)
		{
			OnPressedDown();
		} else if (@event is InputEventMouseButton eventMouseButtonRight && !eventMouseButtonRight.Pressed && eventMouseButtonRight.ButtonIndex == MouseButton.Right)
		{
			OnPressedDown();
		} else
		if (@event is InputEventMouseButton eventMouseButtonBoth && eventMouseButtonBoth.IsActionPressed("mouse_both"))
		{
			OnPressedDown();
		}*/
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("mouse_left") && !Input.IsActionPressed("mouse_right"))
		{
			OnLeftPressedDown();
		}
		else if (Input.IsActionJustPressed("mouse_right") && !Input.IsActionPressed("mouse_left"))
		{
			OnRightPressedDown();
		}
		else if (Input.IsActionJustPressed("mouse_left") && Input.IsActionPressed("mouse_right") || Input.IsActionJustPressed("mouse_right") && Input.IsActionPressed("mouse_left"))
		{
			OnBothPressedDown();
		}
	}

	public async void OnLeftPressedDown()
	{
		Input.SetCustomMouseCursor(cursorFireLeft, Input.CursorShape.Arrow, new Vector2(117, 117));
		SFX sfx = GetNode<SFX>("../SFX/LaserSFX");
		if (sfx != null)
		{
			sfx.PlaySFX();
		}
		else
		{
			await ToSignal(GetTree().CreateTimer(.2), "timeout");
			Default();
		}
	}

	async void OnRightPressedDown()
	{
		Input.SetCustomMouseCursor(cursorFireRight, Input.CursorShape.Arrow, new Vector2(117, 117));
		SFX sfx = GetNode<SFX>("../SFX/LaserSFX");
		if (sfx != null)
		{
			sfx.PlaySFX();
		}
		else
		{
			await ToSignal(GetTree().CreateTimer(.2), "timeout");
			Default();
		}
	}
	
	async void OnBothPressedDown()
	{
		Input.SetCustomMouseCursor(cursorFireBoth, Input.CursorShape.Arrow, new Vector2(117, 117));
		SFX sfx = GetNode<SFX>("../SFX/LaserSFX");
		if (sfx != null) {
			sfx.PlaySFX();
		} else {
			await ToSignal(GetTree().CreateTimer(.2), "timeout");
			Default();
		}
	}

	void Default()
	{
		Input.SetCustomMouseCursor(cursor, Input.CursorShape.Arrow, new Vector2(117, 117));
	}
}
