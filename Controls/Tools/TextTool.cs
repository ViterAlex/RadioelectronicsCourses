using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Controls.Tools
{
    public class TextTool : Tool
    {
        private TextBox _editField;
        private string _text;
        public override void MouseClick(MouseEventArgs e)
        {
            base.MouseClick(e);
            if (_editField != null && !_editField.Bounds.Contains(e.Location))
            {
                LostFocus();
            }
            if (_points.Count == 0)
                _points.Add(e.Location);
            else
                _points[0] = e.Location;

            if (_editField == null)
            {
                _editField = new TextBox() { Location = _points[0] };
            }
        }

        private void LostFocus()
        {
            Parent.Controls.Remove(_editField);
            _text = _editField.Text;
            _editField.Dispose();
            _editField = null;
            OnDone();
        }

        public override void MouseDown(MouseEventArgs e)
        {
            base.MouseDown(e);
        }
        public override void MouseUp(MouseEventArgs e)
        {
        }
        public override void MouseMove(MouseEventArgs e)
        {
            base.MouseMove(e);
        }
        public override Action<Graphics> GetAction()
        {
            if (_editField == null || string.IsNullOrWhiteSpace(_editField.Text))
            {
                return null;
            }
            return new Action<Graphics>(g =>
            {
                var pt = _points[0];
                g.DrawString(_text, Font, Fill, pt);
            });
        }
        public override ToolKind ToolKind => ToolKind.Text;
    }
}
