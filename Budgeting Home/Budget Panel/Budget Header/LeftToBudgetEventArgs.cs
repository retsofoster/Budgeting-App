using System;


public class LeftToBudgetEventArgs : EventArgs
{
    public float Amount { get; }

    public LeftToBudgetEventArgs(float amount)
    {
        Amount = amount;
    }
}
