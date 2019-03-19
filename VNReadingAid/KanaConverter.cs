using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNReadingAid
{
    class KanaConverter
    {
        public static string HiraganaToKatakana(string input)
        {
            byte[] unicodes = Encoding.GetEncoding("Unicode").GetBytes(input);
            int i;
            for (i = 0; i < unicodes.Length; i += 2)                                     //Each 16 bits.
            {
                int _word = (unicodes[i + 1] << 8) | (unicodes[i] & 0xFF);              //Two byte make a word.
                if (_word >= 0x3041 && _word <= 0x30A0)                                 //In hiragana area
                {
                    _word += 0x60;                                                      //Add difference
                    unicodes[i + 1] = (byte)(_word >> 8);                               //Write back high byte.
                    unicodes[i] = (byte)(_word & 0xFF);                                 //Write back low byte.
                }
            }
            return Encoding.GetEncoding("Unicode").GetString(unicodes);
        }

        public static string KatakanaToHiragana(string input)
        {
            byte[] unicodes = Encoding.GetEncoding("Unicode").GetBytes(input);
            int i;
            for (i = 0; i < unicodes.Length; i += 2)                                     //Each 16 bits.
            {
                int _word = (unicodes[i + 1] << 8) | (unicodes[i] & 0xFF);              //Two byte make a word.
                if (_word >= (0x3041 + 0x60) && _word <= (0x30A0 + 0x60))               //In hiragana area
                {
                    _word -= 0x60;                                                      //Add difference
                    unicodes[i + 1] = (byte)(_word >> 8);                               //Write back high byte.
                    unicodes[i] = (byte)(_word & 0xFF);                                 //Write back low byte.
                }
            }
            return Encoding.GetEncoding("Unicode").GetString(unicodes);
        }
    }
}
