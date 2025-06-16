using Godot;
using System;

public partial class NewTransaction : Panel
{
	
	public string category;

	[Export] MenuButton menuButton;
	[Export] LineEdit Description;
	[Export] Button IncomeAndExpenseSelector;
	[Export] LineEdit Amount;
	[Export] LineEdit Date;
	PopupMenu popupMenu; 
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Entered Ready");
		popupMenu = menuButton.GetPopup();
		popupMenu.Clear();
		//popupMenu.HideOnCheckableItemSelection = false;
		
		foreach(ExpenseCategory category in BudgetMenu.currentBudget.Categories)
		{
			popupMenu.AddItem(category.Name);
		}
		for(int i = 0; i < popupMenu.ItemCount ;i++)
		{
			popupMenu.SetItemAsRadioCheckable(i, true);
		}
		popupMenu.IndexPressed += OnItemPressed;

		Amount.PlaceholderText = "$0.00";
		Date.Text = DateTime.Now.ToString("yyyy-MM-dd");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
	public void OnMenuButtonAboutToPopup()
	{
		popupMenu.Clear();
		if(IncomeAndExpenseSelector.ButtonPressed)
		{
			foreach(ExpenseCategory category in BudgetMenu.currentBudget.Categories)
			{
				popupMenu.AddSeparator(category.Name);
				foreach(Expense expense in category.Expenses)
				{
					popupMenu.AddItem(expense.Name);
				}
			}
		}
		else
		{
			popupMenu.AddSeparator("Income");
			foreach(Income income in BudgetMenu.currentBudget.Incomes)
			{
				popupMenu.AddItem(income.Name);
			}
		}
	}

	public void OnItemPressed(long index)
	{
		
		category = popupMenu.GetItemText((int) index);
		UnCheckAllItems();
		popupMenu.SetItemChecked(popupMenu.GetItemId((int)index), true);
		GD.Print(category);
		menuButton.Text = category;
	}

	public void UnCheckAllItems()
	{
		for(int i = 0; i < popupMenu.ItemCount ;i++)
		{
			popupMenu.SetItemChecked(i,false);
		}
	}

	public void OnAddTransactionPressed()
	{
		
	}
	public void OnIncomeAndExpenseSelectorPressed(bool Expense)
	{
		Description.PlaceholderText = Expense ? "Where did you spend this money?" : "Where did you earn this money?";
	}

	
}
