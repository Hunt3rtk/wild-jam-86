using Godot;
using System;

public partial class GameInput : RayCast3D
{
	private const float RayLength = 1000.0f;

	private Vector3 from;
	private Vector3 to;

	[Export]
	Camera3D camera3D;

	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("mouse_left") && !Input.IsActionPressed("mouse_right"))
		{
			LeftClick();
		}
		else if (Input.IsActionJustPressed("mouse_right") && !Input.IsActionPressed("mouse_left"))
		{
			RightClick();
		}
		else if (Input.IsActionJustPressed("mouse_left") && Input.IsActionPressed("mouse_right") || Input.IsActionJustPressed("mouse_right") && Input.IsActionPressed("mouse_left"))
		{
			BothClick();
		}
	}

	Clickable Click()
	{
		from = camera3D.ProjectRayOrigin(GetViewport().GetMousePosition());
		to = from + camera3D.ProjectRayNormal(GetViewport().GetMousePosition()) * RayLength;

		var spaceState = GetWorld3D().DirectSpaceState;
		var query = PhysicsRayQueryParameters3D.Create(from, to);
		query.CollideWithAreas = true;

		var result = spaceState.IntersectRay(query);

		if (result.Count == 0) 	return null;

		var collider = result["collider"];
		Clickable obj = (Clickable)collider.As<Area3D>().GetParent();

		var playerTexture = GetNode<RotateTexture>("/root/Node3D/CanvasLayer/PlayerContainer/PlayerSprite");
		playerTexture.SelectTexture();

		return obj;
	}

	void LeftClick()
	{
		Clickable obj = Click();
		if (obj != null)
			obj.OnHit(Clickable.Type.Red);
	}

	void RightClick()
	{
		Clickable obj = Click();
		if (obj != null)
			obj.OnHit(Clickable.Type.Blue);
	}
	
	void BothClick()
	{
		Clickable obj = Click();
		if (obj != null)
			obj.OnHit(Clickable.Type.Purple);
	}
}
