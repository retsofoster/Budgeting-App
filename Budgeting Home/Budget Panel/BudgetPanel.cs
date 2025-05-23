using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class BudgetPanel : Panel
{
	[Export] ScrollContainer scrollContainer;
	[Export] VBoxContainer vBoxContainer;
	[Export] PackedScene newTransaction;

	[Export] PackedScene budgetCategory;
	[Export] PackedScene addGroup1;
	[Export] PackedScene recievedScene;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//Add initial data
		BudgetMenu.currentBudget.AddIncome("Paycheck 1", 0);
		BudgetMenu.currentBudget.AddCategory("Giving");
		BudgetMenu.currentBudget.AddExpenseToCategory("Giving", "Tithes", 0, 0);
		BudgetMenu.currentBudget.AddCategory("Savings");
		BudgetMenu.currentBudget.AddCategory("Housing");
		BudgetMenu.currentBudget.AddCategory("Transportation");
		BudgetMenu.currentBudget.AddCategory("Food");
		BudgetMenu.currentBudget.AddCategory("Personal");
		BudgetMenu.currentBudget.AddCategory("Lifestyle");
		BudgetMenu.currentBudget.AddCategory("Health");
		BudgetMenu.currentBudget.AddCategory("Insurance");
		

		
		
		//Add a category
		BudgetCategory budgetCategoryAsChild = (BudgetCategory) budgetCategory.Instantiate();
		vBoxContainer.AddChild(budgetCategoryAsChild);
		budgetCategoryAsChild.presetCategoryTitle.Text = "Income";
		//
		SubCategory subcategory = budgetCategoryAsChild.GetNode<SubCategory>("MarginContainer/Category/Sub-Category");

		Received recieved = (Received) recievedScene.Instantiate();
		budgetCategoryAsChild.planned.AddSibling(recieved);
		
		subcategory.category = "Income";
		foreach(var value in BudgetMenu.currentBudget.Incomes)
		{
			subcategory.categorySubtitle.Text = value.Name;
			subcategory.plannedAmount.Text = value.Planned.ToString();
			subcategory.updatedAmount.Text = value.Received.ToString();
		}

		foreach(ExpenseCategory value in BudgetMenu.currentBudget.Categories)
		{
			AddGroup(value, budgetCategoryAsChild);
		}
		
		
		AddGroup addGroupAsChild = (AddGroup) addGroup1.Instantiate();
		vBoxContainer.AddChild(addGroupAsChild);
		addGroupAsChild.AddGroups += OnAddGroup;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Input.IsActionJustPressed("Print Summary"))
		{
			BudgetMenu.currentBudget.PrintSummary();
		}
	}

	public async void OnAddGroup()
	{
		int num;
		
		NameCategory childScene = (NameCategory) ResourceLoader.Load<PackedScene>(NameCategory.GetScenePath()).Instantiate();
		vBoxContainer.AddChild(childScene);
		

		num = vBoxContainer.GetChildCount() - 2;
		vBoxContainer.MoveChild(childScene, num);
		childScene.Name = "Budget Section" +num.ToString();
		await ToSignal(scrollContainer.GetVScrollBar(), "changed");
		scrollContainer.ScrollVertical = (int)scrollContainer.GetVScrollBar().MaxValue;		
	}	

	public void OnNewTransactionPressed(){
		Window child= (Window) newTransaction.Instantiate();
		AddChild(child);
		//newTransaction.Show();
	}

	public void AddGroup(ExpenseCategory category, BudgetCategory budgetCategory)
	{
		BudgetCategory childScene = (BudgetCategory) ResourceLoader.Load<PackedScene>(BudgetCategory.GetScenePath()).Instantiate();
		budgetCategory.AddSibling(childScene);
		childScene.presetCategoryTitle.Text = category.Name;
		//BudgetMenu.currentBudget.AddExpenseToCategory(category.Name, "Label", 0, 0);
		childScene.subCategory.category = category.Name;
		foreach(Expense expense in category.Expenses)
		{
			childScene.subCategory.categorySubtitle.Text = expense.Name;
			childScene.subCategory.plannedAmount.Text = expense.Planned.ToString();
			childScene.subCategory.updatedAmount.Text = expense.Spent.ToString();

			// Received recieved = (Received) recievedScene.Instantiate();
			// budgetCategory.planned.AddSibling(recieved);
		}
	}
}
