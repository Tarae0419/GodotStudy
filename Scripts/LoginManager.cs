using Godot;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public partial class LoginManager : Node
{
	private LineEdit _IDEdit;
	private LineEdit _PasswordEdit;
	private LineEdit _CreateIDEdit;
	private LineEdit _CreatePasswordEdit;
	private LineEdit _CreatePasswordEdit2;
	private Button _LoginButton;
	private Button _SignInButton;
	private Button _SignUpButton;
	private Button _CreateButton;
	private Panel _SignInPanel;
	private Panel _SignUpPanel;
	
	private String _startUI = "res://UI/StartUI.tscn";
	
	private static readonly Regex EmailRegex = new Regex(
		@"^[^@\s]+@[^@\s]+\.[^@\s]+$",
		RegexOptions.Compiled
	);

	private Dictionary<string, string> _userDatabase = new Dictionary<string, string>
    {
        { "a@naver.com", "a" },
        { "b@naver.com", "b" },
        { "c@naver.com", "c" }
    };
	
	public override void _Ready()
	{
		_IDEdit = GetNode<LineEdit>("SignInPanel/IDEdit");
		_PasswordEdit = GetNode<LineEdit>("SignInPanel/PWEdit");
		_CreateIDEdit = GetNode<LineEdit>("SignUpPanel/CreateIDEdit");
		_CreatePasswordEdit = GetNode<LineEdit>("SignUpPanel/CreatePWEdit");
		_CreatePasswordEdit2 = GetNode<LineEdit>("SignUpPanel/CreatePWEdit2");
		
		_LoginButton = GetNode<Button>("SignInPanel/LoginButton");
		_SignInButton = GetNode<Button>("SignUpPanel/SignInButton");
		_SignUpButton = GetNode<Button>("SignInPanel/SignUpButton");
		_CreateButton = GetNode<Button>("SignUpPanel/CreateButton");
		
		_SignInPanel = GetNode<Panel>("SignInPanel");
		_SignUpPanel = GetNode<Panel>("SignUpPanel");
		
		_LoginButton.Connect("pressed",Callable.From(Login));
		_SignUpButton.Connect("pressed", Callable.From(ShowSignUpPanel));
		_SignInButton.Connect("pressed", Callable.From(ShowSignInPanel));
		_CreateButton.Connect("pressed", Callable.From(CreateUser));

	}

	private void Login()
	{
		string enteredUsername = _IDEdit.Text;
		string enteredPassword = _PasswordEdit.Text;

		if (CheckLogin(enteredUsername, enteredPassword) && IsEmailValid(enteredUsername))
		{
			_SignInPanel.Hide();
		}
		else if (!IsEmailValid(enteredUsername))
		{
			GD.Print("이메일 형식이 아닙니다");
		}
		else
		{
			GD.Print("아이디 또는 비밀번호을 확인해 주세요");
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

	private void CreateUser()
	{
		string enteredUsername = _CreateIDEdit.Text;
		string enteredPassword = _CreatePasswordEdit.Text;
		string enteredConfirmPassword = _CreatePasswordEdit2.Text;

		if (!IsEmailValid(enteredUsername) && !ConfirmPassword(enteredPassword, enteredConfirmPassword))
		{
			GD.Print("이메일과 비밀번호를 입력해주세요.");
		}
		else if (!IsEmailValid(enteredUsername))
		{
			GD.Print("이메일 형식이 옳바르지 않습니다.");
		}
		else if(!ConfirmPassword(enteredPassword, enteredConfirmPassword))
		{
			GD.Print("입력한 비밀번호가 서로 다릅니다.");
		}
		else
		{
			GD.Print("이메일과 비밀번호를 입력해주세요.");
			GD.Print("생성 완료!");
			_userDatabase.Add(enteredUsername, _CreatePasswordEdit.Text);
			ShowSignInPanel();
		}
	}

	private bool ConfirmPassword(string enteredPassword, string enteredConfirmPassword)
	{
		if (enteredPassword == "" && enteredConfirmPassword == "")
		{
			return false;
		}
		else if (enteredPassword.Equals(enteredConfirmPassword))
		{
			return true;
		}

		return false;
	}
}
