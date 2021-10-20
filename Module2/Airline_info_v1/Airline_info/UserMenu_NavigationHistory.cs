using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserMenu
{
    //приклад/демонстрація
    // NavigationMenuHistory p = new NavigationMenuHistory();
    //p.AddItemNavigationPanel("Головне меню");
    //p.DrawMenuHistory(); Console.ReadLine();
    //p.AddItemNavigationPanel("Показати рейси на сьогодні. (1 січня 22р)");
    //p.DrawMenuHistory(); Console.ReadLine();
    //p.DelItemNavigationPanel();
    //p.DrawMenuHistory(); Console.ReadLine();

    //клас що буде відображати стрічку історіх навігації по пунктам меню у вигляді:
    //Головне меню:
    //Головне меню -> Показати рейси на сьогодні. (1 січня 22р):
    public class NavigationMenuHistory
    {
        //константи символів розділювачів
        private const string _endSymbol = ":";
        private const string _separator = "->";

        //список значень елементів меню для відображення
        private List<string> _historyItems = new List<string>();

        // строка надпису історії навігації
        // результат
        private string _MenuHistory;
        public string getHistory()
        {
            return _MenuHistory;
        }

        // добавити новий пункт меню
        public void AddItem_NavigationMenuHistory(string item)
        {
            _historyItems.Add(item);
            _createHistory();
        }

        // видалити останній пункт меню
        public void DelItem_NavigationMenuHistory()
        {
            _historyItems.RemoveAt(_historyItems.Count - 1);
            _createHistory();
        }

        // створити стрічку історії
        private void _createHistory()
        {
            _MenuHistory = "";
            foreach (string item in _historyItems)
            {
                if (_MenuHistory != "")
                {
                    _MenuHistory += " " + _separator + " ";
                }
                _MenuHistory += item;
            }
            _MenuHistory += _endSymbol;

            //Console.WriteLine(_MenuHistory);
        }

    }

}
