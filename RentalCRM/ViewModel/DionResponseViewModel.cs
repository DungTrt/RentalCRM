using System.Collections.Generic;

namespace RentalCRM.ViewModel
{
    public class DionResponseViewModel<T>
    {
        public List<T> Data { get; set; }
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
    }
}
