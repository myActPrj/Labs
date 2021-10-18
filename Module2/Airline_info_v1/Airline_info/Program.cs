using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Airline_info
{



    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Aeroport aerBorispoll = new Aeroport();

            if (CSV.Loadfile(@"..\..\planes(UTF8).csv", aerBorispoll) )
            {



            //Привітання.
            //Виберіть дію:

            //Показати всі рейси.
            aerBorispoll.WriteTableName("Показати всі рейси.");
            //aerBorispoll.drawFlight();
            //aerBorispoll.drawFlight(aerBorispoll);
            aerBorispoll.drawFlight(aerBorispoll.flight);
            pause();

            //Знайти рейс по номеру";
            aerBorispoll.WriteTableName("Знайти рейс по номеру '{0}'.",1);
            aerBorispoll.drawFlight(aerBorispoll.GetFligthsByNumber(1));
            pause();

            //Знайти рейс по місцю кінцевого призначення.
            aerBorispoll.WriteTableName("Знайти рейс по місцю кінцевого призначення '{0}'.", "Дніпро");
            aerBorispoll.drawFlight(aerBorispoll.GetFligthsByDestination("Дніпро"));
            pause();

            //Показати рейси на сьогодні. (1 січня 22р)
            aerBorispoll.WriteTableName("Показати рейси на сьогодні. (1 січня 22р)");
            aerBorispoll.drawFlight(aerBorispoll.GetFligthsByDateTime_CurrentDay());
            pause();

            //Показати рейси на найближчих 7 днів.
            aerBorispoll.WriteTableName("Показати рейси на найближчих 7 днів.");
            aerBorispoll.drawFlight(aerBorispoll.GetFligthsByDateTime_departNext7Day());
            pause();

            //Показати рейси дешевші за Х грн.
            aerBorispoll.WriteTableName("Показати рейси дешевші за {0} грн.", 400);
            aerBorispoll.drawFlight(aerBorispoll.GetFligthsByLessPrice(400));
            pause();

            //Показати рейси на які є вільні місця.
            aerBorispoll.WriteTableName("Показати рейси на які є вільні місця.");
            aerBorispoll.drawFlight(aerBorispoll.GetFligthByExistSeatFree());
            pause();


            //Зайти як Адміністратор.
            //Exit application.
  


                //Затримка виведення наступної порції данних на екран, поки не буде натиснута будь-яка калавіша
                void pause()
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(" Press Any Key for Next..");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                }

            }

            Console.WriteLine("\n Press Any Key For Exit");
            Console.ReadKey();
        }
    }

    //інформація про літак в розкладі
    class Flight
    {
        public int number;                  //Номер рейсу

        //departure
        public DateTime departDateTime;     //Час і дата відправлення з нашого автовокзалу
        public string   departCityPort;     //Початковий пункт

        //arrival/destination
        public DateTime destDateTime;       //Час прибуття в пункт призначення
        public string   destCityPort;       //Пункт призначення

        public int price;                   //Вартість квитка

        public int seatTotall;              //Кількість місць всього
        public int seatFree;                //Кількість вільних місць

    }

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
            string[] sHead2 = { "   ", "number", " dateTime",  " cityPort ", " dateTime"   , " cityPort   ", "     ", "free", "totall" };
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
            printColl(Convert.ToString(val), len);
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
            return GetFligthsByDateTime_departBeginEndDT(DtBegin,DtEnd);

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
            Console.WriteLine(text,num);
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



    //клас читання данних інформації про літаки з CSV-файлу
    class CSV
    {
        static public bool Loadfile(string fileName, Aeroport aeroport)
        {
            try
            { 
                //System.IO.StreamReader f = new System.IO.StreamReader(fileName, System.Text.Encoding.UTF8); //System.Text.Encoding.ASCII
                System.IO.StreamReader f = new System.IO.StreamReader(fileName, System.Text.Encoding.UTF8);

                //читаэм першу стрічку файла що є шапкою/заголовоком колонок данних в файлі
                string headerLine = f.ReadLine();
                string[] header = headerLine.Split(';');

                string dataLine;
                while ((dataLine = f.ReadLine()) != null)
                //while ( dataLine.Peek() > -1 )
                {
                    string[] data = dataLine.Split(';');
                    //for (int i = 0; i < data.Length; i++)
                    {
                        // відкидуєм колоночку c пустим заголовком
                        //if (header[i] != "")
                        {
                            Flight flight = new Flight();

                            flight.number = Convert.ToInt32(data[0]);

                            flight.departDateTime = Convert.ToDateTime(data[1]);
                            flight.departCityPort = data[2];
                            
                            flight.destCityPort = data[3];
                            flight.destDateTime = Convert.ToDateTime(data[4]);

                            flight.price = Convert.ToInt32(data[5]);

                            flight.seatFree = Convert.ToInt32(data[6]);
                            flight.seatTotall = Convert.ToInt32(data[7]);

                            //Aeroport a = new Aeroport();

                            aeroport.flight.Add(flight);
                           
                            //Console.WriteLine(flight.destCityPort);

                        }

                    }

                }

                f.Close();
                return true;
            }
            catch (System.IO.FileNotFoundException e)
            {
                Console.WriteLine( e.Message );
                //Console.WriteLine($"Please use correct fileName puth CSV-file");
                return false;
            }

            //інші помилки при читанні файла
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return false;
            }
        }
    }

}
