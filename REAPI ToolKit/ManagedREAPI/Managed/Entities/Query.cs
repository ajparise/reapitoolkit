using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace RaisersEdge.API.ToolKit.Managed.Entities
{
    public class Query : Blackbaud.PIA.RE7.BBREAPI.CQueryObjectClass, IDisposable
    {
        private String _queryName;
        private System.Data.DataTable errorTable;
        private Blackbaud.PIA.RE7.BBREAPI.IBBSessionContext context;

        private void initializeErrorTable()
        {
            errorTable = new System.Data.DataTable("Query Error Table");
            errorTable.Columns.Add(new System.Data.DataColumn("Error", typeof(String)));
            errorTable.Columns.Add(new System.Data.DataColumn("Exception Message", typeof(String)));
            errorTable.Columns.Add(new System.Data.DataColumn("Stack Trace", typeof(String)));
        }

        public Query(String queryName)
            : base()
        {
            context = RaisersEdge.API.ToolKit.Managed.SingletonProxy.Instance.ManagedSessionContext;
            this.Init(ref context);
            this.LoadByField(Blackbaud.PIA.RE7.BBREAPI.bbQueryUniqueFields.uf_QUERY_NAME, queryName);
            initializeErrorTable();
        }

        public Query(int queryID)
            : base()
        {
            context = RaisersEdge.API.ToolKit.Managed.SingletonProxy.Instance.ManagedSessionContext;
            this.Init(ref context);
            this.Load(queryID);
            _queryName = Convert.ToString(this.get_Fields(Blackbaud.PIA.RE7.BBREAPI.EQUERIES2Fields.QUERIES2_fld_NAME));
            initializeErrorTable();
        }
        
        public Query(String queryName, Blackbaud.PIA.RE7.BBREAPI.IBBSessionContext sess) : base()
        {
            context = sess;
            _queryName = queryName;
            this.Init(ref context);
            this.LoadByField(Blackbaud.PIA.RE7.BBREAPI.bbQueryUniqueFields.uf_QUERY_NAME, queryName);
            initializeErrorTable();
        }

        public Query(int queryID, Blackbaud.PIA.RE7.BBREAPI.IBBSessionContext sess)
            : base()
        {
            context = sess;
            this.Init(ref context);
            this.Load(queryID);
            _queryName = Convert.ToString(this.get_Fields(Blackbaud.PIA.RE7.BBREAPI.EQUERIES2Fields.QUERIES2_fld_NAME));
            initializeErrorTable();
        }

        public System.Data.DataTable OpenQuerySetAsDataTable()
        {
            try
            {
                System.Data.DataTable records = new System.Data.DataTable();
                this.QuerySet.OpenQuerySet();

                for (int i = 1; i <= this.QuerySet.FieldCount; i++)
                {
                    System.Data.DataColumn column = new System.Data.DataColumn(this.QuerySet.get_FieldName(i));
                    switch (this.QuerySet.get_FieldType(i))
                    {
                        case Blackbaud.PIA.RE7.BBREAPI.bbQuerySetFieldTypes.bbqueryset_Date:
                            {
                                column.DataType = typeof(DateTime);
                                break;
                            }
                        case Blackbaud.PIA.RE7.BBREAPI.bbQuerySetFieldTypes.bbqueryset_Double:
                            {
                                column.DataType = typeof(Double);
                                break;
                            }
                        case Blackbaud.PIA.RE7.BBREAPI.bbQuerySetFieldTypes.bbqueryset_Long:
                            {
                                column.DataType = typeof(long);
                                break;
                            }
                        case Blackbaud.PIA.RE7.BBREAPI.bbQuerySetFieldTypes.bbqueryset_Memo:
                        case Blackbaud.PIA.RE7.BBREAPI.bbQuerySetFieldTypes.bbqueryset_Text:
                            {
                                column.DataType = typeof(String);
                                break;
                            }
                    }
                    records.Columns.Add(column);
                }

                while (!Convert.ToBoolean(this.QuerySet.EOF))
                {
                    List<object> columnData = new List<object>(this.QuerySet.FieldCount);
                    for (int i = 1; i <= this.QuerySet.FieldCount; i++)
                    {
                        columnData.Add(Convert.ChangeType(this.QuerySet.get_fieldValue(i), records.Columns[i - 1].DataType));
                    }
                    records.Rows.Add(columnData.ToArray());
                    this.QuerySet.MoveNext();
                }

                records.TableName = _queryName;

                this.QuerySet.CloseDown();

                return records;
            }
            catch (Exception err)
            {
                errorTable.Rows.Clear();
                errorTable.Rows.Add("Query Failed!", err.Message, err.StackTrace);
                return errorTable;
            }
        }

        private class QueryField
        {
            public int Index { get; set; }
            public string FieldName { get; set; }

            private Blackbaud.PIA.RE7.BBREAPI.bbQuerySetFieldTypes _BBFieldType;
            public Blackbaud.PIA.RE7.BBREAPI.bbQuerySetFieldTypes BBFieldType
            {
                get
                {
                    return _BBFieldType;
                }
                set
                {
                    _BBFieldType = value;
                    switch (value)
                    {
                        case Blackbaud.PIA.RE7.BBREAPI.bbQuerySetFieldTypes.bbqueryset_Date:
                            {
                                _fieldType = typeof(DateTime);
                                break;
                            }
                        case Blackbaud.PIA.RE7.BBREAPI.bbQuerySetFieldTypes.bbqueryset_Double:
                            {
                                _fieldType = typeof(Double);
                                break;
                            }
                        case Blackbaud.PIA.RE7.BBREAPI.bbQuerySetFieldTypes.bbqueryset_Long:
                            {
                                _fieldType = typeof(long);
                                break;
                            }
                        case Blackbaud.PIA.RE7.BBREAPI.bbQuerySetFieldTypes.bbqueryset_Memo:
                        case Blackbaud.PIA.RE7.BBREAPI.bbQuerySetFieldTypes.bbqueryset_Text:
                            {
                                _fieldType = typeof(String);
                                break;
                            }
                    }
                }
            }

            private Type _fieldType;
            public Type FieldType
            {
                get
                {
                    return _fieldType;
                }
            }
        }

        private static Type baseType = typeof(RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.QueryMappingAttribute);

        public List<T> LoadQuerySetInto<T>() where T : new()
        {
            Dictionary<string, QueryField> queryFields = new Dictionary<string, QueryField>();
            this.QuerySet.OpenQuerySet();

            for (int i = 1; i <= this.QuerySet.FieldCount; i++)
            {
                queryFields.Add(this.QuerySet.get_FieldName(i), new QueryField { Index = i, FieldName = this.QuerySet.get_FieldName(i), BBFieldType = this.QuerySet.get_FieldType(i) });
            }

            List<T> resultSet = new List<T>();
            IEnumerable<System.Reflection.PropertyInfo> propsToLoad = typeof(T).GetProperties().Where(p => p.IsDefined(baseType, true) && p.GetSetMethod().IsPublic);


            while (!Convert.ToBoolean(this.QuerySet.EOF))
            {
                T row = new T();
                foreach (System.Reflection.PropertyInfo prop in propsToLoad)
                {
                    // Get the load attribute
                    RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.QueryMappingAttribute mapAttribute = (RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.QueryMappingAttribute)prop.GetCustomAttributes(baseType, true).FirstOrDefault();

                    // Get the property type
                    Type propValueType = prop.GetSetMethod().GetParameters().FirstOrDefault().ParameterType;

                    // Index provided
                    if (mapAttribute.FieldType.Equals(typeof(int)))
                    {
                        prop.SetValue(row, this.QuerySet.get_fieldValue(mapAttribute.FieldToMap), null);
                    }
                    // Field Name Provided
                    else if (mapAttribute.FieldType.Equals(typeof(string)))
                    {
                        if (queryFields.ContainsKey((string)mapAttribute.FieldToMap))
                        {
                            prop.SetValue(row, this.QuerySet.get_fieldValue(queryFields[(string)mapAttribute.FieldToMap].Index), null);
                        }
                    }
                }

                resultSet.Add(row);

                this.QuerySet.MoveNext();
            }

            return resultSet;
        }

        #region IDisposable Members

        public void Dispose()
        {
            this.CloseDown();
        }

        #endregion

        public static bool QueryExists(string queryName, Blackbaud.PIA.RE7.BBREAPI.IBBSessionContext sess)
        {
            try
            {
                Blackbaud.PIA.RE7.BBREAPI.CQueryObjectClass query = new Blackbaud.PIA.RE7.BBREAPI.CQueryObjectClass();
                query.Init(ref sess);
                query.LoadByField(Blackbaud.PIA.RE7.BBREAPI.bbQueryUniqueFields.uf_QUERY_NAME, queryName);
                query.CloseDown();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool QueryExists(string queryName)
        {
            return QueryExists(queryName, RaisersEdge.API.ToolKit.Managed.SingletonProxy.Instance.ManagedSessionContext);
        }
    }
}
