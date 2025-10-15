using Godot;

public partial class Clickable : Sprite3D
{
	bool falling = false;

	[Export]
	public float speed = 10;
	public override void _Process(double delta)
	{
		if (falling)
		{
			Fall(delta);
		}
		else if (this.Position.Z > 10)
		{
			Escape();
		}
		else
		{
			FlyBy(delta);
		}
	}

	void FlyBy(double delta)
	{
		Position += new Vector3(0, 0, (float)delta * speed);
	}

	void Fall(double delta)
	{
		Position += new Vector3(0, (float)-delta * 10, 0);
		Rotation += new Vector3(0, 0, (float)-delta * 75);
		if (Position.Y < -100)
		{
			QueueFree();
		}
	}
	
	async void Escape()
	{
		await ToSignal(GetTree().CreateTimer(.1), "timeout");
		QueueFree();
	}

	async public void OnHit()
	{
		falling = true;
		var collider = GetNode<Area3D>("Area3D");
		collider.QueueFree();
		GD.Print("Clickable hit!");
		await ToSignal(GetTree().CreateTimer(5), "timeout");
		Escape();
	}

}
