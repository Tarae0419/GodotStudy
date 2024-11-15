using Godot;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public partial class LoginManager : Node
{
	private LineEdit _IDEdit;
	private LineEdit _PasswordEdit;
	private Label _IDLabel;
	private Label _PasswordLabel;
	private Button _LoginButton;
	private Button _SignUpButton;
	private Panel _SignInPanel;
	private Panel _SignUpPanel;
	
	private String _startUI = "res://UI/StartUI.tscn";
	
	private static readonly Regex EmailRegex = new Regex(
		@"^[^@\s]+@[^@\s]+\.[^@\s]+$",
		RegexOptions.Compiled
	);

	private Dictionary<string, string> _userDatabase = new Dictionary<string, string>
    {
        { "user1", "password1" },
        { "user2", "password2" },
        { "admin", "adminpass" }
    };
	
	public override void _Ready()
	{
		_IDEdit = GetNode<LineEdit>("SignInPanel/IDEdit");
		_PasswordEdit = GetNode<LineEdit>("SignInPanel/PWEdit");
		_IDLabel = GetNode<Label>("SignInPanel/IDLabel");
		_PasswordLabel = GetNode<Label>("SignInPanel/PWLabel");
		_LoginButton = GetNode<Button>("SignInPanel/LoginButton");
		_SignUpButton = GetNode<Button>("SignInPanel/SignUpButton");
		_SignInPanel = GetNode<Panel>("SignInPanel");
		_SignUpPanel = GetNode<Panel>("SignUpPanel");
		
		_LoginButton.Connect("pressed",Callable.From(Login));
		_SignUpButton.Connect("pressed", Callable.From(ShowSignUpPanel));

	}

	private void Login()
	{
		string enteredUsername = _IDEdit.Text;
		string enteredPassword = _PasswordEdit.Text;

		if (CheckLogin(enteredUsername, enteredPassword))
		{
			_SignInPanel.Hide();
		}
	}

	private bool CheckLogin(string username, string password)
	{
		if (_userDatabase.ContainsKey(username) && _userDatabase[username] == password)
		{
			return true;
		}
		return false;
	}

	private void ShowSignUpPanel()
	{
		_SignInPanel.Hide();
		_SignUpPanel.Show();
	}
	
	private void ShowSignInPanel()
	{
		_SignUpPanel.Hide();
		_SignInPanel.Show();
	}
	
	private bool IsEmailValid(string email)
	{
		return EmailRegex.IsMatch(email);
	}
}
