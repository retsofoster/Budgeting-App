using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class BudgetPanel : Panel
{
	ScrollContainer scrollContainer;
	[Export] VBoxContainer vBoxContainer;

	[Export] PackedScene budgetCategory;
	[Export] PackedScene addGroup1;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		BudgetMenu.currentBudget.AddIncome("Paycheck 1", 0);
		
		BudgetCategory budgetCategoryAsChild = (BudgetCategory) budgetCategory.Instantiate();
		vBoxContainer.AddChild(budgetCategoryAsChild);
		budgetCategoryAsChild.categoryTitle.Text = "Income";
		

		AddGroup addGroupAsChild = (AddGroup) addGroup1.Instantiate();
		vBoxContainer.AddChild(addGroupAsChild);
		addGroupAsChild.AddGroups += OnAddGroup;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public async void OnAddGroup()
	{
		int num;
		BudgetCategory childScene = (BudgetCategory) ResourceLoader.Load<PackedScene>(BudgetCategory.GetScenePath()).Instantiate();
		vBoxContainer.AddChild(childScene);
		GD.Print(vBoxContainer.GetChildCount());
		num = vBoxContainer.GetChildCount() - 2;
		childScene.Name = "Budget Section" +num.ToString();
		vBoxContainer.MoveChild(childScene, num);
		await ToSignal(scrollContainer.GetVScrollBar(), "changed");
		scrollContainer.ScrollVertical = (int)scrollContainer.GetVScrollBar().MaxValue;		
	}	
}
