//using System.Data.Entity.ModelConfiguration.Configuration;

namespace Model.Models.Facturacao.Generic
{
public class DecimalPrecisionAttribute : Attribute
         {
          int _precision;
          int _scale;
          bool _send;
     
         public DecimalPrecisionAttribute(int precision, int scale,bool send)
         {
             _precision = precision;
             _scale = scale;
             _send = send;
         }
  
         public int Precision => _precision;
         public int Scale => _scale;
         public bool Send  => _send;
         }
  
 

}
