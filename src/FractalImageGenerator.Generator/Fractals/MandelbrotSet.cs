using FractalImageGenerator.Generator.Configurations;

namespace FractalImageGenerator.Generator.Fractals;

internal class MandelbrotSet(MandelbrotSetConfiguration configuration) : IFractal
{
    public int Width { get; init; } = configuration.Width;
    public int Height { get; init; } = configuration.Height;
    public int Zoom { get; init; } = configuration.Zoom;
    public int MaxIterations { get; init; } = configuration.MaxIterations;
    public double OffsetX { get; init; } = configuration.OffsetX;
    public double OffsetY { get; init; } = configuration.OffsetY;

    public double HWWidth => Width / 2;
    public double HHeight => Height / 2;
    public double Magnitude => (Width / 3.0) * Zoom * Zoom;
    
    public byte[] Render() => CreatePixelArray();

    private byte[] CreatePixelArray()
    {
        int stride = (Width % 4 == 0) ? Width : Width + 4 - Width % 4;

        byte[] pixelArray = new byte[stride * Height * 4];

        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                int offset = (y * stride + x) * 4;

                double iterations = CalculateEscapePoint(
                    TransformXFromScreenToWorld(x),
                    TransformYFromScreenToWorld(y));

                if (iterations == -1)
                {
                    pixelArray[offset + 0] = 255;
                    pixelArray[offset + 1] = 255;
                    pixelArray[offset + 2] = 255;
                    pixelArray[offset + 3] = 255;
                }
                else
                {
                    pixelArray[offset + 0] = (byte)Math.Abs(Math.Sin(0.01 * iterations + 1) * 230 + 25);
                    pixelArray[offset + 1] = (byte)Math.Abs(Math.Sin(0.013 * iterations + 2) * 230 + 25);
                    pixelArray[offset + 2] = (byte)Math.Abs(Math.Sin(0.016 * iterations + 4) * 230 + 25);
                    pixelArray[offset + 3] = 255;
                }
            }
        }

        return pixelArray;
    }

    private double TransformXFromScreenToWorld(int x) => ((x - HWWidth) / Magnitude) - OffsetX;

    private double TransformYFromScreenToWorld(int y) => -((y - HHeight) / Magnitude) + OffsetY;

    private double CalculateEscapePoint(double cx, double cy)
    {
        double zx = 0.0, zy = 0.0;
        double xsqr = 0.0, ysqr = 0.0;

        for (int iteration = 0; iteration < MaxIterations; iteration++)
        {
            zy = 2 * zx * zy + cy;
            zx = xsqr - ysqr + cx;
            xsqr = zx * zx;
            ysqr = zy * zy;

            if (xsqr +  ysqr >= 4.0)
                return iteration + 1 - (Math.Log(2) / (xsqr + ysqr)) / Math.Log(2);
        }

        return -1;
    }
}
