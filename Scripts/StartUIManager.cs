using Godot;
using System;
using System.IO;

public partial class StartUIManager : Control
{
	private String _GameScene = "res://UI/panel.tscn";
	private Button _StartButton;
	private Button _OptionButton;
	private Button _QuitButton;
	public override void _Ready()
	{
		_StartButton = GetNode<Button>("Panel/StartButton");
		_OptionButton = GetNode<Button>("Panel/OptionButton");
		_QuitButton = GetNode<Button>("Panel/QuitButton");
		
		_StartButton.Connect("pressed", Callable.From(ChangeStartScene));
		_QuitButton.Connect("pressed", Callable.From(QuitGame));
	}

	private void ChangeStartScene()
	{
		GetTree().ChangeSceneToFile(_GameScene);
	}
	
	private void QuitGame()
	{
		// 게임 종료
		GetTree().Quit();
	}
}
