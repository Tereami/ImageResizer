#region License
/*Данный код опубликован под лицензией Creative Commons Attribution-ShareAlike.
Разрешено использовать, распространять, изменять и брать данный код за основу для производных в коммерческих и
некоммерческих целях, при условии указания авторства и если производные лицензируются на тех же условиях.
Код поставляется "как есть". Автор не несет ответственности за возможные последствия использования.
Зуев Александр, 2021, все права защищены.
This code is listed under the Creative Commons Attribution-ShareAlike license.
You may use, redistribute, remix, tweak, and build upon this work non-commercially and commercially,
as long as you credit the author by linking back and license your new creations under the same terms.
This code is provided 'as is'. Author disclaims any implied warranty.
Zuev Aleksandr, 2021, all rigths reserved.*/
#endregion
#region usings
using System;
using System.Drawing;
#endregion

namespace ImageResizer
{
    public static class Resizer
    {
        /// <summary>
        /// Fit image is square of given size, save proportions (with white fields)
        /// </summary>
        /// <param name="jpgpath">Path to jpg file</param>
        /// <param name="size">Size of square</param>
        /// <returns>Path to a created image</returns>
        public static string FitImageInSquare(string jpgpath, int size)
        {
            string finalimgpath = "";
            using (Image curimg = Image.FromFile(jpgpath) as Bitmap)
            {
                Rectangle curRect = new Rectangle(0, 0, curimg.Width, curimg.Height);
                Rectangle newRect = new Rectangle();
                Bitmap targetBitmap = new Bitmap(size, size);
                if (curimg.Width > curimg.Height) //изображение широкое и низкое
                {
                    double coef = (double)curimg.Width / (double)size;
                    int newheight = (int)(curimg.Height / coef);
                    int topFieldHeight = (size - newheight) / 2;
                    newRect = new Rectangle(0, topFieldHeight, size, newheight);
                }
                else //изображение узкое и высокое
                {
                    double coef = (double)curimg.Height / (double)size;
                    int newwidth = (int)(curimg.Width / coef);
                    int leftFieldWidth = (size - newwidth) / 2;
                    newRect = new Rectangle(leftFieldWidth, 0, newwidth, size);
                }

                using (Bitmap sourceBitmap = new Bitmap(curimg, curimg.Width, curimg.Height))
                {
                    using (Graphics g = Graphics.FromImage(targetBitmap))
                    {
                        SolidBrush sb = new SolidBrush(Color.White);
                        g.FillRectangle(sb, 0, 0, size, size);
                        g.DrawImage(sourceBitmap, newRect, curRect, GraphicsUnit.Pixel);
                    }
                }

                finalimgpath = jpgpath.Replace(".jpg", "_" + size.ToString() + ".jpg");
                targetBitmap.Save(finalimgpath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            return finalimgpath;
        }
    }
}
