using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace cm
{
    public class Plot
    {
        private Settings m_settings;

        public Bitmap m_bitmap = new Bitmap(100, 100);

        private List<Indicators> m_indicators = new List<Indicators>();

        private int m_w = 100;
        private int m_h = 100;

        private Pen m_grayPen = new Pen(Color.Gray, .1f);
        private Pen m_greenPen = new Pen(Color.ForestGreen, 2);
        private SolidBrush m_blackBrush = new SolidBrush(Color.Black);
        private SolidBrush m_greenBrush = new SolidBrush(Color.ForestGreen);

        public Plot(int w, int h, Settings settings, List<Indicators> indicators)
        {
            m_w = w - 60;
            m_h = h - 60;
            m_settings = settings;
            m_indicators = indicators;
            m_bitmap = new Bitmap(w, h);
        }

        private double MaxUab()
        {
            var maxUab = m_indicators.Max(t => t.m_Uab);

            var mx = 0d;

            while(mx < maxUab)
            {
                mx += m_settings.Uab_step;
            }

            return mx;
        }

        private double MaxIa()
        {
            var maxIa = m_indicators.Max(t => t.m_Ia);

            var mx = 0d;

            while (mx < maxIa)
            {
                mx += m_settings.Ia_step;
            }

            return mx;
        }

        public void Clear()
        {
            using (Graphics graphics = Graphics.FromImage(m_bitmap))
            using (SolidBrush whiteBrush = new SolidBrush(Color.White))
            {
                graphics.FillRectangle(whiteBrush, 0, 0, m_bitmap.Width, m_bitmap.Height);
            }
        }

        public void DrawPlot(bool link = false, Indicators current = null)
        {
            if (m_indicators.Count < 5)
            {
                return;
            }

            using (Graphics graphics = Graphics.FromImage(m_bitmap))
            {
                m_greenPen.DashStyle = DashStyle.Dash;

                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

                var maxUab = MaxUab();
                var maxIa = MaxIa();

                float x0 = (float)(m_w / maxIa * m_indicators[0].m_Ia);
                float y0 = m_h - (float)(m_h / maxUab * m_indicators[0].m_Uab);

                graphics.FillEllipse(m_blackBrush, new RectangleF(x0 - 3f, y0 - 3f, 6f, 6f));

                foreach (var indicators in m_indicators.GetRange(1, m_indicators.Count - 1))
                {
                    float x1 = (float)(m_w / maxIa * indicators.m_Ia);
                    float y1 = m_h - (float)(m_h / maxUab * indicators.m_Uab);

                    graphics.FillEllipse(m_blackBrush, new RectangleF(x1 - 3f, y1 - 3f, 6f, 6f));

                    if (link)
                    {
                        graphics.DrawLine(m_grayPen, new PointF(x0, y0), new PointF(x1, y1));
                    }

                    x0 = x1;
                    y0 = y1;
                }

                if (current != null)
                {
                    x0 = (float)(m_w / maxIa * current.m_Ia);
                    y0 = m_h - (float)(m_h / maxUab * current.m_Uab);

                    graphics.DrawLine(m_greenPen, new PointF(0, y0), new PointF(m_w, y0));
                    graphics.DrawLine(m_greenPen, new PointF(x0, 0), new PointF(x0, m_h));

                    graphics.FillEllipse(m_greenBrush, new RectangleF(x0 - 5f, y0 - 5f, 10f, 10f));
                }
            }
        }

        public void DrawAxis()
        {
            if (m_indicators.Count < 5)
            {
                return;
            }

            using (Pen pen = new Pen(Color.Gray, 1))
            using (Font font1 = new Font("Verdana", 14))
            using (Font font2 = new Font("Verdana", 20))
            using (StringFormat drawFormat = new StringFormat())
            using (Graphics graphics = Graphics.FromImage(m_bitmap))
            using (SolidBrush drawBrush1 = new SolidBrush(Color.Crimson))
            using (SolidBrush drawBrush2 = new SolidBrush(Color.Blue))
            {
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

                //horizontal Uab
                var maxUab = MaxUab();
                var Uab_step = m_settings.Uab_step;
                var Uab = Uab_step;

                var Uab_mark_step = (int)((maxUab / Uab_step) / 15);
                if (Uab_mark_step < 5)
                {
                    Uab_mark_step = 5;
                }

                int i = 1;
                while (Uab < maxUab)
                {
                    float y0 = m_h - (float)(m_h / maxUab * Uab);

                    if (i % Uab_mark_step == 0)
                    {
                        var size = graphics.MeasureString(Uab.ToString("F3"), font1);
                        graphics.DrawString(Uab.ToString("F3"), font1, drawBrush2, m_w, y0 - (size.Height / 2), drawFormat);
                    }
                    i++;

                    graphics.DrawLine(pen, new PointF(0, y0), new PointF(m_w, y0));

                    Uab += Uab_step;
                }

                graphics.DrawString("U", font2, drawBrush2, m_w, m_h, drawFormat);

                //vertical Ia
                var maxIa = MaxIa();
                var Ia_step = m_settings.Ia_step;
                var Ia = Ia_step;

                var Ia_mark_step = (int) ((maxIa / Ia_step) / 15);
                if(Ia_mark_step < 5)
                {
                    Ia_mark_step = 5;
                }                

                i = 1;
                while (Ia < maxIa)
                {
                    float x0 = (float)(m_w / maxIa * Ia);

                    if (i % Ia_mark_step == 0)
                    {
                        var size = graphics.MeasureString(Ia.ToString("F3"), font1);                        
                        graphics.DrawString(Ia.ToString("F3"), font1, drawBrush1, x0 - (size.Width / 2), m_h, drawFormat);
                    }
                    i++;

                    graphics.DrawLine(pen, new PointF(x0, 0), new PointF(x0, m_h));                    

                    Ia += Ia_step;
                }

                graphics.DrawString("I", font2, drawBrush1, 0, m_h, drawFormat);
            }
        }
    }
}
