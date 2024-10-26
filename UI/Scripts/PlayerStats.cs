using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class PlayerStats : Node
{
	private int Attack { get; set; } = 3;
    private int Defense { get; set; } = 3;
    private int Health { get; set; } = 20;
	private int CurrentCost { get; set; } = 0;

    public void UpgradeAttack(int amount)
	{
		Attack += amount;
	}
	public void UpgradeDefense(int amount)
	{
		Defense += amount;
	}
	public void UpgradeHealth(int amount)
	{
		Health += amount;
	}

	public int GetAttackStat()
	{
		return Attack;
	}
	public int GetDefenseStat()
	{
		return Defense;
	}
	public int GetHealthStat()
	{
		return Health;
	}
}

