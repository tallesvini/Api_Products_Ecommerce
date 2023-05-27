using System.ComponentModel;

namespace MinhaApi.Enums
{
    public enum StatusProduct
    {
        [Description ("Unknown")]
        Unknown = 0,

        [Description("With Stock")]
        Stock = 1,

        [Description("Without Stock")]
        WithoutStock = 2,
    }
}
