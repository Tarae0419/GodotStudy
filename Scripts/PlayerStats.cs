using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class PlayerStats : Node
{
	private int Attack { get; set; } = 3;
	private int AttackLevel {get; set;} = 1;
    private int Defense { get; set; } = 3;
	private int DefenseLevel {get; set;} = 1;
    private int Health { get; set; } = 20;
	private int HealthLevel {get; set;} = 1;

	public void UpgradeAttack(int amount)
	{
		Attack += amount;
		AttackLevel += 1;
	}
	public void UpgradeDefense(int amount)
	{
		Defense += amount;
		DefenseLevel += 1;
	}
	public void UpgradeHealth(int amount)
	{
		Health += amount;
		HealthLevel += 1;
	}

	public int GetAttackStat()
	{
		return Attack;
	}
	public int GetAttackLevel()
	{
		return AttackLevel;
	}
	public int GetDefenseStat()
	{
		return Defense;
	}
	public int GetDefenseLevel()
	{
		return DefenseLevel;
	}
	public int GetHealthStat()
	{
		return Health;
	}
	public int GetHealthLevel()
	{
		return HealthLevel;
	}
}

