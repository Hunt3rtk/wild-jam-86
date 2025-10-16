using Godot;
using System;

public partial class CursorFire : Node
{

	Resource cursorFire = ResourceLoader.Load("res://sprites/crosshairFirePurple.png");
	Resource cursor = ResourceLoader.Load("res://sprites/crosshairNeutral.png");

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton eventMouseButton && eventMouseButton.Pressed && eventMouseButton.ButtonIndex == MouseButton.Left)
		{
			OnPressedDown();
		}
	}

	async void OnPressedDown()
	{
		Input.SetCustomMouseCursor(cursorFire, Input.CursorShape.Arrow, new Vector2(117, 117));
		await ToSignal(GetTree().CreateTimer(.2), "timeout");
		Default();
	}

	void Default()
	{
		Input.SetCustomMouseCursor(cursor, Input.CursorShape.Arrow, new Vector2(117, 117));
	}
}
