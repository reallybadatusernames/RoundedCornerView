using System;
using System.ComponentModel;

using Foundation;
using UIKit;
using CoreGraphics;
using CoreAnimation;

namespace RoundedCornerView
{

    [DesignTimeVisible(true), Register("RoundedCornerView"), Category("Custom Controls")]
    public class RoundedCornerView : UIView, IComponent
    {
        #region IComponent Implementation

        public event EventHandler Disposed;
        public ISite Site { get; set; }

        #endregion

        #region Properties

        [DisplayName("Bottom Left Corner Radius"), Export("BottomLeftCorner"), Browsable(true)]
        public bool BottomLeftCorner { get; set; } = true;

        [DisplayName("Bottom Right Corner Radius"), Export("BottomRightCorner"), Browsable(true)]
        public bool BottomRightCorner { get; set; } = true;

        [DisplayName("Top Left Corner Radius"), Export("TopLeftCorner"), Browsable(true)]
        public bool TopLeftCorner { get; set; }

        [DisplayName("Top Right Corner Radius"), Export("TopRightCorner"), Browsable(true)]
        public bool TopRightCorner { get; set; }

        [DisplayName("Corner Radius"), Export("CornerRadius"), Browsable(true)]
        public float CornerRadius { get; set; } = 20f;
        #endregion

        #region Constructors/Overrides

        public RoundedCornerView() : base() { }

        public RoundedCornerView(CGRect frame) : base(frame) { }

        public RoundedCornerView(IntPtr handle) : base(handle) { }

        public RoundedCornerView(NSCoder coder) : base(coder) { }

        public RoundedCornerView(NSObjectFlag t) : base(t) { }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
        }

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
            drawBackground();
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
        }

        #endregion

        #region Methods

        private void drawBackground()
        {
            //create mask layer
            var maskLayer = new CAShapeLayer();
            maskLayer.Bounds = this.Frame;
            maskLayer.Position = this.Center;
            UIBezierPath path = UIBezierPath.FromRoundedRect(this.Bounds, corners(), new CGSize(CornerRadius, CornerRadius));
            maskLayer.Path = path.CGPath;

            this.Layer.Mask = maskLayer;
        }

        private UIRectCorner corners()
        {
            if (TopLeftCorner && TopRightCorner && BottomLeftCorner && BottomRightCorner)
                return (UIRectCorner.AllCorners);
            if (TopLeftCorner && !TopRightCorner && !BottomLeftCorner && !BottomRightCorner)
                return (UIRectCorner.TopLeft);
            if (TopLeftCorner && TopRightCorner && !BottomLeftCorner && !BottomRightCorner)
                return (UIRectCorner.TopLeft | UIRectCorner.TopRight);
            if (TopLeftCorner && TopRightCorner && BottomLeftCorner && !BottomRightCorner)
                return (UIRectCorner.TopLeft | UIRectCorner.TopRight | UIRectCorner.BottomLeft);
            if (TopRightCorner && !TopLeftCorner && !BottomLeftCorner && !BottomRightCorner)
                return (UIRectCorner.TopRight);
            if (TopRightCorner && BottomRightCorner && !BottomLeftCorner && !TopLeftCorner)
                return (UIRectCorner.TopRight | UIRectCorner.BottomRight);
            if (TopRightCorner && BottomLeftCorner && !BottomRightCorner && !TopLeftCorner)
                return (UIRectCorner.TopRight | UIRectCorner.BottomLeft);
            if (BottomLeftCorner && !BottomRightCorner && !TopLeftCorner && !TopRightCorner)
                return (UIRectCorner.BottomLeft);
            if (BottomLeftCorner && BottomRightCorner && !TopLeftCorner && !TopRightCorner)
                return (UIRectCorner.BottomLeft | UIRectCorner.BottomRight);
            if (BottomLeftCorner && BottomRightCorner && TopRightCorner && !TopLeftCorner)
                return (UIRectCorner.BottomLeft | UIRectCorner.BottomRight | UIRectCorner.TopRight);
            if (BottomLeftCorner && BottomRightCorner && TopLeftCorner && !TopRightCorner)
                return (UIRectCorner.BottomLeft | UIRectCorner.BottomRight | UIRectCorner.TopLeft);
            if (BottomRightCorner && !BottomLeftCorner && !TopLeftCorner && !TopRightCorner)
                return (UIRectCorner.BottomRight);

            return UIRectCorner.AllCorners;
        }

        #endregion
    }
}