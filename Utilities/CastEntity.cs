using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace StoreManagement.Utilities
{
    public static class CastEntity
    {
        public static T Cast<T>(this Object obj)
        {
            Type objectType = obj.GetType();
            Type target = typeof(T);
            var result = Activator.CreateInstance(target, false);
            var sourceObj = from source in objectType.GetMembers().ToList()
                            where source.MemberType == MemberTypes.Property
                            select source;
            var destObj = from source in target.GetMembers().ToList()
                          where source.MemberType == MemberTypes.Property
                          select source;
            List<MemberInfo> members = destObj.Where(memberInfo => destObj.Select(c => c.Name)
                                                              .ToList().Contains(memberInfo.Name)).ToList();

            foreach (var memberInfo in members)
            {
                var propertyInfo = typeof(T).GetProperty(memberInfo.Name);
                var value = obj.GetType().GetProperty(memberInfo.Name)?.GetValue(obj, null);

                propertyInfo.SetValue(result, value, null);
            }
            return (T)result;
        }
    }
}