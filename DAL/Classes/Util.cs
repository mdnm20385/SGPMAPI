using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Xml;
using DAL.BL;
using DAL.Extensions.Extensions;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace DAL.Classes
{
    public static class Util
    {
        public static bool CopyColumnsFrom(this DataTable tabelaDestino,DataTable tabelaOrigem)
        {
            tabelaDestino = new DataTable() ;
            if (!tabelaOrigem.HasColumns()) return false;
            foreach (DataColumn col in tabelaOrigem.Columns)
            {
                if (col == null) continue;
                var col2 = new DataColumn();
                col2.ColumnName= col.ColumnName;
                col2.DataType= col.DataType;
                tabelaDestino.Columns.Add(col2);
            }

            return true;
        }
        public static DataTable CopyData(this DataTable dt)
        {
            if (dt.HasColumns())
            {
                var columnNames = dt.Columns.Cast<DataColumn>()
                    .Select(x => x.ColumnName)
                    .ToArray();
                dt.DefaultView.ToTable(true, columnNames);
            }
           return dt;
        }

        public static bool IsNullOrEmpty(this string? xx) => string.IsNullOrEmpty(xx);

        public static bool IsAnoComum(this int year)
        {
            return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
        }
        public static bool Existe(this List<string> lista,string descricao)
        {
            bool retorno=false;
            foreach (var item in lista)
            {
                if (item.ToLower().Trim().Equals(descricao.Trim().ToLower()))
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        public static bool IsPositive(this decimal number)
        {
            return number > 0;
        }

        public static bool IsNegative(this decimal number)
        {
            return number < 0;
        }

        public static bool IsZero(this decimal number)
        {
            return number == 0;
        }

        public static bool IsAwesome(this decimal number)
        {
            return IsNegative(number) && IsPositive(number) && IsZero(number);
        }
        public static string AsString(this XmlDocument xmlDoc)
        {
            using (var sw = new StringWriter())
            {
                using (var tx = new XmlTextWriter(sw))
                {
                    xmlDoc.WriteTo(tx);
                    var strXmlText = sw.ToString();
                    return strXmlText;
                }
            }
        }
     
        public static bool IsString( this string xx)
        {
            var retorno = false;
               decimal xxx =0;
               retorno = decimal.TryParse(xx, out xxx);
               return retorno;
        }

        //Easily draw semi-transparent text on an image in c#
        private static string DrawTextOnImage(string inputImage)
        {
            string modifiedImage = string.Empty;
         
            using (var stream = new MemoryStream(Convert.FromBase64String(inputImage)))
            {
                using (Image image = Image.FromStream(stream))
                {
                    using (Graphics graphics = Graphics.FromImage(image))
                    {
                        graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
         
                        using (Font font = new Font("Arial", 24, FontStyle.Bold))
                        {
                            string text = "Copyright © 2019";
         
                            // Measure string to figure out the width needed.
                            SizeF stringSize = graphics.MeasureString(text, font);
         
                            /* Draw twice, first in transparent black and then 
                             * transparent white, so we have a shadow effect. */
                            using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(100, 0, 0, 0)),
                                textBrush = new SolidBrush(Color.FromArgb(100, 255, 255, 255)))
                            {
                                float x = (image.Width - stringSize.Width) / 2F;
                                float y = image.Height / 2F;
         
                                graphics.DrawString(text, font, shadowBrush, new PointF(x + 1, y + 1));
                                graphics.DrawString(text, font, textBrush, new PointF(x, y));
                            }
                        }
                    }
         
                    // Save image to file for testing
                    image.Save(@"C:\Temp\Test.jpg", ImageFormat.Jpeg);
         
                    // Convert the image back to a base64 encoded string
                    using (MemoryStream m = new MemoryStream())
                    {
                        image.Save(m, ImageFormat.Jpeg);
                        modifiedImage = Convert.ToBase64String(m.ToArray());
                    }
                }
            }
            return modifiedImage;
        }

        /// <summary>Resizes an image, optionally maintaining width:height ratios.</summary>
        /// <param name="image">The <see cref="Image"/> that you wish to resize.</param>
        /// <param name="width">The desired width of the resulting image.</param>
        /// <param name="height">The desired height of the resulting image.</param>
        /// <param name="maintainAspectRatio"><b>True</b> to maintain aspect ratio,
        /// otherwise <b>false</b>. This defaults to <b>true</b>.</param>
        /// <returns>The resulting resized <see cref="Image"/> object.</returns>
        //public static Image Resize(this Image image, int width, int height, bool maintainAspectRatio = true)
        //{
        //    if (image == null)
        //        throw new ArgumentNullException(nameof(image));

        //    if (maintainAspectRatio)
        //    {
        //        // calculate resize ratio
        //        double ratio = (double)width / image.Width;

        //        if (ratio * image.Height > height)
        //            ratio = (double)height / image.Height;

        //        width = (int)Math.Round(ratio * image.Width, MidpointRounding.AwayFromZero);
        //        height = (int)Math.Round(ratio * image.Height, MidpointRounding.AwayFromZero);
        //    }

        //    Bitmap bmp = null;
        //    try
        //    {
        //        bmp = new Bitmap(width, height);

        //        using (Graphics g = Graphics.FromImage(bmp))
        //        {
        //            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic;
        //            g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality;
        //            g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality;
        //            g.DrawImage(image, 0, 0, width, height);
        //        }

        //        return bmp;
        //    }
        //    catch
        //    {
        //        if (bmp != null)
        //            bmp.Dispose();
        //        throw;
        //    }
        //}
        //public void SaveToExcel(List<Response> responses)
        //{
        //    var responsePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Responses";

        //    DataTable table = new DataTable();
        //    table.Columns.Add("Response", typeof(string));
        //    table.Columns.Add("ResponseDate", typeof(DateTime));
        //    table.Columns.Add("CellNumber", typeof(string));

        //    foreach (var response in responses)
        //        table.Rows.Add(response.Response, response.ResponseDate, response.CellNumber);

        //    string filename = DateTime.Now.ToString("yyyy-MM-dd HHmmssfff") + ".xlsx";
        //    filename = Path.Combine(responsePath, filename);
        //    Directory.CreateDirectory(responsePath);

        //    using (var stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None, 0x2000, false))
        //    {
        //        using (ExcelPackage pck = new ExcelPackage(stream))
        //        {
        //            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Responses");
        //            ws.Cells["A1"].LoadFromDataTable(table, true);
        //            pck.Save();
        //        }
        //    }
        //}
        public static Image ByteToImage(byte[] blob)
        {
            try
            {
                var mStream = new MemoryStream();
                var pData = blob;
                if (pData == null) return null;
                switch (pData.Length)
                {
                    case 0:
                    case 1:
                        return null;
                }
                mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
                var bm = Image.FromStream(mStream, true);
                mStream.Dispose();
                return bm;
            }
            catch (Exception e)
            {
                //var stream = Pbl._webHost.WebRootFileProvider.GetFileInfo("images/noimage.png").CreateReadStream();

                var stream = new MemoryStream();
                return Image.FromStream(stream); ;
            }
        }
    }


}
