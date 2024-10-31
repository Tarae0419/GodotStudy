using Godot;
using System;

public partial class GameManager : Node
{
	private PlayerStats playerData;
	public override void _Ready()
	{
		playerData = GetNode<PlayerStats>("../PlayerStat");

	}

	public override void _Process(double delta)
	{
	}

	public Godot.Collections.Dictionary<string, Variant> Save()
	{
		return new Godot.Collections.Dictionary<string, Variant>()
		{
			{"PlayerAttack", playerData.GetAttackStat() },
			{"PlayerDefense", playerData.GetDefenseStat()},
			{"PlayerHealth", playerData.GetHealthStat()}
		};
	}
}
