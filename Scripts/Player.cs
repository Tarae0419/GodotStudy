using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public PackedScene ProjectileScene { get; set; } 
	public float ThrowInterval { get; set; } = 2.0f;
	
	private float _throwTimer = 0;

	public override void _Ready()
	{
		ProjectileScene = GD.Load<PackedScene>("res://Prefabs/Projectile.tscn");
	}
	public override void _PhysicsProcess(double delta)
	{
		_throwTimer += (float)delta;
		if (_throwTimer >= ThrowInterval)
		{
			ThrowProjectile();
			_throwTimer = 0;
		}
	}
	
	private void ThrowProjectile()
	{
		if (ProjectileScene == null)
		{
			GD.PrintErr("ProjectileScene is not assigned!");
			return;
		}
		
		Node2D projectile = (Node2D)ProjectileScene.Instantiate();
		AddChild(projectile);
		
		projectile.GlobalPosition = Position;
	}
}
