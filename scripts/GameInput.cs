using Godot;
using System;

public partial class GameInput : RayCast3D
{
	private const float RayLength = 1000.0f;

	private Vector3 from;
	private Vector3 to;

	[Export]
	Camera3D camera3D;

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton eventMouseButton && eventMouseButton.Pressed && eventMouseButton.ButtonIndex == MouseButton.Left)
		{
			GD.Print(" Input event: ", @event);
			from = camera3D.ProjectRayOrigin(eventMouseButton.Position);
			to = from + camera3D.ProjectRayNormal(eventMouseButton.Position) * RayLength;

			var spaceState = GetWorld3D().DirectSpaceState;
			var query = PhysicsRayQueryParameters3D.Create(from, to);
			query.CollideWithAreas = true;

			var result = spaceState.IntersectRay(query);
			GD.Print("Hit at point: ", result);

			if (result.Count == 0) return;

			var collider = result["collider"];
			Clickable obj = (Clickable)collider.As<Area3D>().GetParent();
			obj.OnHit();
		}
	}
}
