using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Solver
    {
        public string Solve(string input)
        {
            var segments = input.Split(';')
                .OrderByDescending(x => x.Length)
                .ToList();

            var solution = segments[0];
            segments.RemoveAt(0);

            while (segments.Count > 0)
            {
                var bestMatch = "";
                var bestScore = 0;
                var bestOffset = 0;

                foreach (var s in segments)
                {
                    int offset;
                    var score = this.FindOverlap(solution, s, out offset);
                    if (score > bestScore)
                    {
                        bestMatch = s;
                        bestScore = score;
                        bestOffset = offset;
                    }
                }

                segments.Remove(bestMatch);
                solution = this.Merge(solution, bestMatch, bestOffset);
            }

            return solution;
        }

        public int FindOverlap(string s, string t, out int offset)
        {
            var bestScore = -1;
            offset = int.MinValue;

            var siMax = s.Length + t.Length - 1;
            for (int si = 0 - t.Length + 1; si < siMax; si++)
            {
                var score = 0;
                var tiMax = t.Length;
                for (int ti = 0; ti < tiMax; ti++)
                {
                    if (si+ti < 0 || si+ti >= s.Length)
                    {
                        continue;
                    }

                    if (s[si+ti] != t[ti])
                    {
                        score = -1;
                        break;
                    }

                    score++;
                }

                if (score > 0 && score > bestScore)
                {
                    bestScore = score;
                    offset = si;
                }
            }

            return bestScore;
        }

        public string Merge(string s, string t, int offset)
        {
            var ret = new StringBuilder();
            for (int si = 0 - t.Length + 1; si < s.Length + t.Length - 1; si++)
            {
                if (si < 0 || si > s.Length - 1)
                {
                    var ti = si - offset;
                    if (ti >= 0 && ti < t.Length)
                    {
                        ret.Append(t[si - offset]);
                    }
                } else
                {
                    ret.Append(s[si]);
                }
            }

            return ret.ToString();
        }
    }
}
