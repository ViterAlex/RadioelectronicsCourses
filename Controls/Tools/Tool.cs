using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace Controls
{
    public abstract class Tool
    {
        public event EventHandler Done;
        public ToolKind ToolKind;
        public virtual void MouseUp(MouseEventArgs e);
        public virtual void MouseDown(MouseEventArgs e);
        public virtual void MouseMove(MouseEventArgs e);
        public virtual void MouseClick(MouseEventArgs e);
        public virtual Action<Graphics> GetAction(){ return null;}

        public virtual SolidBrush Brush{get;set;};
        public virtual Pen Pen{get;set;};

        protected virtual void OnDone()
        {
            EventHandler temp = Done;
            if (temp != null)
            {
                temp(this, EventArgs.Empty);
            }
        }
    }
    
}
