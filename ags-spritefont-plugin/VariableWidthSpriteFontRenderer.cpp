#include "VariableWidthSpriteFontRenderer.h"
#include <string>
#include "color.h"

VariableWidthSpriteFontRenderer::VariableWidthSpriteFontRenderer(IAGSEngine *engine)
{
	_engine = engine;
}

VariableWidthSpriteFontRenderer::~VariableWidthSpriteFontRenderer(void)
{
}

bool VariableWidthSpriteFontRenderer::SupportsExtendedCharacters(int fontNumber) { return false; }

int VariableWidthSpriteFontRenderer::GetTextWidth(const char *text, int fontNumber)
{
	int total = 0;
	VariableWidthFont *font = getFontFor(fontNumber);
	for(size_t i = 0; i < strlen(text); i++)
	{
		if (font->characters.count(text[i]) > 0)
		{
			total += font->characters[text[i]].Width;
			if (text[i] != ' ') total += font->Spacing;
		}
	}
	return total;
}

int VariableWidthSpriteFontRenderer::GetTextHeight(const char *text, int fontNumber)
{
	VariableWidthFont *font = getFontFor(fontNumber);
	for(size_t i = 0; i < strlen(text); i++)
	{
		if (font->characters.count(text[i]) > 0)
		{
			return font->characters[text[i]].Height;
		}
	}
	return 0;
}

void VariableWidthSpriteFontRenderer::SetSpacing(int fontNum, int spacing)
{
	VariableWidthFont *font = getFontFor(fontNum);
	font->Spacing = spacing;
	
}

void VariableWidthSpriteFontRenderer::EnsureTextValidForFont(char *text, int fontNumber)
{
	VariableWidthFont *font = getFontFor(fontNumber);
	std::string s(text);
	
	for(int i = s.length() - 1; i >= 0 ; i--)
	{
		if (font->characters.count(s[i]) == 0)
		{
			s.erase(i,1);
		}
	}
	
	strcpy(text,s.c_str());
	
}

void VariableWidthSpriteFontRenderer::SetGlyph(int fontNum, int charNum, int x, int y, int width, int height)
{
	VariableWidthFont *font = getFontFor(fontNum);
	font->SetGlyph(charNum, x, y, width, height);
}


void VariableWidthSpriteFontRenderer::SetSprite(int fontNum, int spriteNum)
{
	VariableWidthFont *font = getFontFor(fontNum);
	font->SpriteNumber = spriteNum;
}

VariableWidthFont *VariableWidthSpriteFontRenderer::getFontFor(int fontNum){
	VariableWidthFont *font;
	for (size_t i = 0; i < _fonts.size(); i ++)
	{
		font = _fonts.at(i);
		if (font->FontReplaced == fontNum) return font;
	}
	//not found
	font = new VariableWidthFont;
	font->FontReplaced = fontNum;
	_fonts.push_back(font);
	return font;
}

void VariableWidthSpriteFontRenderer::RenderText(const char *text, int fontNumber, BITMAP *destination, int x, int y, int colour)
{
	VariableWidthFont *font = getFontFor(fontNumber);
	int totalWidth = 0;
	for(size_t i = 0; i < strlen(text); i++)
	{
		char c = text[i];
				
		BITMAP *src = _engine->GetSpriteGraphic(font->SpriteNumber);
		Draw(src, destination, x + totalWidth, y, font->characters[c].X, font->characters[c].Y, font->characters[c].Width, font->characters[c].Height); 
		totalWidth += font->characters[c].Width;
		if (text[i] != ' ') totalWidth += font->Spacing;
	}
	
}


void VariableWidthSpriteFontRenderer::Draw(BITMAP *src, BITMAP *dest, int destx, int desty, int srcx, int srcy, int width, int height)
{

	long srcWidth, srcHeight, destWidth, destHeight, srcColDepth, destColDepth;

	unsigned char **srccharbuffer = _engine->GetRawBitmapSurface (src); //8bit
	unsigned short **srcshortbuffer = (unsigned short**)srccharbuffer; //16bit;
    unsigned long **srclongbuffer = (unsigned long**)srccharbuffer; //32bit

	unsigned char **destcharbuffer = _engine->GetRawBitmapSurface (dest); //8bit
	unsigned short **destshortbuffer = (unsigned short**)destcharbuffer; //16bit;
    unsigned long **destlongbuffer = (unsigned long**)destcharbuffer; //32bit

	int transColor = _engine->GetBitmapTransparentColor(src);

	_engine->GetBitmapDimensions(src, &srcWidth, &srcHeight, &srcColDepth);
	_engine->GetBitmapDimensions(dest, &destWidth, &destHeight, &destColDepth);
	
	if (srcy + height > srcHeight || srcx + width > srcWidth || srcx < 0 || srcy < 0) return;

	if (width + destx > destWidth) width = destWidth - destx;
	if (height + desty > destHeight) height = destHeight - desty;

	int startx = MAX(0, (-1 * destx));
	int starty = MAX(0, (-1 * desty));

	
	int srca, srcr, srcg, srcb, desta, destr, destg, destb, finalr, finalg, finalb, finala, col;

	for(int x = startx; x < width; x ++)
	{
		
		for(int y = starty; y <  height; y ++)
		{
			int srcyy = y + srcy;
			int srcxx = x + srcx;
			int destyy = y + desty;
			int destxx = x + destx;
				if (destColDepth == 8)
				{
					if (srccharbuffer[srcyy][srcxx] != transColor) destcharbuffer[destyy][destxx] = srccharbuffer[srcyy][srcxx];
				}
				else if (destColDepth == 16)
				{
					if (srcshortbuffer[srcyy][srcxx] != transColor) destshortbuffer[destyy][destxx] = srcshortbuffer[srcyy][srcxx];
				}
				else if (destColDepth == 32)
				{
					//if (srclongbuffer[srcyy][srcxx] != transColor) destlongbuffer[destyy][destxx] = srclongbuffer[srcyy][srcxx];
					
					srca =  (geta32(srclongbuffer[srcyy][srcxx]));
            
					if (srca != 0) {
						   
						srcr =  getr32(srclongbuffer[srcyy][srcxx]);  
						srcg =  getg32(srclongbuffer[srcyy][srcxx]);
						srcb =  getb32(srclongbuffer[srcyy][srcxx]);
    
						destr =  getr32(destlongbuffer[destyy][destxx]);
						destg =  getg32(destlongbuffer[destyy][destxx]);
						destb =  getb32(destlongbuffer[destyy][destxx]);
						desta =  geta32(destlongbuffer[destyy][destxx]);
                

						finalr = srcr;
						finalg = srcg;
						finalb = srcb;   
              
                                                               
						finala = 255-(255-srca)*(255-desta)/255;                                              
						finalr = srca*finalr/finala + desta*destr*(255-srca)/finala/255;
						finalg = srca*finalg/finala + desta*destg*(255-srca)/finala/255;
						finalb = srca*finalb/finala + desta*destb*(255-srca)/finala/255;
						col = makeacol32(finalr, finalg, finalb, finala);
						destlongbuffer[destyy][destxx] = col;
					}

				}
		}
	}
	
	_engine->ReleaseBitmapSurface(src);
	_engine->ReleaseBitmapSurface(dest);

	

}

