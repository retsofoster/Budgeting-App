using Godot;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

public partial class BudgetCategory : Panel
{
	[Signal] public delegate void AddIncomeEventHandler(string source, float amount, string category);
	[Export] public VBoxContainer category;
	[Export] public Label categoryTitle;

	[Export] public PackedScene recieved;
	
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
		//Node parent = GetNode("MarginContainer/HBoxContainer/VBoxContainer");
		AddChildAtLocation(SubCategory.GetScenePath(),category.GetPath(), 4);		
	}
	public void AddChildAtLocation(string childPath, string parentPath, int maxChildren)
	{
		Node parent = GetNode(parentPath);
		int location;
		Node childScene = ResourceLoader.Load<PackedScene>(childPath).Instantiate();
		if(parent.GetChildCount() < maxChildren)
		{
			parent.AddChild(childScene);
			GD.Print(parent.GetChildCount());
			location = parent.GetChildCount() - 2;
			childScene.Name = "Budget Item" +location.ToString();
			parent.MoveChild(childScene, location);
		}
		else
		{
			GD.Print("Group is Full!");
		}
	}
	public void AddChildRemainingAtLocation(string childPath, string parentPath, int maxChildren)
	{
		Node parent = GetNode(parentPath);
		int location;
		Node childScene = ResourceLoader.Load<PackedScene>(childPath).Instantiate();
		if(parent.GetChildCount() < maxChildren)
		{
			parent.AddChild(childScene);
			GD.Print("remaining" +parent.GetChildCount());
			location = parent.GetChildCount() - 2;
			childScene.Name = "Budget Item" +location.ToString();
			parent.MoveChild(childScene, location);
			Label label = childScene.GetNode<Label>(".");
			EmitSignal(SignalName.AddIncome, "Paycheck " +(parent.GetChildCount() - 2), label.Text, "Income");
		}
		else
		{
			GD.Print("Group is Full!");
		}
	}
	public void OnItemNameTextSubmitted(string income)
	{
		
	}
}

