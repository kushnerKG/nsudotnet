using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Kushner.Nsudotnet.LinesCounter
{
    class Counter
    {
        private readonly Explorer _explorer;
        private Boolean _isMultilineComment;
        private static readonly Regex MultilineRegex = new Regex(@"(/\*).*?(\*/)");
        private static readonly Regex StartMultilineRegex = new Regex(@"(/\*).*");
        private static readonly Regex FinishMultilineRegex = new Regex(@".*?(\*/)");
        private static readonly Regex SingleLineRegex = new Regex(@"(//).*");
        private static readonly Regex QuotesRegex = new Regex("\".*\"");

        public Counter(Explorer exp)
        {
            _explorer = exp;
        }

        public int DoCount()
        {
            int counter = 0;
            foreach (FileInfo fileInfo in _explorer)
            {
                counter += DoWork(File.ReadAllLines(fileInfo.FullName));
            }
            return counter;
        }

        private int DoWork(String[] lines)
        {
            int count = 0;
            _isMultilineComment = false;

            foreach (string s in lines)
            {
                if (Check(s))
                {
                    count++;
                }

            }

            return count;
        }

        private bool Check(String str)
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                str = QuotesRegex.Replace(str, "k");
                if (!_isMultilineComment)
                {
                    str = MultilineRegex.Replace(str, "");
                }
                str = SingleLineRegex.Replace(str, "");

                if (!_isMultilineComment && StartMultilineRegex.IsMatch(str))
                {
                    str = StartMultilineRegex.Replace(str, "", 1);
                    _isMultilineComment = true;
                    flag = true;
                    if (str.Length > 0)
                    {
                        Console.WriteLine(str);
                        return true;
                    }
                }
                else if (_isMultilineComment && FinishMultilineRegex.IsMatch(str))
                {
                    str = FinishMultilineRegex.Replace(str, "", 1);
                    _isMultilineComment = false;
                    flag = true;
                }
            }
            if (str.Length != 0 && !_isMultilineComment)
            {
                Console.WriteLine(str);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
