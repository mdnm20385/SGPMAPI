namespace DAL.Classes
{
    public static class DmzConverter
    {
        //internal static void PdfToImage(string pdf)
        //{
        //    //Create a PdfConverter object

        //    var converter = new PdfConverter();

        //    //Bind the input PDF file

        //    converter.BindPdf(pdf);

        //    // Specify the start page to be processed

        //    converter.StartPage = 1;

        //    // Specify the end page for processing

        //    converter.EndPage = 1;

        //    // Create a Resolution object to specify the resolution of resultant image

        //    converter.Resolution = new Resolution(400,400);

        //    //Initialize the convertion process

        //    converter.DoConvert();

        //    // Create a MemoryStream object to hold the resultant image

        //    var imageStream = new MemoryStream();

        //    //Check if pages exist and then convert to image one by one

        //    while (converter.HasNextImage())

        //    {

        //        // Save the image in the given image Format

        //        converter.GetNextImage(imageStream, System.Drawing.Imaging.ImageFormat.Png);

        //        // Set the stream position to the beginning of the stream

        //        imageStream.Position = 0;

        //        // Instantiate a BarCodeReader object

        //       // Aspose.BarCodeRecognition.BarCodeReader barcodeReader = new Aspose.BarCodeRecognition.BarCodeReader(imageStream, Aspose.BarCodeRecognition.BarCodeReadType.Code39Extended);

        //        // String txtResult.Text = "";

        //        //while (barcodeReader.Read())

        //        //{

        //        //    // Get the barcode text from the barcode image

        //        //    string code = barcodeReader.GetCodeText();

        //        //    // Write the barcode text to Console output

        //        //    //Console.WriteLine("BARCODE : " + code);

        //        //}

        //        //// Close the BarCodeReader object to release the image file

        //        //barcodeReader.Close();

        //    }

        //    // Close the PdfConverter instance and release the resources

        //    converter.Close();

        //    // Close the stream holding the image object

        //    imageStream.Close();

        //}
    }
}
