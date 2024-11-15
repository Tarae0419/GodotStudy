using Godot;
using System;

public partial class UIManager : Node
{
	private PlayerStats playerData;
	private CostManager costManager;
	private UpgradeManager upgradeManager;
	private Panel upgradePanel;
	private Panel selectPanel;
	private Panel statPanel;
	private Control IncomeScene;
	public override void _Ready()
	{
		playerData = GetNode<PlayerStats>("../PlayerStat");
		costManager = GetNode<CostManager>("../CostManager");
		upgradeManager = GetNode<UpgradeManager>("../UpgradeManager");
		upgradePanel = GetNode<Panel>("../UpgradePanel");
		selectPanel = GetNode<Panel>("../SelectPanel");
		statPanel = GetNode<Panel>("../StatPanel");
		IncomeScene = GetNode<Control>("../Income");

		var button = GetNode<Button>("../CheckButton");
		var AttackButton = GetNode<Button>("../UpgradePanel/UpgradeAttackButton");
		var DefenseButton = GetNode<Button>("../UpgradePanel/UpgradeDefenseButton");
		var HealthButton = GetNode<Button>("../UpgradePanel/UpgradeHealthButton");
		var StatButton = GetNode<Button>("../SelectPanel/StatButton");
		var UpdateButton = GetNode<Button>("../SelectPanel/UpdateButton");
		var IncomeButton = GetNode<Button>("../SelectPanel/IncomeButton");

		button.Connect("pressed",Callable.From(Check));
        AttackButton.Connect("pressed", new Callable(upgradeManager, "OnAttackButtonPressed"));
		DefenseButton.Connect("pressed", new Callable(upgradeManager, "OnDefenseButtonPressed"));
		HealthButton.Connect("pressed", new Callable(upgradeManager, "OnHealthButtonPressed"));
		StatButton.Connect("pressed",Callable.From(SetStatPanel));
		UpdateButton.Connect("pressed",Callable.From(SetUpgradePanel));
	}

	private void Check()
	{
		GD.Print($"현재 공격력 : {playerData.GetAttackStat()}");
		GD.Print($"현재 잔고 : {costManager.CurrentBalance}");
	}
	private void SetStatPanel()
	{
		statPanel.Show();
		upgradePanel.Hide();
	}
	private void SetUpgradePanel()
	{
		upgradePanel.Show();
		statPanel.Hide();
	}

	private void SetIncomePanel()
	{
		
	}
	
}
