using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace RaisersEdge.API.ToolKit.Managed.Mapping
{
    public class Loader
    {
        private static Type baseType = typeof(RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.BaseMapAttribute);

        private Func<System.Reflection.MethodInfo, bool> isGetFieldsProp = new Func<System.Reflection.MethodInfo, bool>(mi => mi.Name.Equals("get_Fields", StringComparison.CurrentCultureIgnoreCase));
        private Func<System.Reflection.MethodInfo, bool> isSetFieldsProp = new Func<System.Reflection.MethodInfo, bool>(mi => mi.Name.Equals("set_Fields", StringComparison.CurrentCultureIgnoreCase));

        public T CopyInto<T, K>(K apiObject) where T : new()
        {
            T dataObject = new T();
            return CopyInto<T, K>(dataObject, apiObject);
        }        

        public T CopyInto<T, K>(T dataObject, K apiObject)
        {
            IEnumerable<System.Reflection.PropertyInfo> propsToLoad = dataObject.GetType().GetProperties().Where(p => p.IsDefined(baseType, true) && p.GetSetMethod().IsPublic);

            foreach (System.Reflection.PropertyInfo prop in propsToLoad)
            {
                // Get the load attribute
                RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.BaseMapAttribute mapAttribute = (RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.BaseMapAttribute)prop.GetCustomAttributes(baseType, true).FirstOrDefault();

                var testProps = apiObject.GetType().GetMethods();
                // Get the get_Fields property that uses the specified enumeration type
                var apiGetFieldProp = apiObject.GetType().GetMethods().
                    Where(isGetFieldsProp).Where(m => m.GetParameters().Where(p => p.ParameterType.Equals(mapAttribute.FieldType)).Count() == 1).FirstOrDefault();

                // Get the field value from the api object
                if (apiGetFieldProp != null)
                {
                    // Get the field to load value
                    object fieldToLoad = Convert.ChangeType(mapAttribute.FieldToMap, mapAttribute.FieldType);

                    object fieldValue = apiGetFieldProp.Invoke(apiObject, new object[] { fieldToLoad });

                    if (mapAttribute.IsREBoolean)
                    {
                        bool reBoolValue = fieldValue.ToString().Equals("-1");
                        prop.SetValue(dataObject, reBoolValue, null);
                    }
                    else
                    {
                        // Get defined type on data object
                        Type propValueType = prop.GetSetMethod().GetParameters().FirstOrDefault().ParameterType;

                        // Set the field value to the data object
                        prop.SetValue(dataObject, Convert.ChangeType(fieldValue, propValueType), null);
                    }
                }
            }

            return dataObject;
        }

        public T UpdateFrom<T, K>(T dataObject, K apiObject)
        {
            IEnumerable<System.Reflection.PropertyInfo> propsToSave = dataObject.GetType().GetProperties().Where(p => p.IsDefined(baseType, true) && p.GetSetMethod().IsPublic);

            foreach (System.Reflection.PropertyInfo prop in propsToSave)
            {
                // Get the load attribute
                RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.BaseMapAttribute mapAttribute = (RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.BaseMapAttribute)prop.GetCustomAttributes(baseType, true).FirstOrDefault();

                if (!mapAttribute.IsReadOnly)
                {
                    var apiGetFieldProp = apiObject.GetType().GetMethods().
                        Where(isGetFieldsProp).Where(m => m.GetParameters().Where(p => p.ParameterType.Equals(mapAttribute.FieldType)).Count() == 1).FirstOrDefault();

                    // Get the set_Fields property that uses the specified enumeration type
                    var apiSetFieldProp = apiObject.GetType().GetMethods().
                        Where(isSetFieldsProp).Where(m => m.GetParameters().Where(p => p.ParameterType.Equals(mapAttribute.FieldType)).Count() == 1).FirstOrDefault();

                    // Get the field value from the api object
                    if (apiSetFieldProp != null)
                    {

                        // Get the field value from the data object
                        object fieldValue = prop.GetValue(dataObject, null);

                        object currentFieldValue = apiGetFieldProp.Invoke(apiObject, new object[] { mapAttribute.FieldToMap });

                        if (mapAttribute.IsREBoolean)
                        {
                            string reBoolValue = (bool)fieldValue ? "-1" : "0";
                            apiSetFieldProp.Invoke(apiObject, new object[] { mapAttribute.FieldToMap, fieldValue });
                        }
                        else
                        {
                            if (currentFieldValue == null || !currentFieldValue.Equals(fieldValue))
                            {
                                apiSetFieldProp.Invoke(apiObject, new object[] { mapAttribute.FieldToMap, fieldValue });
                            }
                        }
                    }
                }
            }

            return dataObject;
        }
    }
}
