using Godot;

public partial class UpgradeManager : Node
{
	private int AttackStat;
	private Label AttackText; 
	private PlayerStats PlayerStat;

	public override void _Ready()
	{
		AttackText = GetNode<Label>("../StatPanel/StatText");
		PlayerStat = GetNode<PlayerStats>("../PlayerStat");
	}
	public void OnAttackButtonPressed()
	{
		PlayerStat.UpgradeAttack(3);
		UpdateStat();
	}
	public void OnDefenseButtonPressed()
	{
		PlayerStat.UpgradeDefense(3);
		UpdateStat();
	}
	public void OnHealthButtonPressed()
	{
		PlayerStat.UpgradeHealth(5);
		UpdateStat();
	}
	private void UpdateStat()
	{
		AttackText.Text = 	$"현재 공격력 : {PlayerStat.GetAttackStat()}\n" +
							$"현재 방어력 : {PlayerStat.GetDefenseStat()}\n" +
							$"현재 체력 : {PlayerStat.GetHealthStat()}\n" +
							$"현재 라운드 : ";
	}
}
