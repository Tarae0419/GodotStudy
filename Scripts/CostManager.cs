using Godot;
using System;

public partial class CostManager : Node
{
	private TextEdit _currentCostText;
	public int CurrentBalance { get; set; }
	private int IncreaseRate { get; set;} = 5;
	public double Time;
    public override void _Ready()
    {
        _currentCostText = GetNode<TextEdit>("../CurrentCost");
    }
    public override void _Process(double delta)
    {
        Time += delta;

		if(Time >= 0.25)
		{
			CurrentBalance += IncreaseRate;
		_currentCostText.Text = $"잔고 : {CurrentBalance}";

		Time = 0;
		}		
    }

	public int UpgradeCost(int level)
	{
		var cost = 500 + level * 25;

		return cost;
	}

}
