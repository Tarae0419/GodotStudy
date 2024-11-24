using Godot;
using System;

public partial class Boss : Node
{
	private int _health;
	private int Health => _health;
	private GameManager _gameManager;
	public override void _Ready()
	{
		_gameManager = GetNode<GameManager>("../../GameManager");
		var currentStageLevel = _gameManager.StageLevel;
		
		_health = 200 + 10 * currentStageLevel;
	}

	public void TakeDamage(int damage)
	{
		_health -= damage;
		GD.Print($"현재 체력 : {_health}");
		
		if (Health <= 0)
		{
			QueueFree();
		}
	}
}
