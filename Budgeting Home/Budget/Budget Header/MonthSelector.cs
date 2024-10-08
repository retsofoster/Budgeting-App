using Godot;
using System;

public partial class MonthSelector : MenuButton
{
    public int monthNumber = 0;
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
        UpdateMonthText();
    }

    private void OnMonthSelected(long id)
    {
        monthNumber = (int) id;
        // This method will be called when a month is selected
        UpdateMonthText();
    }
    public void UpdateMonthText()
    {
        if(monthNumber < 0)
        {
            monthNumber = 11;
        }
        else if(monthNumber > 11)
        {
            monthNumber = 0;
        }
        Text = months[monthNumber];
        GD.Print($"Selected month: {months[monthNumber]}");
    }
    public void OnNextMonthPressed()
    {
        monthNumber++;
        UpdateMonthText();
    }
    public void OnPreviousMonthPressed()
    {
        monthNumber--;
        UpdateMonthText();
    }
}
