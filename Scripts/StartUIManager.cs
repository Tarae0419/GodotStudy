using Godot;
using System;
using System.IO;

public partial class StartUIManager : Control
{
	private String GameScene = "res://UI/panel.tscn";
	public override void _Ready()
	{
		var StartButton = GetNode<Button>("Panel/StartButton");

		StartButton.Connect("pressed", new Callable(this, "ChangeStartScene"));
	}

	private void ChangeStartScene()
	{
		GetTree().ChangeSceneToFile(GameScene);
	}
}
