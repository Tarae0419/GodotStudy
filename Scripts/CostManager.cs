using Godot;
using System;

public partial class CostManager : Node
{
	private TextEdit CurrentCostText;
	public int CurrentBalance { get; set; }
	private int IncreaseRate { get; set;} = 5;
	public double Time;
    public override void _Ready()
    {
        CurrentCostText = GetNode<TextEdit>("../CurrentCost");
    }
    public override void _Process(double delta)
    {
        Time += delta;

		if(Time >= 0.25)
		{
			CurrentBalance += IncreaseRate;
		CurrentCostText.Text = $"잔고 : {CurrentBalance}";

		Time = 0;
		}		
    }

}
