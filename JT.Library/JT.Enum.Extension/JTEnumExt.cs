using System;

namespace JT.Enum.Extension {
    public static partial class JTEnumExt {
        public interface IJTAttribute<T> { T Value { get; } }
    }
    public static partial class JTEnumExt {
        public static T JTAttributeValue<T>(this System.Enum value) { return !(value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(IJTAttribute<T>), false) is IJTAttribute<T>[] attribs) ? default(T) : (attribs.Length > 0 ? attribs[0].Value : default(T)); }

        //public static string JTDescriptionValue<T>(this T enumerationValue) where T : struct {
        //    return (!enumerationValue.GetType().IsEnum) ? null :
        //        enumerationValue.GetType().GetMember(enumerationValue.ToString()) == null ? null :
        //        (!(enumerationValue.GetType().GetMember(enumerationValue.ToString())[0].GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[] attrs) ? null : (attrs.Length > 0 ? attrs[0].Description : null));
        //}
    }
    public static partial class JTEnumExt {

        public class JTEnumAttributeAttribute : Attribute {

        }

        [AttributeUsage(AttributeTargets.Field, Inherited = false)]
        public class JTEnumObjectAttributeAttribute : Attribute, IJTAttribute<object> {
            public JTEnumObjectAttributeAttribute(object value) { Value = value; }
            public object Value { get; }
        }

        [AttributeUsage(AttributeTargets.Field, Inherited = false)]
        public class JTEnumStringAttributeAttribute : Attribute, IJTAttribute<string> {
            public JTEnumStringAttributeAttribute(string value) { Value = value; }
            public string Value { get; }
        }

        [AttributeUsage(AttributeTargets.Field, Inherited = false)]
        public class JTEnumDoubleAttributeAttribute : Attribute, IJTAttribute<double> {
            public JTEnumDoubleAttributeAttribute(double value) { Value = value; }
            public double Value { get; }
        }

        [AttributeUsage(AttributeTargets.Field, Inherited = false)]
        public class JTEnumCharAttributeAttribute : Attribute, IJTAttribute<char> {
            public JTEnumCharAttributeAttribute(char value) { Value = value; }
            public char Value { get; }
        }

        [AttributeUsage(AttributeTargets.Field, Inherited = false)]
        public class JTEnumBoolAttributeAttribute : Attribute, IJTAttribute<bool> {
            public JTEnumBoolAttributeAttribute(bool value) { Value = value; }
            public bool Value { get; }
        }
    }
}
