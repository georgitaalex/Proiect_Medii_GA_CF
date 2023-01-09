using System.Collections;
using System.Collections.Generic;

namespace WEB.Models.ViewModels
{
    public class LocatieIndexData
    {
        public IEnumerable<Locatie> Locatii { get; set; }

        public IEnumerable<Sport> Sporturi { get; set; }
    }
}
