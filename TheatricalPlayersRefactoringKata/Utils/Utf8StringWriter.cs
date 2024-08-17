using System;
using System.Collections.Generic;
using System.IO;

namespace TheatricalPlayersRefactoringKata;

public class Utf8StringWriter : StringWriter
{
    public override System.Text.Encoding Encoding
    {
        get { return new System.Text.UTF8Encoding(false); }
    }
}