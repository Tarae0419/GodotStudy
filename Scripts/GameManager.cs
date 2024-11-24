using Godot;
using System;

public partial class GameManager : Node
{
	private PlayerStats _playerData;
	public int StageLevel { get; set; }
	public override void _Ready()
	{
		_playerData = GetNode<PlayerStats>("../Stage/Player/PlayerStat");

		StageLevel = 1;
	}
	
	public Godot.Collections.Dictionary<string, Variant> Save()
	{
		return new Godot.Collections.Dictionary<string, Variant>()
		{
			{"PlayerAttack", _playerData.GetAttackStat() },
			{"PlayerDefense", _playerData.GetDefenseStat()},
			{"PlayerHealth", _playerData.GetHealthStat()}
		};
	}
}
