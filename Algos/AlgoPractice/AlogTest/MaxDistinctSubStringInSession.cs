using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos.AlogTest
{
    public static class MaxDistinctSubstringLengthInSessions
    {

        /*
         * Complete the 'maxDistinctSubstringLengthInSessions' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts STRING sessionString as parameter.
         */

        public static int maxDistinctSubstringLengthInSessions(string sessionString)
        {
            if (string.IsNullOrEmpty(sessionString)) return 0;

            // Split into sessions by '*'
            string[] sessions = sessionString.Split('*');
            int maxLen = 0;

            foreach (var session in sessions)
            {
                maxLen = Math.Max(maxLen, LongestDistinctSubstring(session));
            }

            return maxLen;
        }

        private static int LongestDistinctSubstring(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            Dictionary<char, int> lastSeen = new Dictionary<char, int>();
            int maxLen = 0;
            int start = 0;

            for (int end = 0; end < s.Length; end++)
            {
                char c = s[end];

                if (lastSeen.ContainsKey(c) && lastSeen[c] >= start)
                {
                    // Move start right after the duplicate
                    start = lastSeen[c] + 1;
                }

                lastSeen[c] = end;
                maxLen = Math.Max(maxLen, end - start + 1);
            }

            return maxLen;
        }
    }
}
