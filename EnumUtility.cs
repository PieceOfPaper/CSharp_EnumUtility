using System;
using System.Collections.Generic;

public static class EnumUtility
{
    static Dictionary<Type, Dictionary<string, object>> m_DicStringToEnum = new Dictionary<Type, Dictionary<string, object>>();

    public static void CacheStringToEnum(Type type)
    {
        if (m_DicStringToEnum.ContainsKey(type) == true)
            return;

        m_DicStringToEnum.Add(type, new Dictionary<string, object>());

        var names = System.Enum.GetNames(type);
        var values = System.Enum.GetValues(type);

        for (int i = 0; i < names.Length; i++)
        {
            var name = names[i];
            var value = values.GetValue(i);
            if (string.IsNullOrEmpty(name)) continue;
            if (value == null) continue;

            m_DicStringToEnum[type].Add(name, value);
        }
    }

    public static void ClearCachedStringToEnums()
    {
        m_DicStringToEnum.Clear();
    }

    public static TEnum EnumParse<TEnum>(string str) where TEnum : Enum
    {
        var type =  typeof(TEnum);
        CacheStringToEnum(type);

        if (m_DicStringToEnum[type].ContainsKey(str) == false)
        {
            throw new FormatException();
        }

        return (TEnum)m_DicStringToEnum[type][str];
    }

    public static bool TryEnumParse<TEnum>(string str, out TEnum output) where TEnum : Enum
    {
        var type = typeof(TEnum);
        CacheStringToEnum(type);

        if (m_DicStringToEnum[type].ContainsKey(str) == false)
        {
            output = default;
            return false;
        }

        output = (TEnum)m_DicStringToEnum[type][str];
        return true;
    }
}