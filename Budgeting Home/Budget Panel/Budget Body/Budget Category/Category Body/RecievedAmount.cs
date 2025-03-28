using Godot;
using System;

public partial class RecievedAmount : Label
{
	public string text;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Text = text;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public static string GetScenePath()
    {
        return "res://Budgeting Home/Budget/Budget Body/Budget Category/Category Body/recieved_amount.tscn";
    }
}
