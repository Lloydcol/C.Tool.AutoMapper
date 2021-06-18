using System;

namespace ToolBox.AutoMapper
{
    public static class MapperExtensions
    {
        public static T MapTo<T>(this object from)
           where T: new()
        {
            Type fromType = from.GetType();
            T result = new T();
            var toProps = typeof(T).GetProperties();
            foreach(var prop in toProps)
            {
                var fromProp = fromType.GetProperty(prop.Name);
                if (fromProp != null)
                {
                    object value = fromProp.GetValue(from);
                    try
                    {
                        prop.SetValue(result, value);
                    } catch(Exception ) { }
                }
            }
            return result;
        }
    }
}
