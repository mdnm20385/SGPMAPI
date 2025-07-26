namespace Model.Models.Facturacao.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class MinLength : Attribute
	{
		public int Value { get; set; }
	}
}
