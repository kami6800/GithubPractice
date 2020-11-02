using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    public partial class OrderDetails : ObservableObject
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { 
            get { return _unitPrice; }
            set
            {
                _unitPrice = value;
                //TotalPrice = Quantity * value;
                RaisePropertyChanged("UnitPrice");
                RaisePropertyChanged("TotalPrice");
            }
        }
        private decimal _unitPrice;
        public short Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                    //TotalPrice = _unitPrice * value;
                    RaisePropertyChanged("Quantity");
                    RaisePropertyChanged("TotalPrice");
            }
        }
        public short _quantity;
        public float Discount { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Products Product { get; set; }

        [NotMapped]
        public decimal TotalPrice
        {
            get
            {
                return UnitPrice * Quantity;
            }
        }
    }
}
