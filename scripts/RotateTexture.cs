using Godot;
using System;

public partial class RotateTexture : TextureRect
{

	[Export]
	private Texture2D[] textures;

	private int currentIndex = 0;

	public void SelectTexture()
	{
		int index = GD.RandRange(0, textures.Length - 1);

		if (index == currentIndex)
		{
			index = (index + 1) % textures.Length;
		}
		currentIndex = index;

		this.Texture = textures[index];
		
	}
}
