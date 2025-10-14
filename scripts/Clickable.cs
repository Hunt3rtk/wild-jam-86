using Godot;

public partial class Clickable : Sprite3D
{
	bool falling = false;
	public override void _Process(double delta)
	{
		if (falling)
		{
			Fall(delta);
		}
		else
		{
			FlyBy(delta);
		}
	}

	void FlyBy(double delta)
	{
		Position += new Vector3(0, 0, (float)delta * 10);
	}
	
	void Fall(double delta)
	{
		Position += new Vector3(0, (float)-delta * 10, 0);
		Rotation += new Vector3(0, 0, (float)-delta * 50);
		if (Position.Y < -100)
		{
			QueueFree();
		}
	}

	public void OnHit()
	{
		falling = true;
		var collider = GetNode<StaticBody3D>("StaticBody3D");
		collider.QueueFree();
		GD.Print("Clickable hit!");
	}

}
