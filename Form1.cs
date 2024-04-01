using SkiaSharp;
using System.Windows.Forms;

namespace SandWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                pictureBox2.Size = new Size(1920, 1080);
                pictureBox2.Location = new Point(0, 0);

                SKImageInfo info = new SKImageInfo(300, 200);

                using (SKSurface surface = SKSurface.Create(info))
                {
                    SKCanvas canvas = surface.Canvas;

                    canvas.Clear(SKColors.Red);

                    using (SKPaint paint = new SKPaint())
                    {
                        paint.Color = SKColors.Blue;
                        paint.StrokeWidth = 15;
                        paint.Style = SKPaintStyle.Stroke;

                        canvas.DrawCircle(50, 50, 30, paint);


                    }

                    using (SKImage image = surface.Snapshot())
                    using (SKData data = image.Encode(SKEncodedImageFormat.Png, 100))
                    using (MemoryStream mStream = new MemoryStream(data.ToArray()))
                    {
                        Bitmap bm = new Bitmap(mStream, false);
                        pictureBox2.Image = bm;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {


        }
    }
}
