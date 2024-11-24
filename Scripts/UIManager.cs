using Godot;
using System;

public partial class UIManager : Node
{
	private PlayerStats _playerData;
	private CostManager _costManager;
	private UpgradeManager _upgradeManager;
	private Panel _upgradePanel;
	private Panel _selectPanel;
	private Panel _statPanel;
	private Control _incomeScene;
	public override void _Ready()
	{
		_playerData = GetNode<PlayerStats>("../Stage/Player/PlayerStat");
		_costManager = GetNode<CostManager>("../CostManager");
		_upgradeManager = GetNode<UpgradeManager>("../UpgradeManager");
		_upgradePanel = GetNode<Panel>("../UpgradePanel");
		_selectPanel = GetNode<Panel>("../SelectPanel");
		_statPanel = GetNode<Panel>("../StatPanel");
		_incomeScene = GetNode<Control>("../Income");

		var button = GetNode<Button>("../CheckButton");
		var attackButton = GetNode<Button>("../UpgradePanel/UpgradeAttackButton");
		var defenseButton = GetNode<Button>("../UpgradePanel/UpgradeDefenseButton");
		var healthButton = GetNode<Button>("../UpgradePanel/UpgradeHealthButton");
		var statButton = GetNode<Button>("../SelectPanel/StatButton");
		var updateButton = GetNode<Button>("../SelectPanel/UpdateButton");
		var incomeButton = GetNode<Button>("../SelectPanel/IncomeButton");

		button.Connect("pressed",Callable.From(Check));
        attackButton.Connect("pressed", new Callable(_upgradeManager, "OnAttackButtonPressed"));
		defenseButton.Connect("pressed", new Callable(_upgradeManager, "OnDefenseButtonPressed"));
		healthButton.Connect("pressed", new Callable(_upgradeManager, "OnHealthButtonPressed"));
		statButton.Connect("pressed",Callable.From(SetStatPanel));
		updateButton.Connect("pressed",Callable.From(SetUpgradePanel));
	}

	private void Check()
	{
		GD.Print($"현재 공격력 : {_playerData.GetAttackStat()}");
		GD.Print($"현재 잔고 : {_costManager.CurrentBalance}");
	}
	private void SetStatPanel()
	{
		_statPanel.Show();
		_upgradePanel.Hide();
	}
	private void SetUpgradePanel()
	{
		_upgradePanel.Show();
		_statPanel.Hide();
	}

	private void SetIncomePanel()
	{
		
	}
	
}
