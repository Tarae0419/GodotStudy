using Godot;
using System;
using System.IO;

public partial class StartUIManager : Control
{
	private String _gameScene = "res://UI/panel.tscn";
	private Button _startButton;
	private Button _optionButton;
	private Button _quitButton;
	public override void _Ready()
	{
		_startButton = GetNode<Button>("Panel/StartButton");
		_optionButton = GetNode<Button>("Panel/OptionButton");
		_quitButton = GetNode<Button>("Panel/QuitButton");
		
		_startButton.Connect("pressed", Callable.From(ChangeStartScene));
		_quitButton.Connect("pressed", Callable.From(QuitGame));
	}

	private void ChangeStartScene()
	{
		GetTree().ChangeSceneToFile(_gameScene);
	}
	
	private void QuitGame()
	{
		GetTree().Quit();
	}
}
