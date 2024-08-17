using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml.Linq;

namespace TheatricalPlayersRefactoringKata;

public class StatementPrinter
{
    public string Print(Invoice invoice, Dictionary<string, Play> plays)
    {
        double totalAmount = 0;
        var volumeCredits = 0;
        var result = string.Format("Statement for {0}\n", invoice.Customer);
        CultureInfo cultureInfo = new CultureInfo("en-US");

        foreach (var perf in invoice.Performances)
        {
            var play = plays[perf.PlayId];
            var lines = play.Lines;
            if (lines < 1000) lines = 1000;
            if (lines > 4000) lines = 4000;
            double thisAmount = lines * 10;
            switch (play.Type)
            {
                case "tragedy":
                    thisAmount = calcTragedy(perf, thisAmount);

                    break;
                case "comedy":
                    thisAmount = calcComedy(perf, thisAmount);
                    break;
                case "history":
                    thisAmount = calcHistory(perf, thisAmount);
                    break;
                default:
                    throw new Exception("unknown type: " + play.Type);
            }
            // add volume credits
            volumeCredits += Math.Max(perf.Audience - 30, 0);
            // add extra credit for every ten comedy attendees
            if ("comedy" == play.Type) volumeCredits += (int)Math.Floor((decimal)perf.Audience / 5);

            // print line for this order
            result += String.Format(cultureInfo, "  {0}: {1:C} ({2} seats)\n", play.Name, Convert.ToDecimal(thisAmount / 100), perf.Audience);
            totalAmount += thisAmount;
        }
        result += String.Format(cultureInfo, "Amount owed is {0:C}\n", Convert.ToDecimal(totalAmount / 100));
        result += String.Format("You earned {0} credits\n", volumeCredits);
        return result;
    }

    public string PrintXML(Invoice invoice, Dictionary<string, Play> plays)
    {
        double totalAmount = 0;
        var volumeCredits = 0;
        CultureInfo cultureInfo = new CultureInfo("en-US");


        Statement statement = new Statement();
        statement.Customer = invoice.Customer;
        statement.Items = new List<Item>();


        foreach (var perf in invoice.Performances)
        {
            Item item = new Item();
            int singleItemCreditsEarned = 0;
            var play = plays[perf.PlayId];
            var lines = play.Lines;
            if (lines < 1000) lines = 1000;
            if (lines > 4000) lines = 4000;
            double thisAmount = lines * 10;
            switch (play.Type)
            {
                case "tragedy":
                    thisAmount = calcTragedy(perf, thisAmount);

                    break;
                case "comedy":
                    thisAmount = calcComedy(perf, thisAmount);
                    break;
                case "history":
                    thisAmount = calcHistory(perf, thisAmount);
                    break;
                default:
                    throw new Exception("unknown type: " + play.Type);
            }
            // add volume credits
            volumeCredits += Math.Max(perf.Audience - 30, 0);
            // add extra credit for every ten comedy attendees
            if ("comedy" == play.Type) volumeCredits += (int)Math.Floor((decimal)perf.Audience / 5);

            singleItemCreditsEarned += Math.Max(perf.Audience - 30, 0);
            // add extra credit for every ten comedy attendees
            if ("comedy" == play.Type) singleItemCreditsEarned += (int)Math.Floor((decimal)perf.Audience / 5);

            totalAmount += thisAmount;

            item.AmountOwed = (double)Convert.ToDecimal(thisAmount / 100);
            item.EarnedCredits = singleItemCreditsEarned;
            item.Seats = perf.Audience;
            statement.Items.Add(item);
        }

        statement.AmountOwed = (double)Convert.ToDecimal(totalAmount / 100);
        statement.EarnedCredits = volumeCredits;

        System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(statement.GetType());
        using (StringWriter textWriter = new Utf8StringWriter())
        {
            x.Serialize(textWriter, statement);
            return textWriter.ToString();
        }
    }

    public double calcComedy(Performance perf, double thisAmount)
    {
        if (perf.Audience > 20)
        {
            thisAmount += 10000 + 500 * (perf.Audience - 20);
        }
        thisAmount += 300 * perf.Audience;

        return thisAmount;
    }
    public double calcTragedy(Performance perf, double thisAmount)
    {
        if (perf.Audience > 30)
        {
            thisAmount += 1000 * (perf.Audience - 30);
        }
        return thisAmount;
    }
    public double calcHistory(Performance perf, double thisAmount)
    {
        return calcTragedy(perf, thisAmount) + calcComedy(perf, thisAmount);
    }

}
