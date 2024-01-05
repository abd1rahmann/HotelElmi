using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi
{
    public class NameService
    {

        public string GetName(int id)
        {
            return $"Hello-{id}";
        }
    }
}
