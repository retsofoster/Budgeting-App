using Godot;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

public partial class BudgetCategory : Panel
{
	[Export] public VBoxContainer category;
	[Export] public SubCategory subCategory;
	[Export] public Label presetCategoryTitle;
	[Export] public PackedScene recieved;
	[Export] public PackedScene subcategory;
	[Export] public Label planned;
	//public string categoryTitle;
	public int maxChildren = 4;
	public string label;
	Label amount;
	public int spent = 0;
	
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public static string GetScenePath()
    {
        return "res://Budgeting Home/Budget/Budget Body/Budget Category/budget_category.tscn";
    }

	public void OnAddSubCategoryPressed()
	{
		if(presetCategoryTitle.Text == "Income")
		{
			label = "Paycheck" +" " +(maxChildren - 2);
			//budgetMenu.currentBudget.
			//amount = (Label) ResourceLoader.Load<PackedScene>(Received.GetScenePath()).Instantiate();
			AddChildAtLocation(SubCategory.GetScenePath(),category.GetPath(), maxChildren, label);
		}else{
			label = "Label";
			//amount = (Label) ResourceLoader.Load<PackedScene>(RemainingAmount.GetScenePath()).Instantiate();
			AddChildAtLocation(SubCategory.GetScenePath(),category.GetPath(), maxChildren, label);
		}
	}
	public void AddChildAtLocation(string childPath, string parentPath, int max, string subtitle)
	{
		BudgetMenu.currentBudget.AddExpenseToCategory(presetCategoryTitle.Text, "Label", 0, 0);
		Node parent = GetNode(parentPath);
		int location;
		SubCategory childScene = (SubCategory) ResourceLoader.Load<PackedScene>(childPath).Instantiate();
		BudgetMenu.currentBudget.AddIncome(subtitle, 0);
		if(parent.GetChildCount() < max)
		{
			parent.AddChild(childScene);

			childScene.categorySubtitle.Text = subtitle;
			childScene.plannedAmount.Text = BudgetMenu.currentBudget.GetIncomeByName(subtitle).Planned.ToString();
			childScene.updatedAmount.Text = BudgetMenu.currentBudget.GetIncomeByName(subtitle).Received.ToString();
			
			GD.Print(parent.GetChildCount());
			
			location = parent.GetChildCount() - 2;
			childScene.Name = "Budget Item" +location.ToString();

			parent.MoveChild(childScene, location);
		}
		else
		{
			GD.Print("Group is Full!");
			maxChildren++;

		}
	}
}

