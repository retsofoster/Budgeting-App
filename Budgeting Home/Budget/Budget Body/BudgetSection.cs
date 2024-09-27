using Godot;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

public partial class BudgetSection : Panel
{
	[Signal] public delegate void AddIncomeEventHandler(string source, float amount, string category);
	
	public override void _Ready()
	{
	
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnAddIncomePressed()
	{
		//Node parent = GetNode("MarginContainer/HBoxContainer/VBoxContainer");
		AddChildAtLocation("res://Budgeting Home/Budget/Budget Body/item_name.tscn","MarginContainer/HBoxContainer/VBoxContainer", 4);
		AddChildAtLocation("res://Budgeting Home/Budget/Budget Body/planned.tscn","MarginContainer/HBoxContainer/VBoxContainer2", 3);
		AddChildRemainingAtLocation("res://Budgeting Home/Budget/Budget Body/remaining.tscn","MarginContainer/HBoxContainer/VBoxContainer3", 3);
		
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
}

