using Godot;
using System;

public partial class MenuButton : Godot.MenuButton
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetPopup().AddItem("Income");
		//this.GetPopup().Item
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
}
