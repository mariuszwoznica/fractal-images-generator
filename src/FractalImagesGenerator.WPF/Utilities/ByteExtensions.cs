using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FractalImagesGenerator.WPF.Utilities;

internal static class ByteExtensions
{
    internal static WriteableBitmap ToWriteableBitmap(this byte[] data)
    {
        var wBitmap = new WriteableBitmap(ImageConstants.width, ImageConstants.height, 96, 96, 
            PixelFormats.Bgra32, null);

        int bytesPerPixel = wBitmap.Format.BitsPerPixel / 8;
        int stride = ImageConstants.width * bytesPerPixel;

        wBitmap.WritePixels(new Int32Rect(0, 0, ImageConstants.width, ImageConstants.height), data, stride, 0);
        
        return wBitmap;
    }
}
