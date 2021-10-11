using System.Collections.Generic;

namespace Entities.ModelsDto
{
    public class ReturnKindAndCountDto
    {
        public int CountPage { get; set; } = 1;
        public int CurrentPage { get; set; } = 1;
        public IEnumerable<ReturnKindDto> KindsDto { get; set; }
    }
}
