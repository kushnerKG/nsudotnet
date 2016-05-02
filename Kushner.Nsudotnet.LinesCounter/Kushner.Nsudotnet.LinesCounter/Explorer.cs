using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Kushner.Nsudotnet.LinesCounter
{
    class Explorer : IEnumerator, IEnumerable
    {
        private readonly Queue<FileInfo> _files = new Queue<FileInfo>();
        private readonly Queue<DirectoryInfo> _directories = new Queue<DirectoryInfo>();
        private FileInfo _current;
        private readonly String _extension;

        public Explorer(DirectoryInfo dir, String extension)
        {
            _extension = extension;
            foreach (DirectoryInfo tmp in dir.GetDirectories())
            {
                _directories.Enqueue(tmp);
            }

            foreach (FileInfo tmp in dir.GetFiles(extension))
            {
                _files.Enqueue(tmp);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        public bool MoveNext()
        {
            if (_directories.Count == 0 && _files.Count == 0)
            {
                _current = null;
                return false;
            }
            if (_files.Count == 0 && _directories.Count != 0)
            {
                while (_files.Count == 0 && _directories.Count != 0)
                {
                    DirectoryInfo directory = _directories.Dequeue();
                    foreach (DirectoryInfo tmp in directory.GetDirectories())
                    {
                        _directories.Enqueue(tmp);
                    }

                    foreach (FileInfo tmp in directory.GetFiles(_extension))
                    {
                        _files.Enqueue(tmp);
                    }

                    if (_files.Count != 0)
                    {
                        _current = _files.Dequeue();
                        return true;
                    }
                    if (_directories.Count == 0 && _files.Count == 0)
                    {
                        _current = null;
                        return false;
                    }        

                }
            }
            else if (_files.Count != 0)
            {
                _current = _files.Dequeue();
            }

            return true;
        }

        public void Reset()
        {
            _current = null;
        }

        public object Current
        {
            get
            {
                return _current;
            }
        }
    }
}
