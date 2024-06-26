using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Work.Domain.FileAggregate
{
    public class File
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public FileType Type { get; private set; }
        public string Path { get; private set; }

        public File(Guid id, string name, FileType type, string path)
        {
            Id = id;
            Name = name;
            Type = type;
            Path = path;
        }
    }

  
}
