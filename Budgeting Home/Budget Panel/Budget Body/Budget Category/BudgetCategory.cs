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

	private Node parent;
	//public string categoryTitle;
	public int maxChildren = 4;
	public string label;
	Label amount;
	public int spent = 0;

	public override void _Ready()
	{
		parent = GetNode(category.GetPath());
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public static string GetScenePath()
	{
		return "res://Budgeting Home/Budget Panel/Budget Body/Budget Category/budget_category.tscn";
	}

	public void OnAddSubCategoryPressed()
	{
		if (parent.GetChildCount() < maxChildren)
		{
			if (presetCategoryTitle.Text == "Income")
			{
				label = "Paycheck" + " " + (maxChildren - 2);
				AddChildAtLocation(SubCategory.GetScenePath(), maxChildren, label);
			}
			else
			{
				label = "Label";
				AddChildAtLocation(SubCategory.GetScenePath(), maxChildren, label);
			}
		}
		else
		{
			GD.Print("Group is Full!");
			maxChildren++;

		}
	}
	public void AddChildAtLocation(string childPath, int max, string subtitle)
	{
		if (presetCategoryTitle.Text == "Income")
		{
			BudgetMenu.currentBudget.AddIncome(subtitle, 0f);
		}
		else
		{
			BudgetMenu.currentBudget.AddExpenseToCategory(presetCategoryTitle.Text, "Label", 0, 0);
		}
		int location;
		SubCategory childScene = (SubCategory)ResourceLoader.Load<PackedScene>(childPath).Instantiate();

		parent.AddChild(childScene);

		childScene.categorySubtitle.Text = subtitle;
		childScene.plannedAmount.Text = BudgetMenu.currentBudget.GetIncomeByName(subtitle).Planned.ToString();
		childScene.updatedAmount.Text = BudgetMenu.currentBudget.GetIncomeByName(subtitle).Received.ToString();

		GD.Print(parent.GetChildCount());

		location = parent.GetChildCount() - 2;
		childScene.Name = "Budget Item" + location.ToString();

		parent.MoveChild(childScene, location);


	}

	// public void SetUpdatedAmount()
	// {
	// 	(SubCategory) childScene.updatedAmount.Text = expense.Spent.ToString();
	// }
	
}

