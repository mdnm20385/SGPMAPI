namespace Model.Models.Facturacao.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class Max : Attribute
	{
		public int Value { get; set; }
	}
}
