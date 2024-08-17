using System;
using System.Collections.Generic;

namespace TheatricalPlayersRefactoringKata;

[Serializable]
public class Item
{
    private double _amountOwed;
    private double _earnedCredits;
    private int _seats;


    public double AmountOwed { get => _amountOwed; set => _amountOwed = value; }
    public double EarnedCredits { get => _earnedCredits; set => _earnedCredits = value; }
    public int Seats { get => _seats; set => _seats = value; }

    public Item(double amountOwed, double earnedCredits, int seats)
    {
        this._amountOwed = amountOwed;
        this._earnedCredits = earnedCredits;
        this._seats = seats;
    }

    public Item()
    {

    }

}
