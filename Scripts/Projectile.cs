using Godot;
using System;
	
public partial class Projectile : Area2D
{
	private int _damage;
	private float _speed;
	private Vector2 _velocity = Vector2.Right;
	private PlayerStats _playerStat;
	public override void _Ready()
	{
		_playerStat = GetNode<PlayerStats>("../PlayerStat");

		_damage = _playerStat.GetAttackStat();
		_speed = 200f;

		Connect("body_entered", Callable.From((Node body) => OnBodyEntered(body)));
	}
	
	public override void _PhysicsProcess(double delta)
	{
		Position += _velocity * _speed * (float)delta;
		
		if (!GetViewportRect().HasPoint(GlobalPosition))
		{
			QueueFree();
		}
	}
	

	private void OnBodyEntered(Node body)
	{
		// 보스와 충돌 시 데미지 처리
		if (body is Boss boss)
		{
			boss.TakeDamage(_damage);
			GD.Print("Projectile hit the Boss!");
			QueueFree(); // 충돌 후 삭제
		}
	}
}
