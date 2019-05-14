using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HW4
{
    class Matcher
    {
        const string IDpattern = @"^\d{4}320\d{3}$";
        const string PacketPattern = @"^(.{12})(.{12})(.{4})";
        const string SocialPattern = @"^(\d\d)(\d\d)(\d\d) \- (\d)(\d\d\d\d)(\d)(\d)$";

        public string MatchByNumber(int n, string input)
        {
            switch (n)
            {
                case 0:
                    return _MatchID(input);
                case 1:
                    return _MatchPacket(input);
                case 2:
                    return _MatchSocial(input);
                default:
                    throw new InvalidOperationException("Option Invalid.");
            }
        }
        private string _MatchID(string input)
        {
            Match match = Regex.Match(input, IDpattern);
            if (match.Success)
                return "Y";
            else
                return "N";
        }

        private string _MatchPacket(string input)
        {
            Match match = Regex.Match(input, PacketPattern);
            if (!match.Success) return "N";
            string destination = match.Groups[1].Value;
            string source = match.Groups[2].Value;
            string type = match.Groups[3].Value;
            if (type == "0800") return destination;
            else if (destination == "ffffffffffff" && type == "0806") return source;
            else return "N";
        }

        private string _MatchSocial(string input)
        {
            Match match = Regex.Match(input, SocialPattern);
            if (!match.Success) return "N";
            int _year = Int32.Parse(match.Groups[1].Value); int _month = Int32.Parse(match.Groups[2].Value);
            int _day = Int32.Parse(match.Groups[3].Value); int _gender = Int32.Parse(match.Groups[4].Value);
            int _area = Int32.Parse(match.Groups[5].Value); int _acceptance = Int32.Parse(match.Groups[6].Value);
            int _check = Int32.Parse(match.Groups[7].Value);

            if (!_IsItValidDate(_year, _month, _day, _gender))
            {
                Console.WriteLine("Date is Not Valid.");
                return "N";
            }

            int checksum = _GetCheckSumFromRawInput(input);
            if (checksum != _check)
            {
                Console.WriteLine("Check Sum is Not Valid : " + checksum);
                return "N";
            }

            return "Y";

        }
        private bool _IsItValidDate(int y, int m, int d, int g)
        {
            if (g > 2 && y > 18) return false;
            if (!_CheckMonth(m, d, y % 4 == 0)) return false;
            return true;
        }

        private bool _CheckMonth(int m, int d, bool isLeapYear)
        {
            if (m > 12) return false;
            if (m == 1 || m == 3 || m == 5 || m == 7 || m == 8 || m == 10 || m == 12)
                if (d > 31) return false;
                else if (m == 4 || m == 6 || m == 9 || m == 11)
                    if (d > 30) return false;
                    else if (isLeapYear) if (d > 29) return false; else if (d > 28) return false;

            return true;
        }
        private int _GetCheckSumFromRawInput(string input)
        {
            int result = 0;
            for (int i = 0; i < 6; i++)
                result += (input[i] - '0') * (i + 2); // first 6 digit.

            result += (input[9] - '0') * 8;
            result += (input[10] - '0') * 9;
            for (int i = 2; i < 6; i++)
                result += (input[i + 9] - '0') * i;

            result = 11 - result % 11;
            if (result >= 10) return result % 10; else return result;
        }

    }
}