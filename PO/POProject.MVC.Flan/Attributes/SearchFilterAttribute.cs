using System;

namespace POProject.MVC.Flan.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class SearchFilterAttribute : Attribute
    {
        public SearchFilterAttribute()
            : this(FilterType.Equals)
        {
        }

        public SearchFilterAttribute(FilterType filterType)
        {
            this.FilterType = filterType;
        }

        public FilterType FilterType { get; set; }
    }
}
