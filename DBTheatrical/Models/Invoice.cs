using System;
using System.Collections.Generic;

namespace TheatricalPlayersRefactoringKata;

[Serializable]
public class Invoice
{
    private int _id;
    private string _customer;
    private List<Performance> _performances;

    public int Id { get => _id; set { _id = value; } }

    public string Customer { get => _customer; set => _customer = value; }
    public List<Performance> Performances { get => _performances; set => _performances = value; }

    public Invoice(string customer, List<Performance> performance)
    {
        this._customer = customer;
        this._performances = performance;
    }

    public Invoice()
    {

    }

}