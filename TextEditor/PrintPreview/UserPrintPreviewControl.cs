using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TextEditor.PrintPreview
{
    internal enum ZoomMode
        {
            ActualSize,
            FullPage,
            PageWidth,
            TwoPages,
            Custom
        }
    internal partial class UserPrintPreviewControl : UserControl
    {
            //InitializeComponent();

            ////
            PrintDocument doc;
            ZoomMode zoomMode;
            double zoom;
            int startPage;
            Brush backBrush;
            Point ptLast;
            PointF himm2pix = new PointF(-1, -1);
            PageImageList img = new PageImageList();
            bool cancel, rendering;

            const int MARGIN = 4;

        public UserPrintPreviewControl()
        {
            BackColor = SystemColors.AppWorkspace;
            ZoomMode = ZoomMode.FullPage;
            StartPage = 0;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        public PrintDocument Document
        {
            get { return doc; }
            set
            {
                if (value != doc)
                {
                    doc = value;
                    RefreshPreview();
                }
            }
        }

        public void RefreshPreview()
        {
            //Render into PrintController
            if (doc != null)
            {
                //Prepare to render preview document
                img.Clear();
                PrintController savePC = doc.PrintController;

                //Render preview document
                try
                {
                    cancel = false;
                    rendering = true;
                    doc.PrintController = new PreviewPrintController();
                    doc.PrintPage += doc_PrintPage;
                    doc.EndPrint += doc_EndPrint;
                    doc.Print();
                }
                finally
                {
                    cancel = false;
                    rendering = false;
                    doc.PrintPage -= doc_PrintPage;
                    doc.EndPrint -= doc_EndPrint;
                    doc.PrintController = savePC;
                }
            }

            //Update
            OnPageCountChanged(EventArgs.Empty);
            UpdatePreview();
            UpdateScrollBars();
        }

        public void Cancel()
        {
            cancel = true;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsRendering
        {
            get { return rendering; }
        }
      
        //Gets or sets how the zoom should be adjusted when the control is resized.
       
        [DefaultValue(ZoomMode.FullPage)]
        public ZoomMode ZoomMode
        {
            get { return zoomMode; }
            set
            {
                if (value != zoomMode)
                {
                    zoomMode = value;
                    UpdateScrollBars();
                    OnZoomModeChanged(EventArgs.Empty);
                }
            }
        }

        [Browsable(false),DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double Zoom
        {
            get { return zoom; }
            set
            {
                if (value != zoom || ZoomMode != ZoomMode.Custom)
                {
                    ZoomMode = ZoomMode.Custom;
                    zoom = value;
                    UpdateScrollBars();
                    OnZoomModeChanged(EventArgs.Empty);
                }
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int StartPage
        {
            get { return startPage; }
            set
            {
                // validate new setting
                if (value > PageCount - 1) value = PageCount - 1;
                if (value < 0) value = 0;

                // apply new setting
                if (value != startPage)
                {
                    startPage = value;
                    UpdateScrollBars();
                    OnStartPageChanged(EventArgs.Empty);
                }
            }
        }

        [Browsable(false),DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int PageCount
        {
            get { return img.Count; }
        }
        
        //Gets or sets the control's background color.
        [DefaultValue(typeof(Color), "AppWorkspace")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                backBrush = new SolidBrush(value);
            }
        }

        // Gets a list containing the images of the pages in the document.
        [Browsable(false)]
        public PageImageList PageImages
        {
            get { return img; }
        }
       
        // Prints the current document honoring the selected page range.
        public void Print()
        {
            // select pages to print
            var ps = doc.PrinterSettings;
            int first = ps.MinimumPage - 1;
            int last = ps.MaximumPage - 1;
            switch (ps.PrintRange)
            {
                case PrintRange.AllPages:
                    Document.Print();
                    return;
                case PrintRange.CurrentPage:
                    first = last = StartPage;
                    break;
                case PrintRange.Selection:
                    first = last = StartPage;
                    if (ZoomMode == ZoomMode.TwoPages)
                    {
                        last = Math.Min(first + 1, PageCount - 1);
                    }
                    break;
                case PrintRange.SomePages:
                    first = ps.FromPage - 1;
                    last = ps.ToPage - 1;
                    break;
            }

            // print using helper class
            var dp = new DocumentPrinter(this, first, last);
            dp.Print();
        }

        //!!! Events
        public event EventHandler StartPageChanged;
       
        protected void OnStartPageChanged(EventArgs e)
        {
            if (StartPageChanged != null)
            {
                StartPageChanged(this, e);
            }
        }
           
        public event EventHandler PageCountChanged;
   
        protected void OnPageCountChanged(EventArgs e)
        {
            if (PageCountChanged != null)
            {
                PageCountChanged(this, e);
            }
        }
        
        public event EventHandler ZoomModeChanged;
       
        protected void OnZoomModeChanged(EventArgs e)
        {
            if (ZoomModeChanged != null)
            {
                ZoomModeChanged(this, e);
            }
        }

        //!!! OverRide

        //Painting
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Image img = GetImage(StartPage);
            if (img != null)
            {
                Rectangle rc = GetImageRectangle(img);
                if (rc.Width > 2 && rc.Height > 2)
                {
                    // adjust for scrollbars
                    rc.Offset(AutoScrollPosition);

                    // render single page
                    if (zoomMode != ZoomMode.TwoPages)
                    {
                        RenderPage(e.Graphics, img, rc);
                    }
                    else // render two pages
                    {
                        // render first page
                        rc.Width = (rc.Width - MARGIN) / 2;
                        RenderPage(e.Graphics, img, rc);

                        // render second page
                        img = GetImage(StartPage + 1);
                        if (img != null)
                        {
                            // update bounds in case orientation changed
                            rc = GetImageRectangle(img);
                            rc.Width = (rc.Width - MARGIN) / 2;

                            // render second page
                            rc.Offset(rc.Width + MARGIN, 0);
                            RenderPage(e.Graphics, img, rc);
                        }
                    }
                }
            }

            //Paint background
            e.Graphics.FillRectangle(backBrush, ClientRectangle);
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            UpdateScrollBars();
            base.OnSizeChanged(e);
        }

        //Pan by dragging preview pane
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left && AutoScrollMinSize != Size.Empty)
            {
                Cursor = Cursors.NoMove2D;
                ptLast = new Point(e.X, e.Y);
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left && Cursor == Cursors.NoMove2D)
                Cursor = Cursors.Default;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (Cursor == Cursors.NoMove2D)
            {
                int dx = e.X - ptLast.X;
                int dy = e.Y - ptLast.Y;
                if (dx != 0 || dy != 0)
                {
                    Point pt = AutoScrollPosition;
                    AutoScrollPosition = new Point(-(pt.X + dx), -(pt.Y + dy));
                    ptLast = new Point(e.X, e.Y);
                }
            }
        }

        //Keyboard
        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Right:
                case Keys.Down:
                case Keys.PageUp:
                case Keys.PageDown:
                case Keys.Home:
                case Keys.End:
                    return true;
            }
            return base.IsInputKey(keyData);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.Handled)
                return;

            switch (e.KeyCode)
            {
                // arrow keys scroll or browse, depending on ZoomMode
                case Keys.Left:
                case Keys.Up:
                case Keys.Right:
                case Keys.Down:

                    // browse
                    if (ZoomMode == ZoomMode.FullPage || ZoomMode == ZoomMode.TwoPages)
                    {
                        switch (e.KeyCode)
                        {
                            case Keys.Left:
                            case Keys.Up:
                                StartPage--;
                                break;
                            case Keys.Right:
                            case Keys.Down:
                                StartPage++;
                                break;
                        }
                        break;
                    }

                    //Scroll
                    Point pt = AutoScrollPosition;
                    switch (e.KeyCode)
                    {
                        case Keys.Left: pt.X += 20; break;
                        case Keys.Right: pt.X -= 20; break;
                        case Keys.Up: pt.Y += 20; break;
                        case Keys.Down: pt.Y -= 20; break;
                    }
                    AutoScrollPosition = new Point(-pt.X, -pt.Y);
                    break;

                //page up/down browse pages
                case Keys.PageUp:
                    StartPage--;
                    break;
                case Keys.PageDown:
                    StartPage++;
                    break;

                //home/end 
                case Keys.Home:
                    AutoScrollPosition = Point.Empty;
                    StartPage = 0;
                    break;
                case Keys.End:
                    AutoScrollPosition = Point.Empty;
                    StartPage = PageCount - 1;
                    break;

                default:
                    return;
            }

            //If we got here, the event was handled
            e.Handled = true;
        }

        //Impliments
        void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            SyncPageImages(false);
            if (cancel)
            {
                e.Cancel = true;
            }
        }
        void doc_EndPrint(object sender, PrintEventArgs e)
        {
            SyncPageImages(true);
        }
        void SyncPageImages(bool lastPageReady)
        {
            var pv = (PreviewPrintController)doc.PrintController;
            if (pv != null)
            {
                var pageInfo = pv.GetPreviewPageInfo();
                int count = lastPageReady ? pageInfo.Length : pageInfo.Length - 1;
                for (int i = img.Count; i < count; i++)
                {
                    var imgPage = pageInfo[i].Image;
                    img.Add(imgPage);

                    OnPageCountChanged(EventArgs.Empty);

                    if (StartPage < 0) StartPage = 0;
                    if (i == StartPage || i == StartPage + 1)
                    {
                        Refresh();
                    }
                    Application.DoEvents();
                }
            }
        }
        Image GetImage(int page)
        {
            return page > -1 && page < PageCount ? img[page] : null;
        }
        Rectangle GetImageRectangle(Image img)
        {
            //Start with regular image rectangle
            Size sz = GetImageSizeInPixels(img);
            Rectangle rc = new Rectangle(0, 0, sz.Width, sz.Height);

            //Calculate zoom
            Rectangle rcCli = this.ClientRectangle;
            switch (zoomMode)
            {
                case ZoomMode.ActualSize:
                    zoom = 1;
                    break;
                case ZoomMode.TwoPages:
                    rc.Width *= 2; // Two pages side-by-side
                    goto case ZoomMode.FullPage;
                case ZoomMode.FullPage:
                    double zoomX = (rc.Width > 0) ? rcCli.Width / (double)rc.Width : 0;
                    double zoomY = (rc.Height > 0) ? rcCli.Height / (double)rc.Height : 0;
                    zoom = Math.Min(zoomX, zoomY);
                    break;
                case ZoomMode.PageWidth:
                    zoom = (rc.Width > 0) ? rcCli.Width / (double)rc.Width : 0;
                    break;
            }

            //Apply zoom factor
            rc.Width = (int)(rc.Width * zoom);
            rc.Height = (int)(rc.Height * zoom);

            //Center image
            int dx = (rcCli.Width - rc.Width) / 2;
            if (dx > 0) rc.X += dx;
            int dy = (rcCli.Height - rc.Height) / 2;
            if (dy > 0) rc.Y += dy;

            // add some extra space
            rc.Inflate(-MARGIN, -MARGIN);
            if (zoomMode == ZoomMode.TwoPages)
            {
                rc.Inflate(-MARGIN / 2, 0);
            }
                        
            return rc;
        }
        Size GetImageSizeInPixels(Image img)
        {
            //Get image size
            SizeF szf = img.PhysicalDimension;

            // if it is a metafile, convert to pixels
            if (img is Metafile)
            {
                // get screen resolution
                if (himm2pix.X < 0)
                {
                    using (Graphics g = this.CreateGraphics())
                    {
                        himm2pix.X = g.DpiX / 2540f;
                        himm2pix.Y = g.DpiY / 2540f;
                    }
                }

                // convert himetric to pixels
                szf.Width *= himm2pix.X;
                szf.Height *= himm2pix.Y;
            }

            return Size.Truncate(szf);
        }
        void RenderPage(Graphics g, Image img, Rectangle rc)
        {
            //Draw the page
            rc.Offset(1, 1);
            g.DrawRectangle(Pens.Black, rc);
            rc.Offset(-1, -1);
            g.FillRectangle(Brushes.White, rc);
            g.DrawImage(img, rc);
            g.DrawRectangle(Pens.Black, rc);

            // exclude cliprect to paint background later
            rc.Width++;
            rc.Height++;
            g.ExcludeClip(rc);
            rc.Offset(1, 1);
            g.ExcludeClip(rc);
        }
        void UpdateScrollBars()
        {
            //Get image rectangle to adjust scroll size
            Rectangle rc = Rectangle.Empty;
            Image img = this.GetImage(StartPage);
            if (img != null)
            {
                rc = GetImageRectangle(img);
            }

            // calculate new scroll size
            Size scrollSize = new Size(0, 0);
            switch (zoomMode)
            {
                case ZoomMode.PageWidth:
                    scrollSize = new Size(0, rc.Height + 2 * MARGIN);
                    break;
                case ZoomMode.ActualSize:
                case ZoomMode.Custom:
                    scrollSize = new Size(rc.Width + 2 * MARGIN, rc.Height + 2 * MARGIN);
                    break;
            }

            //Apply if needed
            if (scrollSize != AutoScrollMinSize)
            {
                AutoScrollMinSize = scrollSize;
            }

            // ready to update
            UpdatePreview();
        }
        void UpdatePreview()
        {
            //Validate current page
            if (startPage < 0) startPage = 0;
            if (startPage > PageCount - 1) startPage = PageCount - 1;

            //Repaint
            Invalidate();
        }

        
        //!!! Class-helper that prints the selected page range in a PrintDocument.
        internal class DocumentPrinter : PrintDocument
        {
            int first, last, index;
            PageImageList imgList;

            public DocumentPrinter(UserPrintPreviewControl preview, int first, int last)
            {
                // save page range and image list
                first = first;
                last = last;
                imgList = preview.PageImages;

                // copy page and printer settings from original document
                DefaultPageSettings = preview.Document.DefaultPageSettings;
                PrinterSettings = preview.Document.PrinterSettings;
            }

            protected override void OnBeginPrint(PrintEventArgs e)
            {
                // start from the first page
                index = first;
            }
            protected override void OnPrintPage(PrintPageEventArgs e)
            {
                // render the current page and increment the index
                e.Graphics.PageUnit = GraphicsUnit.Display;
                e.Graphics.DrawImage(imgList[index++], e.PageBounds);

                // stop when we reach the last page in the range
                e.HasMorePages = index <= last;
            }
        }



    }
}
