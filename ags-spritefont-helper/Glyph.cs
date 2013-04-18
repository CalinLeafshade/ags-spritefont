using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace AGSSpriteFontGen
{
    class Glyph
    {
        string charNum,x,y,width,height;
        

        public Glyph(string charNum, string x, string y, string width, string height)
        {
            this.charNum = charNum;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public override string ToString()
        {
            return String.Format("Character: {0}, Rectangle: {1} {2} {3} {4}", charNum, x, y, width, height);
        }

        public string ToAGSScript(string fontToReplace)
        {
            return String.Format("SetGlyph({0}, {1}, {2}, {3}, {4}, {5});", fontToReplace, charNum, x, y, width, height);
        }

    }
}
