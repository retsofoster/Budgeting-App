using Godot;
using System;

public partial class LeftToBudget : Label
{
	Color red = new Color(1, 0, 0, 1);
	Color green = new Color(0, 1, 0, 1);
	Color white = new Color(1, 1, 1, 1); 

	public override void _Ready()
	{
		BudgetMenu.currentBudget.BudgetUpdated += UpdateLeftToBudget;
		//AddThemeColorOverride("font_color", new Color(1, 0, 0));

	}

	public override void _Process(double delta)
	{
		
		LabelSettings.FontColor = red;
	}

	private void UpdateLeftToBudget(object sender, LeftToBudgetEventArgs e)
	{
		if (e.Amount > 0)
		{
			LabelSettings.FontColor = white;
		}
		else if (e.Amount == 0)
		{
			LabelSettings.FontColor = green;
		}
		else
		{
			LabelSettings.FontColor = red;
		}
		Text = e.Amount.ToString();
	}
}
	

