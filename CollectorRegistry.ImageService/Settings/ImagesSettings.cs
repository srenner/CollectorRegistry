using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorRegistry.ImageService.Settings
{
    public class ImagesSettings : IOptions<ImagesSettings>
    {
        /// <summary>
        /// Max W and H px of thumbnail image
        /// </summary>
        public int Thumb { get; set; }
        /// <summary>
        /// Max W and H px of Medium size image (typically mobile)
        /// </summary>
        public int M { get; set; }
        /// <summary>
        /// Max W and H px of Large size image (typically desktop browser)
        /// </summary>
        public int L { get; set; }

        public ImagesSettings Value { get { return this; } }
    }
}
