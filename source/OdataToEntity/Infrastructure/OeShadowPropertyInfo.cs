﻿using System;
using System.Globalization;
using System.Reflection;

namespace OdataToEntity.Infrastructure
{
    public sealed class OeShadowPropertyInfo : PropertyInfo
    {
        private readonly MethodInfo _getMethodInfo;
        private readonly MethodInfo _setMethodInfo;

        public OeShadowPropertyInfo(Type declaringType, Type propertyType, String name)
        {
            DeclaringType = declaringType;
            PropertyType = propertyType;
            Name = name;
        }
        public OeShadowPropertyInfo(Type declaringType, Type propertyType, String name, MethodInfo getMethodInfo)
            : this(declaringType, propertyType, name)
        {
            _getMethodInfo = getMethodInfo;
            _setMethodInfo = ((Action<Object>)SetValueMethod).Method;
        }

        private void SetValueMethod(Object value)
        {
            throw new InvalidOperationException("Cannot set value in shadow property " + Name);
        }

        public override PropertyAttributes Attributes => throw new NotImplementedException();
        public override bool CanRead => _getMethodInfo != null;
        public override bool CanWrite => _setMethodInfo != null;
        public override Type DeclaringType { get; }
        public override String Name { get; }
        public override Type PropertyType { get; }
        public override Type ReflectedType => throw new NotImplementedException();

        public override MethodInfo[] GetAccessors(bool nonPublic) => throw new NotImplementedException();
        public override Object[] GetCustomAttributes(bool inherit) => Array.Empty<Attribute>();
        public override Object[] GetCustomAttributes(Type attributeType, bool inherit) => Array.Empty<Attribute>();
        public override MethodInfo GetGetMethod(bool nonPublic) => _getMethodInfo;
        public override ParameterInfo[] GetIndexParameters() => Array.Empty<ParameterInfo>();
        public override MethodInfo GetSetMethod(bool nonPublic) => _setMethodInfo;
        public override Object GetValue(Object obj, BindingFlags invokeAttr, Binder binder, Object[] index, CultureInfo culture) => throw new NotImplementedException();
        public override bool IsDefined(Type attributeType, bool inherit) => throw new NotImplementedException();
        public override void SetValue(Object obj, Object value, BindingFlags invokeAttr, Binder binder, Object[] index, CultureInfo culture) => throw new NotImplementedException();
    }
}