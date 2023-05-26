using System.Collections.Generic;

namespace Cars.Application.Cars.Queries.GetCarList
{
    public class CarListVm
    {
        public IList<CarLookupDto> Cars { get; set; }
    }
}
