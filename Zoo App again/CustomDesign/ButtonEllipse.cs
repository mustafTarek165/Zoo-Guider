using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_App_again.CustomDesign
{
    public class ButtonEllipse:Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            GraphicsPath graphics=new GraphicsPath();   
            graphics.AddEllipse(0,0,ClientSize.Width,ClientSize.Height);
            this.Region = new System.Drawing.Region(graphics);
            base.OnPaint(pevent);
        }
    }
}
