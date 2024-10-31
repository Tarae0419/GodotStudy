using Godot;
using System;

public partial class UIManager : Node
{
	private PlayerStats playerData;
	private CostManager costManager;
	private UpgradeManager upgradeManager;
	public override void _Ready()
	{
		playerData = GetNode<PlayerStats>("../PlayerStat");
		costManager = GetNode<CostManager>("../CostManager");
		upgradeManager = GetNode<UpgradeManager>("../UpgradeManager");

		var button = GetNode<Button>("../CheckButton");
		var AttackButton = GetNode<Button>("../UpgradeAttackButton");
		var DefenseButton = GetNode<Button>("../UpgradeDefenseButton");
		var HealthButton = GetNode<Button>("../UpgradeHealthButton");

		button.Connect("pressed", new Callable(this, "Check"));
        AttackButton.Connect("pressed", new Callable(upgradeManager, "OnAttackButtonPressed"));
		DefenseButton.Connect("pressed", new Callable(upgradeManager, "OnDefenseButtonPressed"));
		HealthButton.Connect("pressed", new Callable(upgradeManager, "OnHealthButtonPressed"));

	}

	public void Check()
	{
		GD.Print($"현재 공격력 : {playerData.GetAttackStat()}");
		GD.Print($"현재 잔고 : {costManager.CurrentBalance}");
	}
}
