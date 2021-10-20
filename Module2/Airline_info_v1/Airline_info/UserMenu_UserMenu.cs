using System;
using System.Collections.Generic;

namespace UserMenu
{
    public class UserMenu : NavigationMenuHistory
    {

        //#region Panel
        //public void PanelUp()
        //{

        //}

        //public void PanelDwn()
        //{

        //}
        //#endregion

        public UserMenu()
        {

        }

        //------------------------------------
        // зберігати пункти меню буду в Словниках, для зручності обробки
        //------------------------------------
        private Dictionary<int, string> _itemKey = new Dictionary<int, string>();
        private Dictionary<int, string> _itemText = new Dictionary<int, string>();
        //------------------------------------

        //------------------------------------
        // ф-я добавлення елемента меню в список, з вказанням
        // індекса
        // гарячої кнопки швидкого вибору 
        // текста з назвою
        // та одночасно з вертанням значення true, якщо на вказаний пункт меню здійснено вибір
        //------------------------------------
        private string _pressedKey = null;
        public bool Menu(int index, string key, string text) //mainMenuItem
        {

            reloadMenuTask(index);

            // перевіряємо чи такий елемент є у словнику і при необхідності добавляємо його туди
            if (false == _itemKey.ContainsKey(index))
            {
                _itemKey.Add(index, key);
                _itemText.Add(index, text);
            }

            //перевіряємо чи натиснута кнопка на клавіатурі відповідає даному пункту меню,
            //якщо так, то ф-я верне true, і программа зайде в середину оператора if і виконає запрограмовану дію.
            if (key == _pressedKey)
            {
                // добаляэмо назву поточного пункту меню в стрічку навігації
                AddItem_NavigationMenuHistory(text);

                //обнуляєм опрацьовану клавішу
                _pressedKey = null;

                // можна заходити в середину if, там де ф-я була викликана
                return true;
            }
            else
            {
                return false;
            }

        }
        //------------------------------------

        //-------------------------------------
        // виведення на екран пунктів меню
        //-------------------------------------
        private bool _drawMenu_OK; // ознака що пункти меню вже виведені і непотрібно повторно виводити
                                   //private int maxTextLength=0;

        public void DrawMenuHistory()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(getHistory());
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("--------------------------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void drawMenu()
        {

            if (_drawMenu_OK == false)
            {
                DrawMenuHistory();

                foreach (var itemText in _itemText)
                {
                    Console.WriteLine(itemText.Value);
                }
                _drawMenu_OK = true;
            }
        }
        //-------------------------------------

        private void cleardMenu()
        {
            Console.Clear();
            _itemKey.Clear();
            _itemText.Clear();
            _drawMenu_OK = false;
        }


        // вивести меню заново (при поверненні в головне меню)
        private bool _reloadMenu = false;
        //private void startreloadMenu()
        private void reloadMenuTask(int index)
        {
            if (index == 1 && _reloadMenu == true)
            {
                _reloadMenu = false;
                cleardMenu();
            }
        }

        ////////MenuRun(); // обработка нажатий на клавиши выбора пунктов меню, терминальний пункт

        // ф-я що повинна викликатися самою останньою в меню, адже саме вона обробляэ натиски клавіш
        public bool mainMenuItem_WaitPressKey(int index, string key, string text)
        {
            Menu(index, key, text);

            if (_reloadMenu)
                return true;

            drawMenu();

            ConsoleKey pressKey;
            pressKey = Console.ReadKey().Key;

            //if (pressKey == ConsoleKey.D1)
            //{
            //    return false;
            //}

            //if (pressKey == ConsoleKey.Escape)
            if (pressKey == ConsoleKey.D9)
            {
                return false;
            }

            _pressedKey = pressKey.ToString();

            return true;
        }


        //Затримка виведення наступної порції данних на екран, поки не буде натиснута будь-яка калавіша
        public void WaitKeyReturn()  // WaitKeyForReturnPrevMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" Press 'Esc' Key for Main menu..");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
            }

            // видаляемо назву поточного пункту меню з стрічки навігації
            DelItem_NavigationMenuHistory();
            _reloadMenu = true;
        }

    }


}