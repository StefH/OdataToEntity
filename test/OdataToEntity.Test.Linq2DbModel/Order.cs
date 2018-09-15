//---------------------------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated by T4Model template for T4 (https://github.com/linq2db/t4models).
//    Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//---------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

using LinqToDB;
using LinqToDB.DataProvider.SqlServer;
using LinqToDB.Mapping;
using OdataToEntity.Linq2Db;
using System.ComponentModel;

namespace OdataToEntity.Test.Model
{
	/// <summary>
	/// Database       : OdataToEntity
	/// Data Source    : .\sqlexpress
	/// Server Version : 12.00.5203
	/// </summary>
	public partial class OdataToEntityDB : LinqToDB.Data.DataConnection, IOeLinq2DbDataContext
    {
        public ITable<Category>                Categories              { get { return this.GetTable<Category>(); } }
        public ITable<Customer>                Customers               { get { return this.GetTable<Customer>(); } }
        public ITable<ManyColumns>             ManyColumns             { get { return this.GetTable<ManyColumns>(); } }
        public ITable<Order>                   Orders                  { get { return this.GetTable<Order>(); } }
		public ITable<OrderItem>               OrderItems              { get { return this.GetTable<OrderItem>(); } }
        public ITable<ShippingAddress>         ShippingAddresses       { get { return this.GetTable<ShippingAddress>(); } }
        public ITable<CustomerShippingAddress> CustomerShippingAddress { get { return this.GetTable<CustomerShippingAddress>(); } }

        OeLinq2DbDataContext IOeLinq2DbDataContext.DataContext
        {
            get;
            set;
        }

		public OdataToEntityDB()
			: base("SqlServer", @"Server=.\sqlexpress;Initial Catalog=OdataToEntity;Trusted_Connection=Yes;")
		{
			InitDataContext();
		}

		partial void InitDataContext();

		#region FreeTextTable

		public class FreeTextKey<T>
		{
			public T   Key;
			public int Rank;
		}

		[FreeTextTableExpression]
		public ITable<FreeTextKey<TKey>> FreeTextTable<TTable,TKey>(string field, string text)
		{
			return this.GetTable<FreeTextKey<TKey>>(
				this,
				((MethodInfo)(MethodBase.GetCurrentMethod())).MakeGenericMethod(typeof(TTable), typeof(TKey)),
				field,
				text);
		}

		[FreeTextTableExpression]
		public ITable<FreeTextKey<TKey>> FreeTextTable<TTable,TKey>(Expression<Func<TTable,string>> fieldSelector, string text)
		{
			return this.GetTable<FreeTextKey<TKey>>(
				this,
				((MethodInfo)(MethodBase.GetCurrentMethod())).MakeGenericMethod(typeof(TTable), typeof(TKey)),
				fieldSelector,
				text);
		}

        #endregion

        [Description("dbo.GetOrders")]
        public IEnumerable<Order> GetOrders(int? id, String name, OrderStatus? status) => throw new NotImplementedException();
        public void ResetDb() => throw new NotImplementedException();
        public void ResetManyColumns() => throw new NotImplementedException();
        [Sql.Function("dbo", "ScalarFunction")]
        public int ScalarFunction() => Orders.Count();
        [Sql.Function("dbo", "ScalarFunctionWithParameters")]
        public int ScalarFunctionWithParameters(int? id, String name, OrderStatus? status) => Orders.Where(o => o.Id == id || o.Name.Contains(name) || o.Status == status).Count();
        [Sql.Function("TableFunction")]
        public IEnumerable<Order> TableFunction() => Orders;
        [Sql.Function("TableFunctionWithParameters")]
        public IEnumerable<Order> TableFunctionWithParameters(int? id, String name, OrderStatus? status) => Orders.Where(o => (o.Id == id) || o.Name.Contains(name) || (o.Status == status));
    }

    [Table(Schema = "dbo", Name = "Categories")]
    public partial class Category
    {
        [PrimaryKey, Identity]
        public int Id { get; set; } // int
        [Column, NotNull]
        public string Name { get; set; } // varchar(128)
        [Column, Nullable]
        public int? ParentId { get; set; } // int
        [Column, Nullable]
        public DateTime? DateTime { get; set; } //datetime2(7)

        #region Associations

        /// <summary>
        /// FK_Categories_Categories_BackReference
        /// </summary>
        [Association(ThisKey = "Id", OtherKey = "ParentId", CanBeNull = true, IsBackReference = true)]
        public IEnumerable<Category> Children { get; set; }

