using Godot;

public partial class Clickable : Sprite3D
{
	bool falling = false;

	[Export]
	public Type type = Type.Normal;

	public enum Type
	{
		Normal,
		Red,
		Blue,
		Purple
	}

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

	async public void OnHit(Type type)
	{

		if (this.type != type && this.type != Type.Normal)
		{
			SFX x = GetNode<SFX>("../../SFX/BadHitSFX");
			if (x != null) x.PlaySFX();

			return;
		}

		falling = true;

		SFX sfx = GetNode<SFX>("../../SFX/HitSFX");
		if (sfx != null) sfx.PlaySFX();

		var collider = GetNode<Area3D>("Area3D");
		collider.QueueFree();

		await ToSignal(GetTree().CreateTimer(5), "timeout");

		Escape();
	}

}
