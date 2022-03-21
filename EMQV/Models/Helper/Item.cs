using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMQV.Models.Master
{
    public partial class Item
    {
        [NotMapped]
        public bool IsAvailableInput
        {
            get => this.IsAvailable.GetValueOrDefault();
            set { this.IsAvailable = value; }
        }
        [NotMapped]
        public bool IsActiveInput
        {
            get => this.IsActive.GetValueOrDefault();
            set { this.IsActive = value; }
        }
        [NotMapped]
        public bool IsBuyableInput
        {
            get => this.IsBuyable.GetValueOrDefault();
            set { this.IsBuyable = value; }
        }
    }
}
