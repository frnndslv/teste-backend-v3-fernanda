using System;

namespace TheatricalPlayersRefactoringKata;

[Serializable]
public class Performance
{
    private int _id;
    private string _playId;
    private int? _audience;

    public int Id { get => _id; set { _id = value; } }
    public string PlayId { get => _playId; set => _playId = value; }
    public int? Audience { get => _audience; set => _audience = value; }

    public Performance(string playID, int audience)
    {
        this._playId = playID;
        this._audience = audience;
    }

    public Performance()
    {

    }

}
