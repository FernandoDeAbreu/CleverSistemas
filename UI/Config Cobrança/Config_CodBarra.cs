using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace Sistema.UI
{
    class Barra2de5 : Config_CodBarra
    {
        #region VARIAVEIS DIVERSAS
        private string[] cPattern = new string[100];
        private const string START = "0000";
        private const string STOP = "1000";
        private Bitmap bitmap;
        private Graphics g;
        #endregion

        #region CONSTRUTORES
        public Barra2de5()
        {
        }

        public Barra2de5(string Code, int BarWidth, int Height)
        {
            this.Code = Code;
            this.Height = Height;
            this.Width = BarWidth;
        }

        public Barra2de5(string Code, int BarWidth, int Height, int Digits)
        {
            this.Code = Code;
            this.Height = Height;
            this.Width = BarWidth;
            this.Digits = Digits;
        }
        #endregion

        private void FillPatern()
        {
            int f;
            string strTemp;

            if (cPattern[0] == null)
            {
                cPattern[0] = "00110";
                cPattern[1] = "10001";
                cPattern[2] = "01001";
                cPattern[3] = "11000";
                cPattern[4] = "00101";
                cPattern[5] = "10100";
                cPattern[6] = "01100";
                cPattern[7] = "00011";
                cPattern[8] = "10010";
                cPattern[9] = "01010";
                //Create a draw pattern for each char from 0 to 99
                for (int f1 = 9; f1 >= 0; f1--)
                {
                    for (int f2 = 9; f2 >= 0; f2--)
                    {
                        f = f1 * 10 + f2;
                        strTemp = "";
                        for (int i = 0; i < 5; i++)
                        {
                            strTemp += cPattern[f1][i].ToString() + cPattern[f2][i].ToString();
                        }
                        cPattern[f] = strTemp;
                    }
                }
            }
        }

        public Bitmap ToBitmap()
        {
            int i;
            string ftemp;

            xPos = 0;
            yPos = 0;

            if (this.Digits == 0)
            {
                this.Digits = this.Code.Length;
            }

            if (this.Digits % 2 > 0) this.Digits++;

            while (this.Code.Length < this.Digits || this.Code.Length % 2 > 0)
            {
                this.Code = "0" + this.Code;
            }

            int _width = (2 * Full + 3 * Thin) * (Digits) + 7 * Thin + Full;

            bitmap = new Bitmap(_width, Height);
            g = Graphics.FromImage(bitmap);

            //Start Pattern
            DrawPattern(ref g, START);

            //Draw code
            this.FillPatern();
            while (this.Code.Length > 0)
            {
                i = Convert.ToInt32(this.Code.Substring(0, 2));
                if (this.Code.Length > 2)
                    this.Code = this.Code.Substring(2, this.Code.Length - 2);
                else
                    this.Code = "";
                ftemp = cPattern[i];
                DrawPattern(ref g, ftemp);
            }

            //Stop Patern
            DrawPattern(ref g, STOP);

            return bitmap;
        }

        public byte[] ToByte()
        {
            return base.toByte(ToBitmap());
        }
    }

    public abstract class Config_CodBarra
    {

        #region VARIAVEIS DIVERSAS
        private string _code;
        private int _height;
        private int _digits;

        private int _thin;
        private int _full;

        protected int xPos = 0;
        protected int yPos = 0;

        private string _contenttype;

        protected Brush BLACK = Brushes.Black;
        protected Brush WHITE = Brushes.White;

        #endregion

        #region PROPRIEDADES
        public string Code
        {
            get
            {
                try
                {
                    return _code;
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                try
                {
                    _code = value;
                }
                catch
                {
                    _code = null;
                }
            }
        }
       
        public int Width
        {
            get
            {
                try
                {
                    return _thin;
                }
                catch
                {
                    return 1;
                }
            }
            set
            {
                try
                {
                    int temp = value;
                    _thin = temp;
                    //					_half = temp * 2;
                    _full = temp * 3;
                }
                catch
                {
                    int temp = 1;
                    _thin = temp;
                    //					_half = temp * 2;
                    _full = temp * 3;
                }
            }
        }
     
        public int Height
        {
            get
            {
                try
                {
                    return _height;
                }
                catch
                {
                    return 15;
                }
            }
            set
            {
                try
                {
                    _height = value;
                }
                catch
                {
                    _height = 1;
                }
            }
        }
        
        public int Digits
        {
            get
            {
                try
                {
                    return _digits;
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                try
                {
                    _digits = value;
                }
                catch
                {
                    _digits = 0;
                }
            }
        }
       
        public string ContentType
        {
            get
            {
                try
                {
                    if (_contenttype == null)
                        return "image/jpeg";
                    return _contenttype;
                }
                catch
                {
                    return "image/jpeg";
                }
            }
            set
            {
                try
                {
                    _contenttype = value;
                }
                catch
                {
                    _contenttype = "image/jpeg";
                }
            }
        }

        protected int Thin
        {
            get
            {
                try
                {
                    return _thin;
                }
                catch
                {
                    return 1;
                }
            }
        }

        protected int Full
        {
            get
            {
                try
                {
                    return _full;
                }
                catch
                {
                    return 3;
                }
            }
        }
        #endregion

        protected virtual byte[] toByte(Bitmap bitmap)
        {
            MemoryStream mstream = new MemoryStream();
            ImageCodecInfo myImageCodecInfo = GetEncoderInfo(ContentType);

            EncoderParameter myEncoderParameter0 = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)100);
            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            myEncoderParameters.Param[0] = myEncoderParameter0;

            bitmap.Save(mstream, myImageCodecInfo, myEncoderParameters);

            return mstream.GetBuffer();
        }

        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        protected virtual void DrawPattern(ref Graphics g, string Pattern)
        {
            int tempWidth;

            for (int i = 0; i < Pattern.Length; i++)
            {
                if (Pattern[i] == '0')
                    tempWidth = _thin;
                else
                    tempWidth = _full;

                if (i % 2 == 0)
                    g.FillRectangle(BLACK, xPos, yPos, tempWidth, _height);
                else
                    g.FillRectangle(WHITE, xPos, yPos, tempWidth, _height);

                xPos += tempWidth;
            }
        }
    }
}
