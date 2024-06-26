using I3Lab.Work.Domain.WorkCommentsAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Work.Domain.FileAggregate
{
    public class File
    {
        public FileId Id { get; private set; }

        

        public string Name { get; private set; }
        public FileType Type { get; private set; }
        public string Path { get; private set; }

        private File()
        {
                
        }

        public File(string name, FileType type, string path)
        {
            Id = new FileId(Guid.NewGuid()); 
            Name = name;
            Type = type;
            Path = path;
        }
    }

  
}
