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
#endregion

namespace ImageResizer
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath;
            int size;
            int quality;
            if (args != null && args.Length > 0)
            {
                filepath = args[0];
                size = int.Parse(args[1]);
                quality = int.Parse(args[2]);
            } else
            {
                Console.WriteLine("The path to jpg file");
                filepath = Console.ReadLine();
                Console.WriteLine("Size of square");
                size = int.Parse(Console.ReadLine());
                Console.WriteLine("Quality");
                quality = int.Parse(Console.ReadLine());
            }

            string finalpath = Resizer.FitImageInSquare(filepath, size, quality);
            Console.WriteLine(finalpath);
        }
    }
}
