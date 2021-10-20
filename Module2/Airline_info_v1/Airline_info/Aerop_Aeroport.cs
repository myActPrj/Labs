using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerop
{
    //клас аеропорт в якому є літаки
    class Aeroport
    {
        public List<Flight> flight = new List<Flight>();

        //---------------------------------------------------------
        // виведення на екран таблички всіх літаків
        //---------------------------------------------------------

        public void drawFlight()
        {
            drawFlight(this);
        }

        public void drawFlight(Aeroport aerop)
        {
            drawFlight(aerop.flight);
        }

        //базпосередньо виведення таблички літаків
        public void drawFlight(List<Flight> flight)
        {
            int i = 0;

            ////Console.WriteLine("{0,6} {1,20} {2,20}","Word #", "Char Objects", "Characters")

            //Console.WriteLine("  №  |flight  |   Departure   |  Departure       | Destination   | Destination   | Seat  | seat  ");
            //Console.WriteLine("     |number  |   dateTime    |  cityPort        | dateTime      | cityPort      | free  | totall");

            //foreach (Flight f in flight)
            //{
            //    i++;
            //    Console.WriteLine($"{i}    | {f.number}      | {f.departDateTime}   | {f.departCityPort}   | {f.destDateTime} |{f.destCityPort}  | {f.seatFree}  | {f.seatTotall}");
            //}

            // більш адаптивне виведенянн данних в табличку
            // Заголовки табличок
            string[] sHead1 = { " № ", "flight", " Departure", " Departure", " Destination", " Destination", "Price", "Seat", "Seat  " };
            string[] sHead2 = { "   ", "number", " dateTime", " cityPort ", " dateTime", " cityPort   ", "     ", "free", "totall" };
            int[] iHead = { 3, 6, 20, 15, 20, 15, 5, 4, 6 };    // ширина колонок

            string separatorLine = "+------------------------------------------------------------------------------------------------------+";
            //Console.WriteLine();
            Console.WriteLine(separatorLine);
            printLine(sHead1, iHead);
            printLine(sHead2, iHead);
            Console.WriteLine(separatorLine);

            // Данні для виведення
            foreach (Flight f in flight)
            {
                i++;
                //Console.WriteLine($"{i}    | {f.number}      | {f.departDateTime}   | {f.departCityPort}   | {f.destDateTime} |{f.destCityPort}  | {f.seatFree}  | {f.seatTotall}");
                Console.Write("|");
                printColl(Convert.ToString(i), iHead[0]);

                printColl(f.number, iHead[1]);

                printColl(f.departDateTime, iHead[2]);
                printColl(f.departCityPort, iHead[3]);
                printColl(f.destDateTime, iHead[4]);
                printColl(f.destCityPort, iHead[5]);

                printColl(f.price, iHead[6]);
                printColl(f.seatFree, iHead[7]);
                printColl(f.seatTotall, iHead[8]);

                //{ f.number}      | { f.departDateTime}   | { f.departCityPort}   | { f.destDateTime} |{ f.destCityPort}  | { f.seatFree}  | { f.seatTotall}

                Console.WriteLine();
            }
            Console.WriteLine(separatorLine);
        }
        //---------------------------------------------------------

        //---------------------------------------------------------
        // набір вспоміжних ф-й виведення данних у вигляді гарненької таблички
        //---------------------------------------------------------
        //зручний друк шапки таблиці
        private void printLine(string[] s, int[] len)
        {
            Console.Write("|");
            int max_len;
            for (int sIndx = 0; sIndx < s.Length; sIndx++)
            {
                max_len = Math.Max(s[sIndx].Length, len[sIndx]);
                printColl(s[sIndx], max_len);
            }
            Console.WriteLine();
        }

        private void printLine(string[] s)
        {
            Console.Write("|");
            for (int sIndx = 0; sIndx < s.Length; sIndx++)
            {
                printColl(s[sIndx], s.Length);
            }
            Console.WriteLine();
        }

        //друк комірки данних з фіксованою шириною і кінц. символом "|"
        private void printColl(string s, int len)
        {
            Console.Write(s);
            for (int space = s.Length; space < len; space++)
            {
                Console.Write(" ");
            }
            Console.Write("|");
        }

        private void printColl(int val, int len)
        {
            printColl(Convert.ToString(val), len);
        }

        private void printColl(DateTime val, int len)
        {
            // для ф-и преобразования формата времени (использовать рускоязычный формат)
            //ToDateTime(String, IFormatProvider)
            var formatDT = new System.Globalization.CultureInfo("ru-RU");

            printColl(Convert.ToString(val, formatDT), len);
        }
        //---------------------------------------------------------
        //---------------------------------------------------------

        //---------------------------------------------------------
        // ф-и фильтрации
        //---------------------------------------------------------
        //Привітання.
        //Виберіть дію:
        //Показати всі рейси.
        //Знайти рейс по номеру.
        //Знайти рейс по місцю кінцевого призначення.
        //Показати рейси на сьогодні. (1 січня 22р)
        //Показати рейси на найближчих 7 днів.
        //Показати рейси дешевші за Х грн.
        //Показати рейси на які є вільні місця.
        //Зайти як Адміністратор.
        //Exit application.

        // Знайти рейс по номеру.
        public List<Flight> GetFligthsByNumber(int flightNumber)
        {
            List<Flight> result = new List<Flight>();

            foreach (var flight in this.flight)
            {
                if (flight.number == flightNumber)
                {
                    result.Add(flight);
                }
            }
            return result;
        }

        // Знайти рейс по місцю кінцевого призначення.
        public List<Flight> GetFligthsByDestination(string destCityPort)
        {
            List<Flight> result = new List<Flight>();

            foreach (var flight in this.flight)
            {
                if (flight.destCityPort == destCityPort)
                {
                    result.Add(flight);
                }
            }
            return result;
        }

        //Показати рейси на сьогодні. (1 січня 22р)
        public List<Flight> GetFligthsByDateTime_CurrentDay()
        {
            // +7 дней к
            DateTime DtBegin = DateTime.Now;

            //жорстко задаэм, щоб працювало з прикладами з CSV-файла
            DtBegin = new DateTime(2022, 1, 1);

            DateTime DtEnd = DtBegin.AddDays(1);

            //return GetFligthsByBeginEndDateTime(DtBegin, DtEnd);
            return GetFligthsByDateTime_departBeginEndDT(DtBegin, DtEnd);

        }

        //Показати рейси на найближчих 7 днів.
        public List<Flight> GetFligthsByDateTime_departNext7Day()
        {
            // +7 днів до поточноъ дати
            DateTime DtBegin = DateTime.Now;

            //жорстко задаэм, щоб працювало з прикладами з CSV-файла
            DtBegin = new DateTime(2022, 1, 1);

            DateTime DtEnd = DtBegin.AddDays(7);

            //return GetFligthsByBeginEndDateTime(DtBegin,DtEnd);
            return GetFligthsByDateTime_departBeginEndDT(DtBegin, DtEnd);

        }

        //відібрати рейси за вказаниний період по пукту виїзду
        public List<Flight> GetFligthsByDateTime_departBeginEndDT(DateTime DtBegin, DateTime DtEnd)
        {
            List<Flight> result = new List<Flight>();

            foreach (var flight in this.flight)
            {
                if ((flight.departDateTime >= DtBegin) && (flight.departDateTime <= DtEnd))
                {
                    result.Add(flight);
                }
            }
            return result;
        }

        public List<Flight> GetFligthsByDateTime_BeginEndDT(DateTime departDateTime, DateTime destDateTime)
        {
            List<Flight> result = new List<Flight>();

            foreach (var flight in this.flight)
            {
                if ((flight.departDateTime >= departDateTime) && (flight.destDateTime <= destDateTime))
                {
                    result.Add(flight);
                }
            }
            return result;
        }

        //Показати рейси дешевші за Х грн.
        public List<Flight> GetFligthsByLessPrice(int price)
        {
            List<Flight> result = new List<Flight>();

            foreach (var flight in this.flight)
            {
                if (flight.price < price)
                {
                    result.Add(flight);
                }
            }
            return result;
        }

        //Показати рейси на які є вільні місця.
        public List<Flight> GetFligthByExistSeatFree()
        {
            List<Flight> result = new List<Flight>();

            foreach (var flight in this.flight)
            {
                if (flight.seatFree > 0)
                {
                    result.Add(flight);
                }
            }
            return result;
        }

        //Зайти як Адміністратор.
        // НЕ реалізовано

        //---------------------------------------------------------
        // гарненьке виведеня в кольорі назви табличок
        //---------------------------------------------------------
        private const ConsoleColor TableNameColor = ConsoleColor.Green;

        public void WriteTableName(string text)
        {
            Console.ForegroundColor = TableNameColor;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void WriteTableName(string text, int num)
        {
            Console.ForegroundColor = TableNameColor;
            Console.WriteLine(text, num);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void WriteTableName(string text, string text2)
        {
            Console.ForegroundColor = TableNameColor;
            Console.WriteLine(text, text2);
            Console.ForegroundColor = ConsoleColor.White;
        }
        //---------------------------------------------------------
    }

}
