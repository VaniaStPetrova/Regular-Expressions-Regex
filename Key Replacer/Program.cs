﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Key_Replacer
{
    class Key_Replacer
    {
        static void Main(string[] args)
        {
           var key = Console.ReadLine();
            var text = Console.ReadLine();

            var keysPattern = @"^(?<startKey>[a-zA-Z]*)(?:\<|\||\\)(?:.+)(?:\<|\||\\)(?<endKey>[a-zA-Z]*)$";

            var keyMatch = Regex.Match(key, keysPattern);

            if (keyMatch.Success)
            {
                var startKey = keyMatch.Groups["startKey"].Value;
                var endKey = keyMatch.Groups["endKey"].Value;

                var textPattern = "{startKey}(?<word>.*?){endKey}";
                var matches = Regex.Matches(text, textPattern);

                var result = new StringBuilder();

                foreach (Match match in matches)
                {
                    result.Append(match.Groups["word"].Value);
                }

                Console.WriteLine(result.ToString().Length == 0 ? "Empty result" : result.ToString());
            }
        }
    }
}
