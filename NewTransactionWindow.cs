using Godot;
using System;

public partial class NewTransactionWindow : Window
{
	public string category;

	[Export] MenuButton menuButton;
	PopupMenu popupMenu; 
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
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
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void OnCancelPressed()
	{
		QueueFree();
	}
	public void OnMenuButtonAboutToPopup()
	{
	}

	public void OnItemPressed(long index)
	{
		
		category = popupMenu.GetItemText((int) index);
		UnCheckAllItems();
		popupMenu.SetItemChecked(popupMenu.GetItemId((int)index), true);
		GD.Print(category);
	}

	public void UnCheckAllItems()
	{
		for(int i = 0; i < popupMenu.ItemCount ;i++)
		{
			popupMenu.SetItemChecked(i,false);
		}
	}
}
