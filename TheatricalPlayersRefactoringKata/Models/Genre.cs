using TheatricalPlayersRefactoringKata;

public class Genre
{

    private double _thisAmount;

    private Performance _performance;



    public Performance Performance { get => _performance; set => _performance = value; }

    public double ThisAmount { get => _thisAmount; set => _thisAmount = value; }


    public Genre(Performance performance, double thisAmount)
    {
        this._thisAmount = thisAmount;
        this._performance = performance;

    }

    public Genre()
    {

    }
    public double CalcComedyAmount()
    {
        double amount = _thisAmount;
        if (this._performance.Audience > 20)
        {
            amount += 10000 + 500 * (this._performance.Audience - 20);
        }
        amount += 300 * this._performance.Audience;

        return amount;
    }
    public double CalcTragedyAmount()
    {
        double amount = _thisAmount;
        if (this._performance.Audience > 30)
        {
            amount += 1000 * (this._performance.Audience - 30);
        }
        return amount;
    }
    public double CalcHistoryAmount()
    {
        return CalcComedyAmount() + CalcTragedyAmount();
    }

}
