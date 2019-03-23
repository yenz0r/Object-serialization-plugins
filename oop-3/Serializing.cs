using System;
using System.Text;
using System.Reflection;

class Serializer
{
    public Serializer()
    {

    }

    public static PropertyInfo[] getPropsArr<T>(T obj)
    {
        return obj.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
    }
     
    public void Serialize(string savefilepath, object obj)
    {
        PropertyInfo[] props = getPropsArr<object>(obj);
        string attr = string.Empty; 
        attr += obj.GetType().ToString();
        attr += "|";
        foreach (PropertyInfo prop in props)
        {
            attr += prop.GetValue(obj).ToString();
            attr += "|";
        }
        attr = attr.Substring(0, attr.Length - 1);
        System.IO.File.WriteAllBytes(savefilepath, Encoding.ASCII.GetBytes(attr));
    }

    public object Deserialize(string openfilepath)
    {
        byte[] attr;
        attr = System.IO.File.ReadAllBytes(openfilepath);
        string strattr = Encoding.ASCII.GetString(attr);
        string[] arr = strattr.Split('|');
        Type t = Type.GetType(arr[0]);
        object obj = Activator.CreateInstance(t);
        int i = 1;
        foreach (PropertyInfo prop in getPropsArr<object>(obj))
        {
            if (prop.PropertyType == Type.GetType("System.String"))
            {
                prop.SetValue(obj, arr[i]);
                i++;
                continue;
            }

            if (prop.PropertyType == Type.GetType("System.Int32"))
            {
                prop.SetValue(obj, int.Parse(arr[i]));
                
                i++;
                continue;
            } 

            if (prop.PropertyType == Type.GetType("System.Boolean"))
            {
                prop.SetValue(obj, bool.Parse(arr[i]));

                i++;
                continue;
            }

        }
        System.IO.File.Delete(openfilepath);
        return obj;
    }
}