        /// <summary>
        /// FK_Categories_Categories
        /// </summary>
        [Association(ThisKey = "ParentId", OtherKey = "Id", CanBeNull = true, KeyName = "FK_Categories_Categories", BackReferenceName = "Children")]
        public Category Parent { get; set; }

        #endregion
    }

    [Table(Schema="dbo", Name="Customers")]
	public partial class Customer
	{
		[Column,     Nullable ] public string Address { get; set; } // varchar(256)
        [PrimaryKey(Order = 0)] public string Country { get; set; } // char(2)
        [PrimaryKey(Order = 1)] public int    Id      { get; set; } // int
		[Column,     NotNull  ] public string Name    { get; set; } // varchar(128)
		[Column,     Nullable ] public Sex?   Sex     { get; set; } // int

		#region Associations
		[Association(ThisKey="Country,Id", OtherKey="AltCustomerCountry,AltCustomerId", CanBeNull=true, IsBackReference=true)]
		public IEnumerable<Order> AltOrders { get; set; }

		[Association(ThisKey="Country,Id", OtherKey="CustomerCountry,CustomerId", CanBeNull=true, IsBackReference=true)]
		public IEnumerable<Order> Orders { get; set; }

		[Association(ThisKey="Country,Id", OtherKey="CustomerCountry,CustomerId", CanBeNull=true, IsBackReference=true)]
        public ICollection<CustomerShippingAddress> CustomerShippingAddresses { get; set; }

        public ICollection<ShippingAddress> ShippingAddresses { get; set; }
		#endregion
	}

    public class ManyColumnsBase
    {
        [Column, PrimaryKey] public int Column01 { get; set; } // int
        [Column, NotNull]    public int Column02 { get; set; } // int
        [Column, NotNull]    public int Column03 { get; set; } // int
        [Column, NotNull]    public int Column04 { get; set; } // int
        [Column, NotNull]    public int Column05 { get; set; } // int
        [Column, NotNull]    public int Column06 { get; set; } // int
        [Column, NotNull]    public int Column07 { get; set; } // int
        [Column, NotNull]    public int Column08 { get; set; } // int
        [Column, NotNull]    public int Column09 { get; set; } // int
        [Column, NotNull]    public int Column10 { get; set; } // int
        [Column, NotNull]    public int Column11 { get; set; } // int
        [Column, NotNull]    public int Column12 { get; set; } // int
        [Column, NotNull]    public int Column13 { get; set; } // int
        [Column, NotNull]    public int Column14 { get; set; } // int
        [Column, NotNull]    public int Column15 { get; set; } // int
        [Column, NotNull]    public int Column16 { get; set; } // int
        [Column, NotNull]    public int Column17 { get; set; } // int
        [Column, NotNull]    public int Column18 { get; set; } // int
        [Column, NotNull]    public int Column19 { get; set; } // int
        [Column, NotNull]    public int Column20 { get; set; } // int
        [Column, NotNull]    public int Column21 { get; set; } // int
        [Column, NotNull]    public int Column22 { get; set; } // int
        [Column, NotNull]    public int Column23 { get; set; } // int
        [Column, NotNull]    public int Column24 { get; set; } // int
        [Column, NotNull]    public int Column25 { get; set; } // int
        [Column, NotNull]    public int Column26 { get; set; } // int
        [Column, NotNull]    public int Column27 { get; set; } // int
        [Column, NotNull]    public int Column28 { get; set; } // int
        [Column, NotNull]    public int Column29 { get; set; } // int
        [Column, NotNull]    public int Column30 { get; set; } // int
    }

    [Table(Schema = "dbo", Name = "ManyColumns")]
    public sealed class ManyColumns : ManyColumnsBase
    {
    }

    public abstract class OrderBase
    {
        [Column,     Nullable ] public string          AltCustomerCountry { get; set; } // char(2)
        [Column,     Nullable ] public int?            AltCustomerId      { get; set; } // int
		[Column,     NotNull  ] public string          Name               { get; set; } // varchar(256)
    }

    [Table(Schema="dbo", Name="Orders")]
	public partial class Order : OrderBase
	{
        [Column,     NotNull  ] public string          CustomerCountry    { get; set; } // char(2)
        [Column,     NotNull  ] public int             CustomerId         { get; set; } // int
		[Column,     Nullable ] public DateTimeOffset? Date               { get; set; } // datetimeoffset(7)
		[PrimaryKey, Identity ] public int             Id                 { get; set; } // int
		[Column,     NotNull  ] public OrderStatus     Status             { get; set; } // int

