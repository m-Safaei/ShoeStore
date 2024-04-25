using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeStore.Domain.DTOs.SiteSide.Order
{
    public class InvoiceSiteSideViewModel
    {
        #region proeprties

        public Domain.Entities.Order.Order Order { get; set; }
        public List<InvoiceOrderDetailSiteSideViewModel> InvoiceOrderItem { get; set; }      
        public bool IsReturend { get; set; }


        #endregion
    }
    public class InvoiceOrderDetailSiteSideViewModel
    {
        public int OrderDetailID { get; set; }
        public int Count { get; set; }
        public InvoiceProductSiteSideViewModel Product { get; set; }
        public InvoiceSizeSiteSideViewModel InvoiceSize { get; set; }
    }

    public class InvoiceProductSiteSideViewModel
    {
        public int ProductId { get; set; }

        public string ProductTitle { get; set; }

        public string ProductImage { get; set; }

        public decimal Price { get; set; }
    }

    public class InvoiceSizeSiteSideViewModel
    {
        public float SizeId { get; set; }
    }
}
