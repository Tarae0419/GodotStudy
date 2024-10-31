using Godot;
using System;

public partial class GameManager : Node
{
	private PlayerStats PlayerData;
	private CostManager CurrentCost;
	public override void _Ready()
	{
		PlayerData = GetNode<PlayerStats>("../PlayerStat");
		CurrentCost = GetNode<CostManager>("../CostManager");

		var button = GetNode<Button>("../CheckButton");

		button.Connect("pressed", new Callable(this, "Check"));
	}

	public void Check()
	{
		GD.Print($"현재 공격력 : {PlayerData.GetAttackStat()}");
		GD.Print($"현재 잔고 : {CurrentCost.CurrentBalance}");
	}


	public override void _Process(double delta)
	{
	}

	public Godot.Collections.Dictionary<string, Variant> Save()
	{
		return new Godot.Collections.Dictionary<string, Variant>()
		{
			{"PlayerAttack", PlayerData.GetAttackStat() },
			{"PlayerDefense", PlayerData.GetDefenseStat()},
			{"PlayerHealth", PlayerData.GetHealthStat()}
		};
	}
}
