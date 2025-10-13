using Godot;

public partial class FlyBy : Sprite3D
{
	public override void _Process(double delta)
	{
		Position += new Vector3(0, 0, (float)delta * 10);
	}

}
