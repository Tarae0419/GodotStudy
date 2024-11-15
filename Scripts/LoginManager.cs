using Godot;
using System;

public partial class LoginManager : Node
{
	private LineEdit _IDEdit;
	private LineEdit _PasswordEdit;
	private Label _IDLabel;
	private Label _PasswordLabel;
	private Button _LoginButton;
	
	public override void _Ready()
	{
		_IDEdit = GetNode<LineEdit>("SignInPanel/IDEdit");
		_PasswordEdit = GetNode<LineEdit>("SignInPanel/PWEdit");
		_IDLabel = GetNode<Label>("SignInPanel/IDLabel");
		_PasswordLabel = GetNode<Label>("SignInPanel/PWLabel");
		_LoginButton = GetNode<Button>("SignInPanel/LoginButton");
		
		_LoginButton.Connect("pressed",Callable.From(Login));

	}
	
	public override void _Process(double delta)
	{
	}

	private void Login()
	{
		
	}
}
