using Godot;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public partial class LoginManager : Node
{
	private LineEdit _iDEdit;
	private LineEdit _passwordEdit;
	private LineEdit _createIdEdit;
	private LineEdit _createPasswordEdit;
	private LineEdit _createPasswordEdit2;
	private Button _loginButton;
	private Button _signInButton;
	private Button _signUpButton;
	private Button _createButton;
	private Panel _signInPanel;
	private Panel _signUpPanel;
	
	private String _startUi = "res://UI/StartUI.tscn";
	
	private static readonly Regex EmailRegex = new Regex(
		@"^[^@\s]+@[^@\s]+\.[^@\s]+$",
		RegexOptions.Compiled
	);

	private readonly Dictionary<string, string> _userDatabase = new Dictionary<string, string>
    {
        { "a@naver.com", "a" },
        { "b@naver.com", "b" },
        { "c@naver.com", "c" }
    };
	
	public override void _Ready()
	{
		_iDEdit = GetNode<LineEdit>("SignInPanel/IDEdit");
		_passwordEdit = GetNode<LineEdit>("SignInPanel/PWEdit");
		_createIdEdit = GetNode<LineEdit>("SignUpPanel/CreateIDEdit");
		_createPasswordEdit = GetNode<LineEdit>("SignUpPanel/CreatePWEdit");
		_createPasswordEdit2 = GetNode<LineEdit>("SignUpPanel/CreatePWEdit2");
		
		_loginButton = GetNode<Button>("SignInPanel/LoginButton");
		_signInButton = GetNode<Button>("SignUpPanel/SignInButton");
		_signUpButton = GetNode<Button>("SignInPanel/SignUpButton");
		_createButton = GetNode<Button>("SignUpPanel/CreateButton");
		
		_signInPanel = GetNode<Panel>("SignInPanel");
		_signUpPanel = GetNode<Panel>("SignUpPanel");
		
		_loginButton.Connect("pressed",Callable.From(Login));
		_signUpButton.Connect("pressed", Callable.From(ShowSignUpPanel));
		_signInButton.Connect("pressed", Callable.From(ShowSignInPanel));
		_createButton.Connect("pressed", Callable.From(CreateUser));

	}

	private void Login()
	{
		string enteredUsername = _iDEdit.Text;
		string enteredPassword = _passwordEdit.Text;

		if (CheckLogin(enteredUsername, enteredPassword) && IsEmailValid(enteredUsername))
		{
			_signInPanel.Hide();
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
		_signInPanel.Hide();
		_signUpPanel.Show();
	}
	
	private void ShowSignInPanel()
	{
		_signUpPanel.Hide();
		_signInPanel.Show();
	}
	
	private bool IsEmailValid(string email)
	{
		return EmailRegex.IsMatch(email);
	}

	private void CreateUser()
	{
		string enteredUsername = _createIdEdit.Text;
		string enteredPassword = _createPasswordEdit.Text;
		string enteredConfirmPassword = _createPasswordEdit2.Text;

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
			_userDatabase.Add(enteredUsername, _createPasswordEdit.Text);
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
