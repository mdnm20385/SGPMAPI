using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Dynamic;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using ArrayToPdf;
using DAL.Classes;
using DAL.Conexao;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model.Models;
using Model.Models.SJM;

namespace DAL.BL;

public class ListtoDataTableConverter
{
    public DataTable ToDataTable<T>(List<T> items)
    {
        DataTable dataTable = new DataTable(typeof(T).Name);
        //Get all the properties
        PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (PropertyInfo prop in Props)
        {
            //Setting column names as Property names
            dataTable.Columns.Add(prop.Name);
        }
        foreach (T item in items)
        {
            var values = new object[Props.Length];
            for (int i = 0; i < Props.Length; i++)
            {
                //inserting property values to datatable rows
                values[i] = Props[i].GetValue(item, null);
            }
            dataTable.Rows.Add(values);
        }
        //put a breakpoint here and check datatable
        return dataTable;
    }
}


public sealed class MyDynObject : DynamicObject
{
    private readonly Dictionary<string, object> _properties;

    public MyDynObject(Dictionary<string, object> properties)
    {
        _properties = properties;
    }

    public override IEnumerable<string> GetDynamicMemberNames()
    {
        return _properties.Keys;
    }

    public override bool TryGetMember(GetMemberBinder binder, out object result)
    {
        if (_properties.ContainsKey(binder.Name))
        {
            result = _properties[binder.Name];
            return true;
        }
        else
        {
            result = null;
            return false;
        }
    }

    public override bool TrySetMember(SetMemberBinder binder, object value)
    {
        if (_properties.ContainsKey(binder.Name))
        {
            _properties[binder.Name] = value;
            return true;
        }
        else
        {
            return false;
        }
    }
}