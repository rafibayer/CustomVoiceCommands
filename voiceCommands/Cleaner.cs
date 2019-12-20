using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voiceCommands
{
    // clean STT input and return
    static class Cleaner
    {
        private static readonly char[] remove = { ' ', '!', '?', ',', '.'  };

        public static String Clean(String input)
        {
            // lowercase and trim whitespace
            input = input.ToLower().Trim();
            StringBuilder output = new StringBuilder();
            
            // remove unwanted characters
            foreach (char c in input)
            {
                if (!remove.Contains(c))
                {
                    output.Append(c);
                }
            }


            return output.ToString();
        }
    }
}
