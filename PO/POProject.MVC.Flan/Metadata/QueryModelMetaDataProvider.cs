using POProject.MVC.Flan.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace POProject.MVC.Flan.Metadata
{
    public class QueryModelMetaDataProvider : DataAnnotationsModelMetadataProvider
    {
        /// <summary>
        /// Custom ModelMedataProvider used to store the SearchFilterAttribute and OrderByAttribute
        /// in ModelMetadata AdditionValues
        /// ref: http://bradwilson.typepad.com/blog/2010/01/why-you-dont-need-modelmetadataattributes.html
        /// </summary>
        /// <param name="attributes"></param>
        /// <param name="containerType"></param>
        /// <param name="modelAccessor"></param>
        /// <param name="modelType"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            ModelMetadata metadata = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);

            SearchFilterAttribute searchFilterAttribute = attributes.OfType<SearchFilterAttribute>().FirstOrDefault();
            if (searchFilterAttribute != null)
            {
                metadata.AdditionalValues.Add(Globals.SearchFilterAttributeKey, searchFilterAttribute);
            }

            OrderByAttribute orderByAttribute = attributes.OfType<OrderByAttribute>().FirstOrDefault();
            if (orderByAttribute != null)
            {
                metadata.AdditionalValues.Add(Globals.OrderByAttributeKey, orderByAttribute);
            }

            return metadata;
        }

        public int MyProperty { get; set; }
    }
}
