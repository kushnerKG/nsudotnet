using System;
using System.IO;

namespace Kushner.Nsudotnet.LinesCounter
{
    class Counter
    {
        private readonly Explorer _explorer;
       
        public Counter(Explorer exp)
        {
            _explorer = exp;
        }

        public int DoCount()
        {
            int counter = 0;
            int k = 0;
            foreach (FileInfo fileInfo in _explorer)
            {
                StreamReader sr = new StreamReader(fileInfo.OpenRead());
                counter += DoWork(sr);
                k++;
            }
            return counter;
        }

        private int DoWork(StreamReader sr)
        {
            int count = 0;
            bool isLinesComment = false, isMultilineComment = false, slash = false, star = false;
            
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                int localCounter = 0;
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '/')
                    {
                        if (slash)
                        {
                            isLinesComment = true;
                        }
                        else
                        {
                            slash = true;
                        }
                        if (star)
                        {
                            isMultilineComment = false;
                            slash = false;
                        }
                    }
                    else if (line[i] == '*')
                    {
                        if (slash)
                        {
                            isMultilineComment = true;
                        }
                        else
                        {
                            star = true;
                        }
                    }
                    else
                    {
                        if (slash || star)
                        {
                            localCounter++;
                        }
                        slash = false;
                        star = false;
                    }
                    
                    if (!isMultilineComment && !isLinesComment && !slash && !star)
                    {
                        localCounter++;
                    }
                }
                if (!isMultilineComment && !isLinesComment && (localCounter > 0))
                {
                    count++;
                }
                isLinesComment = false;
                
            }
            return count;
        }   
    }
}
