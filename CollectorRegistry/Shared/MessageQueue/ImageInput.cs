using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorRegistry.Shared.MessageQueue
{
    /// <summary>
    /// Maps to the message queue named image-input
    /// </summary>
    public record struct ImageInput
    {
        public int EntryID { get; set; }

        public string UploadPath { get; set; }
        public string WatermarkText { get; set; }


    }
}
