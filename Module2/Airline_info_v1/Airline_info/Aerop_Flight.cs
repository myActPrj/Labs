using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerop
{
    //інформація про літак в розкладі
    class Flight
    {
        public int number;                  //Номер рейсу

        //departure
        public DateTime departDateTime;     //Час і дата відправлення з нашого автовокзалу
        public string departCityPort;     //Початковий пункт

        //arrival/destination
        public DateTime destDateTime;       //Час прибуття в пункт призначення
        public string destCityPort;       //Пункт призначення

        public int price;                   //Вартість квитка

        public int seatTotall;              //Кількість місць всього
        public int seatFree;                //Кількість вільних місць

    }

}
