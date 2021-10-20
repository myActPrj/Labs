using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerop
{

    //клас читання данних інформації про літаки з CSV-файлу
    class CSV
    {
        static public bool Loadfile(string fileName, Aeroport aeroport)
        {
            // для ф-и преобразования формата времени (использовать рускоязычный формат)
            //ToDateTime(String, IFormatProvider)
            var formatDT = new System.Globalization.CultureInfo("ru-RU");

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

                            flight.departDateTime = Convert.ToDateTime(data[1], formatDT);
                            flight.departCityPort = data[2];

                            flight.destCityPort = data[3];
                            flight.destDateTime = Convert.ToDateTime(data[4], formatDT);

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
                Console.WriteLine(e.Message);
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
