using Godot;
using System;

public partial class BudgetScreen : MarginContainer
{
	public HBoxContainer container;
	[Export] public PackedScene budget;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		container = GetNode<HBoxContainer>("HBoxContainer");
		Node budgetAsChild = budget.Instantiate();
		container.AddChild(budgetAsChild);
		container.MoveChild(budgetAsChild, 1);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
