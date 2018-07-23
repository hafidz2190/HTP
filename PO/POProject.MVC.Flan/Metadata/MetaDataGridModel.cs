using MvcContrib.UI.Grid;
using System;
using System.Linq.Expressions;
using System.Web.ModelBinding;

namespace POProject.MVC.Flan.Metadata
{
    /// <summary>
    /// Class to auto generate columns based on the ModelMetadata
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MetaDataGridModel<T> : GridModel<T> where T : class, new()
    {
        public MetaDataGridModel() : this(null) { }

        /// <summary>
        /// Enumerates through the ModelMetadata for a given type and
        /// adds columns to the Grid
        /// </summary>
        /// <param name="insertColumns"></param>
        public MetaDataGridModel(Action<ColumnBuilder<T>> insertColumns)
        {
            //To insert any custom columns the user wishes to add in front of the auto generated ones.
            //Ideally the MVCContrib Grid should allow inserting columns
            if (insertColumns != null)
            {
                insertColumns(this.Column);
            }

            var modelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => null, typeof(T));
            foreach (var modelMetadataProperty in modelMetadata.Properties)
            {
                if (modelMetadataProperty.ShowForDisplay)
                {
                    bool isSortable = modelMetadataProperty.AdditionalValues.ContainsKey(Globals.OrderByAttributeKey);
                    string displayFormatString = modelMetadataProperty.DisplayFormatString;
                    var expression = CreateExpression(modelMetadataProperty);

                    IGridColumn<T> column = Column.For(expression).Named(modelMetadataProperty.GetDisplayName()).Sortable(isSortable);

                    if (!string.IsNullOrEmpty(displayFormatString))
                    {
                        column.Format(displayFormatString);
                    }
                }
            }
        }

        private static Expression<Func<T, object>> CreateExpression(ModelMetadata modelMetadata)
        {
            ParameterExpression param = Expression.Parameter(typeof(T), "x");
            Expression expression = Expression.Property(param, modelMetadata.PropertyName);

            if (modelMetadata.ModelType.IsValueType)
            {
                expression = Expression.Convert(expression, typeof(object));
            }
            var predicate = Expression.Lambda<Func<T, object>>(expression, param);
            return predicate;
        }
    }
}
