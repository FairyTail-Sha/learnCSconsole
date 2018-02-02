using System;

namespace TimeTable
{
    class MyTime
    {
        public readonly int Year;
        public readonly int Mouth;
        public readonly int Days;
        //月份天数
        int[,] mouth = new int[2, 12] {
            {1 , 2, 3, 4, 5, 6, 7, 8, 9,10,11,12},
            {31, 0,31,30,31,20,31,30,31,31,30,31}
        };
        //构造函数
        public MyTime(int _year, int _mouth, int _day)
        {
            this.Year = _year;
            this.Mouth = _mouth;
            this.Days = _day;
            //二月的天数
            if (IsLeap(_year))
            {
                mouth[1, 1] = 29;
            }
            else
            {
                mouth[1, 2 - 1] = 28;
            }

        }
        //星期
        enum Week : byte
        {
            Monday = 1,//Monday
            Tuesday = 2,//Tuesday
            Wednesday = 3,//Wednesday
            Thursday = 4,//Thursday
            Friday = 5,//Friday
            Saturday = 6,//Saturday
            Sunday = 0,//Sunday
        }
        #region 星期

        private Week week;

        public string GetWeek()
        {
            SetWeek();
            return this.week.ToString();
        }
        private void SetWeek()
        {
            this.week = Zeller();
        }
        private Week Zeller()
        {
            int y, c, m, d;
            if (this.Mouth < 3)
            {
                y = (this.Year - 1) % 100;
                c = (this.Year - 1) / 100;
                m = this.Mouth + 12;
                d = this.Days;
            }
            else
            {
                y = this.Year % 100;
                c = this.Year / 100;
                m = this.Mouth;
                d = this.Days;
            }

            int w = y + y / 4 + c / 4 - 2 * c + 26 * (m + 1) / 10 + d - 1;
            // Console.WriteLine($"y = {y}; c = {c}; m = {m}; d = {d}; week = {w%7}");
            switch (w % 7)
            {
                case 0: return Week.Sunday;
                case 1: return Week.Monday;
                case 2: return Week.Tuesday;
                case 3: return Week.Wednesday;
                case 4: return Week.Thursday;
                case 5: return Week.Friday;
                default:
                    return Week.Saturday;
            }
        }
        #endregion
        //闰年二月天数
        public bool IsLeap(int year)
        {
            if ((year % 100 != 0 && year % 4 == 0) || (year % 400 == 0))
                return true;
            else return false;
        }
        /// <summary>
        /// 15天小日历
        /// </summary>
        public void ShowCalender()
        {
            int k = 15;
            MyTime Start, End, Mid;
            string big = "big";
            string small = "small";
            bool isBig = true;
            Start = this;
            Mid = this;
            while (k != 0)
            {
                k--;
                //计算明天
                Mid = NextDay(Mid);
                if (k == 14)
                {
                    //记录第一天
                    Start = Mid;
                }
                else if (k == 0)
                {
                    //记录最后一天
                    End = Mid;
                    //输出
                    string s = isBig ? big : small;
                    Console.WriteLine($"{s.PadRight(5)} 开始于{Start.Year}年{Start.Mouth.ToString().PadLeft(2)}月{Start.Days.ToString().PadLeft(2)}日"
                        + $"~结束于{End.Year}年{End.Mouth.ToString().PadLeft(2)}月{End.Days.ToString().PadLeft(2)}日");
                    //重新初始化
                    isBig = !isBig;
                    k = 15;
                }
                if (Mid.Year == 2019)
                    break;
            }
        }
        private MyTime NextDay(MyTime taday)
        {
            if (taday.Days + 1 > taday.mouth[1, taday.Mouth - 1])
            {
                if (taday.Mouth + 1 > 12)
                {
                    return new MyTime(taday.Year + 1, 1, 1);
                }
                else
                {
                    return new MyTime(taday.Year, taday.Mouth + 1, 1);
                }
            }
            else
            {
                return new MyTime(taday.Year, taday.Mouth, taday.Days + 1);
            }
        }
    }
}