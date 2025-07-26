namespace Model.Models.Facturacao.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class Min : Attribute
	{
		public int Value { get; set; }
	}
}
