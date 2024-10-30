using Godot;
using System;

public partial class StartUIManager : Control
{
	public String GameScene = "res://UI/panel.tscn";
	public override void _Ready()
	{
		var StartButton = GetNode<Button>("Panel/StartButton");

		StartButton.Connect("pressed", new Callable(this, "ChangeStartScene"));
	}

	private void ChangeStartScene()
	{
		GD.Print("씬 이동");
		GetTree().ChangeSceneToFile(GameScene);
	}
}
