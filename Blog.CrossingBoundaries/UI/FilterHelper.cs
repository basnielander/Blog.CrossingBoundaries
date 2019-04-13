using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Blog.CrossingBoundaries.UI
{
    public static class FilterHelper
    {
        internal static BindingFlags BindingFlags => BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty;

        internal static PropertyInfo GetPropertyByName(Type type, string name)
        {
            return type.GetProperty(name, BindingFlags);
        }

        public static Expression<Func<TModel, bool>> CreateExpression<TModel>(string sourcePropertyName, string filterValue, ParameterExpression parameterExpression)
        {
            var sourceProperty = GetPropertyByName(typeof(TModel), sourcePropertyName);

            var logicalMethod = typeof(string).GetMethod(nameof(string.Contains), new[] { typeof(string) });
            var expression = Expression.Call(Expression.Property(parameterExpression, sourceProperty), logicalMethod, Expression.Constant(filterValue));

            return Expression.Lambda<Func<TModel, bool>>(expression, new ParameterExpression[] { parameterExpression });
        }

        public static ParameterExpression GetParameterExpression<TModel>()
        {
            return Expression.Parameter(typeof(TModel), "item");
        }
    }
}
