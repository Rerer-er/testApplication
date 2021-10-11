using System.Collections.Generic;

namespace Entities.ModelsDto
{
    public class ReturnProductAndCountDto
    {
        public int CountPage { get; set; } = 1;
        public int CurrentPage { get; set; } = 1;
        public IEnumerable<ReturnProductDto> ProductsDto { get; set; }
    }
}
