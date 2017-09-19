using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BasicCustomControls
{
    public class ClipSegmentsMap : Control
    {

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020;   //WS_EX_TRANSPARENT 
                return cp;
            }
        }

        public enum Mode
        {
            Strict = 0,
            Indicatif = 1
        }

        public ClipSegmentsMap()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }


        private Mode _ViewMode = Mode.Indicatif;
        public Mode ViewMode
        {
            get { return _ViewMode; }
            set { _ViewMode = value; }
        }

        private int _Minimum;
        public int Minimum
        {
            get { return _Minimum; }
            set { _Minimum = value; }
        }

        private int _Maximum = 100;
        public int Maximum
        {
            get { return _Maximum; }
            set { _Maximum = value; }
        }

        private int _Value;
        public int Value
        {
            get { return _Value; }
            set
            {
                if (value > _Maximum) _Value = _Maximum;
                else if (value < _Minimum) _Value = _Minimum;
                else _Value = value;
                OnValueChanged();
            }
        }



        private Color _FreeSegmentTopColor = Color.LightGreen;
        public Color FreeSegmentTopColor
        {
            get { return _FreeSegmentTopColor; }
            set
            {
                _FreeSegmentTopColor = value;
                OnProgressTopColorChanged();
            }
        }

        private Color _FreeSegmentBottomColor = Color.LightGreen;
        public Color FreeSegmentBottomColor
        {
            get { return _FreeSegmentBottomColor; }
            set
            {
                _FreeSegmentBottomColor = value;
                OnProgressBottomColorChanged();
            }
        }

        private Color _UnAllowedSegmentTopColor = Color.Red;
        public Color UnAllowedSegmentTopColor
        {
            get { return _UnAllowedSegmentTopColor; }
            set
            {
                _UnAllowedSegmentTopColor = value;
                OnProgressTopColorChanged();
            }
        }

        private Color _UnAllowedSegmentBottomColor = Color.Red;
        public Color UnAllowedSegmentBottomColor
        {
            get { return _UnAllowedSegmentBottomColor; }
            set
            {
                _UnAllowedSegmentBottomColor = value;
                OnProgressBottomColorChanged();
            }
        }

        private Color _NoFreeSegmentBottomColor = Color.Orange;
        public Color NoFreeSegmentBottomColor
        {
            get { return _NoFreeSegmentBottomColor; }
            set
            {
                _NoFreeSegmentBottomColor = value;
                OnProgressBottomColorChanged();
            }
        }

        private Color _NoFreeSegmentTopColor = Color.Orange;
        public Color NoFreeSegmentTopColor
        {
            get { return _NoFreeSegmentTopColor; }
            set
            {
                _NoFreeSegmentTopColor = value;
                OnProgressBottomColorChanged();
            }
        }

        private Color _BackgroundColor = Color.LightGray;
        public Color BackgroundColor
        {
            get { return _BackgroundColor; }
            set
            {
                _BackgroundColor = value;
                //OnProgressTopColorChanged();
            }
        }




        private Color _BorderColor = Color.LightGray;
        public Color BorderColor
        {
            get { return _BorderColor; }
            set
            {
                _BorderColor = value;
                OnBorderColorChanged();
            }
        }

        protected void OnBorderColorChanged()
        {
            this.Invalidate();
        }

        protected void OnValueChanged()
        {
            this.Invalidate();
        }

        protected void OnProgressTopColorChanged()
        {
            this.Invalidate();
        }

        protected void OnProgressBottomColorChanged()
        {
            this.Invalidate();
        }

        GraphicsPath _Path;
        Rectangle _Rect;
        Rectangle _RectEffect;
        Brush _BackgroundBrush;
        Rectangle _RectBase;
        protected void GetPath()
        {
            Rectangle RcWindow = this.ClientRectangle;

            _Rect = new Rectangle(RcWindow.X, RcWindow.Y, RcWindow.Width - 1, RcWindow.Height - 1);
            _RectBase = new Rectangle(RcWindow.X + 1, RcWindow.Y + 1, RcWindow.Width - 2, RcWindow.Height - 2);
            _Path = GetRoundedRectPath(_Rect, 1);
            _RectEffect = new Rectangle(RcWindow.X + 1, RcWindow.Y + 1, (RcWindow.Width - 3), (RcWindow.Height / 2));
            _BackgroundBrush = new LinearGradientBrush(_Rect, Color.White, _BackgroundColor, LinearGradientMode.Vertical);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            GetPath();
        }

        protected Rectangle GetBadSegmentRect()
        {
            double value = _Value;
            double width = this.Width;
            double ratio = ((double)this.Width / (double)_Maximum);
            double progressWidth = (ratio * value) + 1;
            int rectWidth = (int)progressWidth;
            if (rectWidth < 1) rectWidth = 1;
            return new Rectangle(0, 0, rectWidth, this.Height - 1);
        }

        protected Rectangle GetFreeSegmentRect()
        {
            double value = _Value;
            double width = this.Width;
            double ratio = ((double)this.Width / (double)_Maximum);
            double progressWidth = (ratio * value) + 1;
            int rectWidth = (int)progressWidth;
            if (rectWidth < 1) rectWidth = 1;
            return new Rectangle(rectWidth, 0, this.Width - rectWidth, this.Height - 1);
        }

        protected void DrawBackGround(Graphics graphics)
        {
            if (_Path == null) GetPath();
            Pen p = new Pen(_BorderColor, 1);
            graphics.FillPath(_BackgroundBrush, _Path);
        }

        protected void DrawBorder(Graphics graphics)
        {
            if (_Path == null) GetPath();
            Pen p = new Pen(_BorderColor, 1);
            graphics.DrawPath(p, _Path);
            Rectangle r = _Rect;
            if (r.Width >= 3)
            {
                Color borderBottom = Color.FromArgb(_BorderColor.R - 40, _BorderColor.G - 40, _BorderColor.B - 40);
                graphics.DrawLine(new Pen(borderBottom, 1), new Point(1, r.Bottom - 1), new Point(r.Right - 1, r.Bottom - 1));
            }
        }


        private void DrawShadows(Graphics g, Rectangle rect)
        {
            LinearGradientBrush lg = new LinearGradientBrush
                                (rect, Color.White, Color.White,
                                     LinearGradientMode.Horizontal);

            ColorBlend lc = new ColorBlend(3);
            lc.Colors = new Color[] { Color.Transparent, Color.FromArgb(40, 0, 0, 0), Color.Transparent };
            lc.Positions = new float[] { 0.0F, 0.2F, 1.0F };
            lg.InterpolationColors = lc;

            g.FillRectangle(lg, rect);
        }



        protected void DrawSegments(Graphics graphics)
        {
            try
            {
                if (_Value == int.MaxValue)
                {
                    DrawBackGround(graphics);
                    return;
                }
                if (_Value == 0)
                {
                    if (_Path == null) GetPath();
                    using (LinearGradientBrush BrushProgress = new LinearGradientBrush(_Rect, Color.Yellow, Color.Orange, LinearGradientMode.Vertical))
                    {
                        graphics.FillPath(BrushProgress, _Path);
                    }
                    return;
                }
             
                
                
                Rectangle valueRect = GetBadSegmentRect();

                Color unAllowedTop = (this.ViewMode == Mode.Indicatif) ? _NoFreeSegmentTopColor : _UnAllowedSegmentTopColor;
                Color unAllowedBottom = (this.ViewMode == Mode.Indicatif) ? _NoFreeSegmentBottomColor : _UnAllowedSegmentBottomColor;

                using (LinearGradientBrush BrushProgress = new LinearGradientBrush(valueRect, unAllowedTop, unAllowedBottom, LinearGradientMode.Vertical))
                {
                    using (GraphicsPath PathProgress = GetRoundedRectPath(valueRect, 1))
                    {
                        graphics.FillPath(BrushProgress, PathProgress);

                        ColorBlend lc = new ColorBlend(3);
                        lc.Colors = new Color[] { Color.FromArgb(164, Color.White), Color.Transparent, Color.Transparent/*Color.FromArgb(128, _ProgressBottomColor)*/ };
                        lc.Positions = new float[] { 0.0F, 0.5F, 1.0F };
                        BrushProgress.InterpolationColors = lc;

                        using (GraphicsPath PathEffect = GetRoundedRectPath(_Rect, 1))
                        {
                            graphics.FillPath(BrushProgress, PathEffect);
                        }
                    }
                }

                Rectangle badRect = GetFreeSegmentRect();
                using (LinearGradientBrush BrushProgress = new LinearGradientBrush(badRect, _FreeSegmentTopColor, _FreeSegmentBottomColor, LinearGradientMode.Vertical))
                {
                    using (GraphicsPath PathProgress = GetRoundedRectPath(badRect, 1))
                    {
                        graphics.FillPath(BrushProgress, PathProgress);

                        ColorBlend lc = new ColorBlend(3);
                        lc.Colors = new Color[] { Color.FromArgb(164, Color.White), Color.Transparent, Color.Transparent/*Color.FromArgb(128, _ProgressBottomColor)*/ };
                        lc.Positions = new float[] { 0.0F, 0.5F, 1.0F };
                        BrushProgress.InterpolationColors = lc;

                        using (GraphicsPath PathEffect = GetRoundedRectPath(_Rect, 1))
                        {
                            graphics.FillPath(BrushProgress, PathEffect);
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        protected void SetGraphics(Graphics graphics)
        {
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            try
            {
                Graphics g = e.Graphics;
                SetGraphics(g);

                DrawBackGround(g);
                DrawSegments(g);
                DrawBorder(g);
            }
            catch (Exception) { }
        }

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = 2 * radius;

            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();

            path.AddArc(arcRect, 180, 90);
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);
            arcRect.Y = rect.Bottom - diameter - 1;
            path.AddArc(arcRect, 0, 90);
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();

            return path;
        }

    }
}
