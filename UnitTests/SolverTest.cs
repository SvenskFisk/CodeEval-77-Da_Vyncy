using System;
using Xunit;
using ClassLibrary1;

namespace UnitTestProject1
{
    public class SolverTest
    {
        [Theory]
        [InlineData(
            "O draconia;conian devil! Oh la;h lame sa;saint!",
            "O draconian devil! Oh lame saint!")]
        [InlineData(
            "m quaerat voluptatem.;pora incidunt ut labore et d;, consectetur, adipisci velit;olore magnam aliqua;idunt ut labore et dolore magn;uptatem.;i dolorem ipsum qu;iquam quaerat vol;psum quia dolor sit amet, consectetur, a;ia dolor sit amet, conse;squam est, qui do;Neque porro quisquam est, qu;aerat voluptatem.;m eius modi tem;Neque porro qui;, sed quia non numquam ei;lorem ipsum quia dolor sit amet;ctetur, adipisci velit, sed quia non numq;unt ut labore et dolore magnam aliquam qu;dipisci velit, sed quia non numqua;us modi tempora incid;Neque porro quisquam est, qui dolorem i;uam eius modi tem;pora inc;am al",
            "Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem.")]
        public void Solve(string input, string expected)
        {
            var target = new Solver();
            var result = target.Solve(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("abc", "def", -1, int.MinValue)]
        [InlineData("abcde", "bcd", 3, 1)]
        [InlineData("bcde", "ab", 1, -1)]
        [InlineData("bcde", "ef", 1, 3)]
        public void FindOverlap(string s, string t, int expectedScore, int expectedOffset)
        {
            int offset;
            var target = new Solver();
            var result = target.FindOverlap(s, t, out offset);

            Assert.Equal(expectedScore, result);
            Assert.Equal(expectedOffset, offset);
        }

        [Theory]
        [InlineData("abcde", "bcd", 1, "abcde")]
        [InlineData("bcde", "ab",-1, "abcde")]
        [InlineData("bcde", "ef", 3, "bcdef")]
        public void Merge(string s, string t, int offset, string expected)
        {
            var target = new Solver();
            var result = target.Merge(s, t, offset);

            Assert.Equal(expected, result);
        }
    }
}
