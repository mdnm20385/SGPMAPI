using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Model.Models.Facturacao.Generic
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class Unique : ValidationAttribute
    {
        public Type TargetModelType { get; set; }
        public string TargetPropertyName { get; set; }
        private string GetName(ValidationContext validationContext)
        {
            var Name = validationContext.MemberName;
            if (string.IsNullOrEmpty(Name))
            {
                var displayName = validationContext.DisplayName;

                var prop = validationContext.ObjectInstance.GetType().GetProperty(displayName);

                if (prop != null)
                {
                    Name = prop.Name;
                }
                else
                {
                    var props = validationContext.ObjectInstance.GetType().GetProperties().Where(x => x.CustomAttributes.Count(a => a.AttributeType == typeof(DisplayAttribute)) > 0).ToList();

                    foreach (PropertyInfo prp in props)
                    {
                        var attr = prp.CustomAttributes.FirstOrDefault(p => p.AttributeType == typeof(DisplayAttribute));

                        var val = attr.NamedArguments.FirstOrDefault(p => p.MemberName == "Name").TypedValue.Value;

                        if (val.Equals(displayName))
                        {
                            Name = prp.Name;
                            break;
                        }
                    }
                }
            }
            return Name;
        }
    }
}
