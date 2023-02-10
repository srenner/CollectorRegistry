using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorRegistry.Shared.Image
{
    public record struct ImageInput
    {


        public string FullPath { get; set; }
        public string Watermark { get; set; }


    }
}
