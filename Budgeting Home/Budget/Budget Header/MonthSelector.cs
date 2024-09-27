using Godot;
using System;

public partial class MonthSelector : MenuButton
{
    private string[] months = new string[]
    {
        "January", "February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November", "December"
    };

    public override void _Ready()
    {
        // Add each month to the PopupMenu
        GetPopup().IdPressed += OnMonthSelected;
        for (int i = 0; i < months.Length; i++)
        {
            var popup = GetPopup();
            popup.AddItem(months[i], i); // AddItem(string label, int id)
        }
    }

    private void OnMonthSelected(long id)
    {
        // This method will be called when a month is selected
        GD.Print($"Selected month: {months[id]}");
    }
}
