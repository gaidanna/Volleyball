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
    [DataContract(IsReference = true)]
    public abstract class Base
    {
        private Guid id;
        public static string table;

        public Base()
        {
            id = Guid.NewGuid();
        }

        [IsInTable]
        [DataMember]
        public Guid Id
        {
            get
            { return id; }
            set
            { id = value; }
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
    }
}
