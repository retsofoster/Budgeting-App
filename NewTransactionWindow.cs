using Godot;
using System;

public partial class NewTransactionWindow : Window
{

	public void OnCancelPressed()
	{
		QueueFree();
	}
	
	public void OnCloseRequested()
	{
		QueueFree();
	}

}
