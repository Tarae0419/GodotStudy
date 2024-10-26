using Godot;
using System;

public partial class UpgradeAttack : Button
{
	private int AttackStat;
	private TextEdit AttackText; 
	private PlayerStats PlayerStat;

	public override void _Ready()
	{
		AttackText = GetNode<TextEdit>("../StatText");
		PlayerStat = GetNode<PlayerStats>("../PlayerStat");
		Connect("pressed",new Callable(this, "OnButtonPressed"));
	}

	private void OnButtonPressed()
	{
		switch(Name){
			case "UpgradeAttackButton":
			PlayerStat.UpgradeAttack(3);
			GD.Print("공격력 업그레이드 성공!");
			break;
			case "UpgradeDefenseButton":
			PlayerStat.UpgradeDefense(3);
			GD.Print("방어력 업그레이드 성공!");
			break;
			case "UpgradeHealthButton":
			PlayerStat.UpgradeHealth(5);
			GD.Print("체력 업그레이드 성공!");
			break;
		}
		UpdateStat();
	}

	private void UpdateStat()
	{
		AttackText.Text = $"현재 공격력 : {PlayerStat.GetAttackStat()}\n현재 방어력 : {PlayerStat.GetDefenseStat()}\n현재 체력 : {PlayerStat.GetHealthStat()}";
	}
}
