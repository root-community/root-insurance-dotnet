using System.Diagnostics.CodeAnalysis;

namespace RootSDK.Insurance.Models
 {
     [SuppressMessage("ReSharper", "InconsistentNaming")]
     public class QuoteItem<T>
         where T : class, IInsurable
     {
         public string quote_package_id { get; set; }
         public string package_name { get; set; }
         public int sum_assured { get; set; }
         public int base_premium { get; set; }
         public int suggested_premium { get; set; }
         public object module { get; set; }
     }
 }