using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM5ResourceEditor
{
    class Resource
    {
        public string ResourceID
        {
            get;
            set;
        }

        public string FilePath
        {
            get;
            set;
        }

        public SResourceHeaderHeader ResourceHeaderHeader
        {
            get;
            set;
        }

        public Dictionary<int, Dictionary<string, long>> Extensions
        {
            get;
            set;
        } = new Dictionary<int, Dictionary<string, long>>();
    }
}
