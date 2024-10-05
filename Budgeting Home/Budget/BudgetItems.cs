using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class BudgetItems : Panel
{
	ScrollContainer scrollContainer;
	VBoxContainer vBoxContainer;

	[Export] PackedScene budgetSection;
	[Export] PackedScene addGroup1;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		BudgetMenu.currentBudget.AddIncome("Paycheck 1", 0);
		vBoxContainer = GetNode<VBoxContainer>("MarginContainer/HBoxContainer/Budget/ScrollContainer/VBoxContainer");
		BudgetCategory budgetSectionAsChild = (BudgetCategory) budgetSection.Instantiate();

		vBoxContainer.AddChild(budgetSectionAsChild);
		LineEdit lineEdit = budgetSectionAsChild.GetNode<LineEdit>("MarginContainer/HBoxContainer/VBoxContainer/Item Name");
		budgetSectionAsChild.itemName.Text = BudgetMenu.currentBudget.Incomes[0].Name;
		GD.Print(BudgetMenu.currentBudget.Incomes[0].Name);
		// INSTEAD USE THE ALREADY ADDED INCOME FROM BUDGETMENU.CS
		// BudgetMenu.currentBudget.Income.Add(new Income()
		// {
		// 	Name = "Paycheck 1",
		// 	Amount = 0,
		// });

		AddGroup addGroupAsChild = (AddGroup) addGroup1.Instantiate();
		vBoxContainer.AddChild(addGroupAsChild);

		// scrollContainer = GetNode<ScrollContainer>("MarginContainer/HBoxContainer/Budget/ScrollContainer");
		//var addGroup = GetNode<AddGroup>("MarginContainer/HBoxContainer/Budget/ScrollContainer/VBoxContainer/Add Group");
		addGroupAsChild.AddGroups += OnAddGroup;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public async void OnAddGroup()
	{
		int num;
		Node childScene = ResourceLoader.Load<PackedScene>("res://Budgeting Home/Budget/Budget Body/budget_section.tscn").Instantiate();
		Node parent = GetNode("MarginContainer/HBoxContainer/Budget/ScrollContainer/VBoxContainer");
		parent.AddChild(childScene);
		GD.Print(parent.GetChildCount());
		num = parent.GetChildCount() - 2;
		childScene.Name = "Budget Section" +num.ToString();
		parent.MoveChild(childScene, num);
		await ToSignal(scrollContainer.GetVScrollBar(), "changed");
		scrollContainer.ScrollVertical = (int)scrollContainer.GetVScrollBar().MaxValue;		
	}	
}
