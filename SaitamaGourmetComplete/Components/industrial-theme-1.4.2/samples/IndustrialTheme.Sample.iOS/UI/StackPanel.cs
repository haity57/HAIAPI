using System;
using UIKit;
using System.Drawing;

namespace ThemeSample
{
	public class StackPanel : UIView 
	{
		int columns = 1;
		
		public int Columns {
			get{ return columns;}
			set {
				if (columns == value)
					return;
				columns = value;
				this.SetNeedsLayout();
			}
		}
		
		public StackPanel ()
		{
			init ();
		}
		
		public StackPanel (RectangleF rect) : base(rect)
		{
			init ();
		}
		
		void init ()
		{
			this.BackgroundColor = UIColor.Clear;
		}
		
		float padding = 5;
		
		public float Padding {
			get{ return padding;}
			set { 
				if (padding == value)
					return;
				padding = value;
				LayoutSubviews ();
			}
		}
		public override void LayoutSubviews ()
		{
			float h = padding;
			var width = (this.Bounds.Width / columns) - (padding * 2);
			float columnH = 0;
			for (int i = 0; i < Subviews.Length; i++) {
				var col =  (i % columns);
				var view = Subviews[i];
				var frame = view.Frame;
				frame.X = padding + ((width + padding) * col);
				frame.Y = h;
				frame.Width = width;
				view.Frame = frame;
				columnH = (float) Math.Max(frame.Bottom + padding,columnH);
				if(col + 1 == columns)
					h = columnH;
			}
		}
	}
}

