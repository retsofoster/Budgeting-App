using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class Budget : Panel
{
	ScrollContainer scrollContainer;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		scrollContainer = GetNode<ScrollContainer>("MarginContainer/HBoxContainer/Budget/ScrollContainer");
		var addGroup = GetNode<AddGroup>("MarginContainer/HBoxContainer/Budget/ScrollContainer/VBoxContainer/Add Group");
		addGroup.AddGroups += OnAddGroup;
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
