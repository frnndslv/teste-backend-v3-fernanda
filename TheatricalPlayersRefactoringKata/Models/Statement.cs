using System;
using System.Collections.Generic;

namespace TheatricalPlayersRefactoringKata;

[Serializable]
public class Statement
{
    private string _customer;
    private List<Item> _items;
    private double _amountOwed;
    private double _earnedCredits;


    public string Customer { get => _customer; set => _customer = value; }
    public List<Item> Items { get => _items; set => _items = value; }
    public double AmountOwed { get => _amountOwed; set => _amountOwed = value; }
    public double EarnedCredits { get => _earnedCredits; set => _earnedCredits = value; }

    public Statement(string customer, List<Item> item, double amountOwed, double earnedCredits)
    {
        this._customer = customer;
        this._items = item;
        this._amountOwed = amountOwed;
        this._earnedCredits = earnedCredits;
    }

    public Statement()
    {

    }

}
