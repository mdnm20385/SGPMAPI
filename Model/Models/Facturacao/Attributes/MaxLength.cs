namespace Model.Models.Facturacao.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class MaxLength : Attribute
	{
		public int Value { get; set; }
	}
}
