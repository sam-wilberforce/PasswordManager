/*
This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
	*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordManager
{
    class genPass
    {
        public genPass()
        {
        }
        public static string getPass(int charsets, int passLen)
        {
            byte[] b = new byte[passLen];
            Random rnd = new Random(new Random().Next(100000000, 900000000));
            int n = 0;
            for (int i = 0; i < passLen; i++)
            {
                switch (charsets)
                {
                    case 1://upper
                        b[i] = (byte)rnd.Next(65, 91);
                        break;
                    case 2://lower
                        b[i] = (byte)rnd.Next(97, 123);
                        break;
                    case 3://upper + lower
                        n = 95;
                        while (n > 90 && n < 97) { n = rnd.Next(65, 123); }
                        b[i] = (byte)n;
                        break;
                    case 4://numbers
                        b[i] = (byte)rnd.Next(48, 58);
                        break;
                    case 5://numbers + upper
                        n = 60;
                        while (n > 57 && n < 65) { n = rnd.Next(48, 91); }
                        b[i] = (byte)n;
                        break;
                    case 6://numbers + lower
                        n = 60;
                        while (n > 57 && n < 97) { n = rnd.Next(48, 123); }
                        b[i] = (byte)n;
                        break;
                    case 7://numbers + lower + upper
                        n = 60;
                        while ((n > 57 && n < 65) || (n > 90 && n < 97)) { n = rnd.Next(48, 123); }
                        b[i] = (byte)n;
                        break;
                    case 8://special
                        n = 50;
                        while ((n > 47 && n < 58) || (n > 64 && n < 91) || (n > 96 && n < 123)) { n = rnd.Next(33, 127); }
                        b[i] = (byte)n;
                        break;
                    case 9://special + upper
                        n = 50;
                        while ((n > 47 && n < 58) || (n > 96 && n < 123)) { n = rnd.Next(33, 127); }
                        b[i] = (byte)n;
                        break;
                    case 10://special + lower
                        n = 50;
                        while ((n > 47 && n < 58) || (n > 64 && n < 91)) { n = rnd.Next(33, 127); }
                        b[i] = (byte)n;
                        break;
                    case 11://special + lower + upper
                        n = 50;
                        while (n > 47 && n < 58) { n = rnd.Next(33, 127); }
                        b[i] = (byte)n;
                        break;
                    case 12://special + numbers
                        n = 70;
                        while ((n > 64 && n < 91) || (n > 96 && n < 123)) { n = rnd.Next(33, 127); }
                        b[i] = (byte)n;
                        break;
                    case 13://special + numbers + upper
                        n = 100;
                        while (n > 96 && n < 123) { n = rnd.Next(33, 127); }
                        b[i] = (byte)n;
                        break;
                    case 14://special + numbers + lower
                        n = 70;
                        while (n > 64 && n < 91) { n = rnd.Next(33, 127); }
                        b[i] = (byte)n;
                        break;
                    case 15://special + numbers + lower + upper
                        b[i] = (byte)rnd.Next(33, 127);
                        break;
                }
            }

            //remove colon
            if (b.Contains((byte)58))
            {
                int i = 0;
                foreach (byte byt in b)
                {
                    if (byt == 58)
                        b[i] = 59;
                    i++;
                }
            }

            return Encoding.ASCII.GetString(b);
        }
    }
}
