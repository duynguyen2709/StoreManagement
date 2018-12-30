using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace StoreManagement.Utilities
{
    public static class CastEntity
    {
        public static T Cast<T>(this object obj)
        {
            Type objectType = obj.GetType();
            Type target = typeof(T);
            object result = Activator.CreateInstance(target, false);
            IEnumerable<MemberInfo> sourceObj = from source in objectType.GetMembers().ToList()
                                                where source.MemberType == MemberTypes.Property
                                                select source;
            IEnumerable<MemberInfo> destObj = from source in target.GetMembers().ToList()
                                              where source.MemberType == MemberTypes.Property
                                              select source;
            List<MemberInfo> members = destObj.Where(memberInfo => destObj.Select(c => c.Name)
                                                              .ToList().Contains(memberInfo.Name)).ToList();

            foreach (MemberInfo memberInfo in members)
            {
                PropertyInfo propertyInfo = typeof(T).GetProperty(memberInfo.Name);
                object value = obj.GetType().GetProperty(memberInfo.Name)?.GetValue(obj, null);

                propertyInfo.SetValue(result, value, null);
            }
            return (T)result;
        }
    }
}