using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;
using Volleyball.Attributes;

namespace Middleware
{
    //[StringLengthValidationClassAttributes]
    [DataContract(IsReference = true)]
    public abstract class Base //: IConvertToDict
    //where T : Base<T>
    {
        private Guid id;
        //public DataRow row;
        private bool isSavedInDB;
        public static string table;

        //public static Dictionary<Guid, Base> Items = new Dictionary<Guid, Base>();

        //static Base()
        //{
        //    table = table = MethodBase.GetCurrentMethod().DeclaringType.Name + "s";
        //    //TableInform.TryCreateTable(table, GetRowNames);
        //    //AddTableRows();
        //}

        //private static string GetRowNames()
        //{
        //    return "( Id uniqueidentifier NOT NULL, PRIMARY KEY (Id) )";
        //}

        public Base()
        {
            //row = table.Table.NewRow();
            id = Guid.NewGuid();
            //row["Id"] = Id;

            //isSavedInDB = false;
        }

        //public Base(DataRow dr)
        //{
        //    row = dr;
        //    isSavedInDB = true;
        //}

        [IsInTable]
        [DataMember]
        public Guid Id
        {
            get
            {
                return id;
                //return new Guid(row["Id"].ToString());
            }
            set
            {
                id = value;
                //row["Id"] = value;
            }
        }

        public Dictionary<string, string> ConvertInstanceToDictionary()
        {
            Dictionary<string, string> selectedProperties;
            Dictionary<string, string> selectedFields;
            Dictionary<string, string> result;

            selectedProperties = this.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Where(prop => prop.GetCustomAttribute<IsInTable>() != null).ToDictionary(prop => prop.Name, prop => prop.GetValue(this).ToString());
            selectedFields = this.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(f => f.GetCustomAttribute<IsInTable>() != null).ToDictionary(f => f.Name, f => f.GetValue(this).ToString());

            if (selectedFields.Count > 0)
            {
                result = selectedProperties.Union(selectedFields).ToDictionary(k => k.Key, v => v.Value);
                return result;
            }
            else return selectedProperties;

        }

        //public static T GetByID(Guid id)
        //{
        //    //while (true)
        //    //{
        //        try
        //        {

        //            return (T)Activator.CreateInstance(typeof(T), new object[] { table.Table.Select("ID = '" + id.ToString() + "'")[0] });
        //        }
        //        catch 
        //        {
        //            return null;
        //        }
        //    //}
        //}

        //public static T[] GetByQuery(string query)
        //{
        //    List<T> result = new List<T>();
        //    List<DataRow> queryRowsResult = new List<DataRow>();
        //    queryRowsResult.AddRange(table.Table.Select(query));

        //    foreach (DataRow dr in queryRowsResult)
        //    {
        //        result.Add((T)Activator.CreateInstance(typeof(T), new object[] { dr }));
        //    }
        //    return result.ToArray(); ;
        //}
        //public bool SavedInDB
        //{
        //    get
        //    {
        //        return isSavedInDB;
        //    }
        //    set
        //    {
        //        isSavedInDB = value;
        //    }
        //}

        //public void Save()
        //{
        //    if (!SavedInDB)
        //    {
        //        isSavedInDB = true;
        //        table.Table.Rows.Add(row);
        //    }
        //    table.Update(row);
        //}

        //public void Delete()
        //{
        //    Items.Remove(Id);
        //    row.Delete();
        //    table.Update(row);
        //}

        //public void Update(Guid Id)
        //{
        //    var retrievedRow = Retrieve(Id);
        //    table.Update(retrievedRow);
        //    //result[changedProperty] =
        //    //var r = table.Table.Rows

        //}

        //public static DataRow Retrieve(Guid Id)
        //{
        //    DataRow dr = table.Table.AsEnumerable()
        //       .SingleOrDefault(r => r.Field<Guid>("ID") == Id);
        //    return dr;
        //    //string searchExpression = String.Format("ID = {0}", Id);
        //    //return table.Table.Select(searchExpression);
        //}


        //public virtual void Save()
        //{ }
        //public virtual Base<T> Read(Guid id)
        //{ }
        //public virtual void Update()
        //{ }
        //public virtual void Delete()
        //{ }
    }
}
