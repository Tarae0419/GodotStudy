using Godot;

public partial class UpgradeManager : Node
{
	private int _attackStat;
	private Label _attackText; 
	private PlayerStats _playerStat;

	public override void _Ready()
	{
		_attackText = GetNode<Label>("../StatPanel/StatText");
		_playerStat = GetNode<PlayerStats>("../Stage/Player/PlayerStat");
	}
	public void OnAttackButtonPressed()
	{
		_playerStat.UpgradeAttack(3);
		UpdateStat();
	}
	public void OnDefenseButtonPressed()
	{
		_playerStat.UpgradeDefense(3);
		UpdateStat();
	}
	public void OnHealthButtonPressed()
	{
		_playerStat.UpgradeHealth(5);
		UpdateStat();
	}
	private void UpdateStat()
	{
		_attackText.Text = 	$"현재 공격력 : {_playerStat.GetAttackStat()}\n" +
							$"현재 방어력 : {_playerStat.GetDefenseStat()}\n" +
							$"현재 체력 : {_playerStat.GetHealthStat()}\n" +
							$"현재 라운드 : ";
	}
}
