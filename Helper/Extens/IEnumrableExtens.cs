using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace MyBlog.BLL.Extens
{
    // ReSharper disable once InconsistentNaming
    // ReSharper disable once IdentifierTypo
    public static class IEnumrableExtens
    {
        public static IEnumerable<ExpandoObject> ShapeData<TSource>(this IEnumerable<TSource> source, string fields)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var expandoObjects=new List<ExpandoObject>(source.Count());

            var propertyInfos=new List<PropertyInfo>();

            if (string.IsNullOrWhiteSpace(fields))
            {
                var propertyInfo = typeof(TSource).GetProperties(BindingFlags.Instance
                                                                 |BindingFlags.Public|BindingFlags.IgnoreCase);
                propertyInfos.AddRange(propertyInfo);
            }
            else
            {
                var splits = fields.Split(",");

                foreach (var field in splits)
                {
                    var trimField = field.Trim();

                    var propertyInfo =
                        typeof(TSource).GetProperty(trimField,BindingFlags.Instance 
                                                              | BindingFlags.IgnoreCase | BindingFlags.Public);

                    if (propertyInfo==null)
                    {
                        throw new Exception($"{trimField}没有找到{typeof(TSource)}");
                    }

                    propertyInfos.Add(propertyInfo);

                }
            }

            // ReSharper disable once PossibleMultipleEnumeration
            foreach (var item in source)
            {
                var expands = new ExpandoObject();

                foreach (var propertyInfo in propertyInfos)
                {

                    var value = propertyInfo.GetValue(item);

                    ((IDictionary<string, object>)expands).Add(propertyInfo.Name, value);

                }

                expandoObjects.Add(expands);

            }

            return expandoObjects;

        }
    }
}
