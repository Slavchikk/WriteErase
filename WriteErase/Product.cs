//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WriteErase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.OrderProduct = new HashSet<OrderProduct>();
        }
    
        public int ProductArticleNumberID { get; set; }
        public string ProductArticleNumber { get; set; }
        public string ProductName { get; set; }
        public int UnitsID { get; set; }
        public decimal ProductCost { get; set; }
        public Nullable<byte> ProductDiscountAmountMax { get; set; }
        public int ProductManufacturerID { get; set; }
        public int ProductSupplierID { get; set; }
        public int ProductCategoryID { get; set; }
        public Nullable<byte> ProductDiscountAmount { get; set; }
        public int ProductQuantityInStock { get; set; }
        public string ProductDescription { get; set; }
        public string ProductPhoto { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderProduct> OrderProduct { get; set; }
        public virtual ProductManufacturer ProductManufacturer { get; set; }
        public virtual ProductSupplier ProductSupplier { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual Units Units { get; set; }
    }
}
