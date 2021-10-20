using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aerop;


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
                UserMenu.UserMenu m = new UserMenu.UserMenu();
                
                // добавляю заголовок в меню
                m.AddItem_NavigationMenuHistory("Головне меню");

                //безкінечний цикл обробки пунктів меню
                do
                {

                    // ф-я одновременно и добавляет пункт меню и выполняет обработку выбора етого пункта
                    if (m.Menu(1, "D1", "1. Показати всі рейси") )
                    {
                        m.DrawMenuHistory();

                        //Показати всі рейси.
                        //aerBorispoll.WriteTableName("Показати всі рейси.");
                        //aerBorispoll.drawFlight();
                        //aerBorispoll.drawFlight(aerBorispoll);
                        aerBorispoll.drawFlight(aerBorispoll.flight);
                        m.WaitKeyReturn();
                    }

                    if (m.Menu(2, "D2", "2. Знайти рейс по вказаному номеру (по номеру 1)"))
                    {
                        m.DrawMenuHistory();

                        //Знайти рейс по номеру";
                        //aerBorispoll.WriteTableName("Знайти рейс по номеру '{0}'.", 1);
                        aerBorispoll.drawFlight(aerBorispoll.GetFligthsByNumber(1));
                        //pause();
                        m.WaitKeyReturn();
                    }

                    if (m.Menu(3, "D3", "3. Знайти рейс по місцю кінцевого призначення (по місцю 'Дніпро')"))
                    {
                        m.DrawMenuHistory();

                        ////Знайти рейс по місцю кінцевого призначення.
                        //aerBorispoll.WriteTableName("Знайти рейс по місцю кінцевого призначення '{0}'.", "Дніпро");
                        aerBorispoll.drawFlight(aerBorispoll.GetFligthsByDestination("Дніпро"));
                        m.WaitKeyReturn();
                    }

                    if (m.Menu(4, "D4", "4. Показати рейси на сьогодні. (1 січня 22р)"))
                    {
                        m.DrawMenuHistory();

                        ////Показати рейси на сьогодні. (1 січня 22р)
                        //aerBorispoll.WriteTableName("Показати рейси на сьогодні. (1 січня 22р)");
                        aerBorispoll.drawFlight(aerBorispoll.GetFligthsByDateTime_CurrentDay());
                        //pause();
                        m.WaitKeyReturn();
                    }

                    if (m.Menu(5, "D5", "5. Показати рейси на найближчих 7 днів"))
                    {
                        m.DrawMenuHistory();

                        ////Показати рейси на найближчих 7 днів.
                        //aerBorispoll.WriteTableName("Показати рейси на найближчих 7 днів.");
                        aerBorispoll.drawFlight(aerBorispoll.GetFligthsByDateTime_departNext7Day());
                        //pause();
                        m.WaitKeyReturn();
                    }

                    if (m.Menu(6, "D6", "6. Показати рейси дешевші за 400 грн"))
                    {
                        m.DrawMenuHistory();

                        ////Показати рейси дешевші за Х грн.
                        //aerBorispoll.WriteTableName("Показати рейси дешевші за {0} грн.", 400);
                        aerBorispoll.drawFlight(aerBorispoll.GetFligthsByLessPrice(400));
                        //pause();
                        m.WaitKeyReturn();
                    }

                    if (m.Menu(7, "D7", "7. Показати рейси на які є вільні місця"))
                    {
                        m.DrawMenuHistory();

                        ////Показати рейси на які є вільні місця.
                        //aerBorispoll.WriteTableName("Показати рейси на які є вільні місця.");
                        aerBorispoll.drawFlight(aerBorispoll.GetFligthByExistSeatFree());
                        //pause();
                        m.WaitKeyReturn();
                    }

                    ////Зайти як Адміністратор.

                    //    //Затримка виведення наступної порції данних на екран, поки не буде натиснута будь-яка калавіша
                    //    void pause()
                    //    {
                    //        Console.ForegroundColor = ConsoleColor.DarkGray;
                    //        Console.WriteLine(" Press Any Key for Next..");
                    //        Console.WriteLine();
                    //        Console.ForegroundColor = ConsoleColor.White;
                    //        Console.ReadKey();
                    //    }

                    ////Exit application.
                } while (m.mainMenuItem_WaitPressKey(9, "D9", "9. Exit application"));
            }

            //Console.WriteLine("\n Press Any Key For Exit");
            //Console.ReadKey();
        }

    }

}