		#region Associations

		/// <summary>
		/// FK_Orders_AltCustomers
		/// </summary>
		[Association(ThisKey= "AltCustomerCountry,AltCustomerId", OtherKey="Country,Id", CanBeNull=true, KeyName="FK_Orders_AltCustomers", BackReferenceName= "AltOrders")]
		public Customer AltCustomer { get; set; }

		/// <summary>
		/// FK_Orders_Customers
		/// </summary>
		[Association(ThisKey= "CustomerCountry,CustomerId", OtherKey="Country,Id", CanBeNull=false, KeyName="FK_Orders_Customers", BackReferenceName="Orders")]
		public Customer Customer { get; set; }

		/// <summary>
		/// FK_OrderItem_Order_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="OrderId", CanBeNull=true, IsBackReference=true)]
		public IEnumerable<OrderItem> Items { get; set; }

        /// <summary>
        /// FK_ShippingAddresses_Order_BackReference
        /// </summary>
        [Association(ThisKey = "Id", OtherKey = "OrderId", CanBeNull = true, IsBackReference = true)]
        public IEnumerable<ShippingAddress> ShippingAddresses { get; set; }

        #endregion
    }

    [Table(Schema="dbo", Name="OrderItems")]
	public partial class OrderItem
	{
		[Column,     Nullable ] public int?     Count   { get; set; } // int
		[PrimaryKey, Identity ] public int      Id      { get; set; } // int
		[Column,     NotNull  ] public int      OrderId { get; set; } // int
		[Column,     Nullable ] public decimal? Price   { get; set; } // decimal(18, 0)
		[Column,     NotNull  ] public string   Product { get; set; } // varchar(256)

		#region Associations

		/// <summary>
		/// FK_OrderItem_Order
		/// </summary>
		[Association(ThisKey="OrderId", OtherKey="Id", CanBeNull=false, KeyName="FK_OrderItem_Order", BackReferenceName="Items")]
		public Order Order { get; set; }

		#endregion
	}

    [Table(Schema = "dbo", Name = "ShippingAddresses")]
    public sealed class ShippingAddress
    {
        [Column, NotNull              ] public string Address { get; set; } // varchar(256)
        [Column, PrimaryKey(Order = 1)] public int    Id      { get; set; } // int
        [Column, PrimaryKey(Order = 0)] public int    OrderId { get; set; } // int

		#region Associations
		[Association(ThisKey="OrderId,Id", OtherKey="ShippingAddressOrderId,ShippingAddressId", CanBeNull=true, IsBackReference=true)]
        public ICollection<CustomerShippingAddress> CustomerShippingAddresses { get; set; }

        public ICollection<Customer> Customers { get; set; }
		#endregion
    }

    [Table(Schema = "dbo", Name = "CustomerShippingAddress")]
    public sealed class CustomerShippingAddress
    {
        [Column, PrimaryKey(Order = 0)] public String CustomerCountry        { get; set; }
        [Column, PrimaryKey(Order = 1)] public int    CustomerId             { get; set; }
        [Column, PrimaryKey(Order = 2)] public int    ShippingAddressOrderId { get; set; }
        [Column, PrimaryKey(Order = 3)] public int    ShippingAddressId      { get; set; }

		#region Associations
		[Association(ThisKey="CustomerCountry,CustomerId", OtherKey="Country,Id", CanBeNull=false, KeyName="FK_CustomerShippingAddress_Customers", BackReferenceName="CustomerShippingAddresses")]
        public Customer Customer { get; set; }

        [Association(ThisKey="ShippingAddressOrderId,ShippingAddressId", OtherKey="OrderId,Id", CanBeNull=false, KeyName="FK_CustomerShippingAddress_ShippingAddresses", BackReferenceName="CustomerShippingAddresses")]
        public ShippingAddress ShippingAddress { get; set; }
		#endregion
    }

    public static partial class TableExtensions
	{
		public static Customer Find(this ITable<Customer> table, int Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}

		public static Order Find(this ITable<Order> table, int Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}

		public static OrderItem Find(this ITable<OrderItem> table, int Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}
	}

    public enum OrderStatus
    {
        Unknown,
        Processing,
        Shipped,
        Delivering,
        Cancelled
    }

    public enum Sex
    {
        Male,
        Female
    }
}
