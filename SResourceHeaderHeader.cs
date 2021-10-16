using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM5ResourceEditor
{
    struct SResourceHeaderHeader
    {
        public string type;
        public uint referencesChunkSize;
        public uint statesChunkSize;
        public uint dataSize;
        public uint systemMemoryRequirement;
        public uint videoMemoryRequirement;
    }
}
