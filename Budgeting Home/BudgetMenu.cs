using Godot;
using System;

public partial class BudgetMenu : Control
{
	
	//BudgetManager budgetManager;
	//BudgetSection budgetSection;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//budgetManager = new BudgetManager();
		//budgetSection = GetNode<BudgetSection>("MarginContainer2/HBoxContainer/Budget/MarginContainer/HBoxContainer/Budget/ScrollContainer/VBoxContainer/Budget Section");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//GD.Print(budgetManager.GetIncomeBySource("Income"));
	}

	public void OnAddIncome(LineEdit lineEdit, string lineEditPath)
	{
		lineEdit = GetNode<LineEdit>(lineEditPath);
		//budgetSection.AddIncome += OnAddIncome;
		//lineEdit.Connect("AddIncome", new Callable(this, nameof(OnAddIncome)));
	}
	public void OnAddIncome(string source, float amount, string category)
	{
		GD.Print("added to budget manager");
		//budgetManager.AddIncome(source, amount, category); 
	}
}
