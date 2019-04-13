using System;
using System.Collections.Generic;
using System.Threading;

namespace MafiaConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            bool isProgramWork = true;
            while (isProgramWork)
            {
                List<int> playerNumbers = new List<int>();
                List<int> playerRoles = new List<int>();
                int countPlayer = GetCountPlayer();

                switch (countPlayer)
                {
                    case 10:
                        playerRoles.Add(-1);
                        playerRoles.Add(-1);
                        playerRoles.Add(-2);
                        playerRoles.Add(1);
                        for (int i = 0; i < 6; i++)
                        {
                            playerRoles.Add(0);
                        }
                        break;
                    case 9:
                        playerRoles.Add(-1);
                        playerRoles.Add(-1);
                        playerRoles.Add(-2);
                        playerRoles.Add(1);
                        for (int i = 0; i < 5; i++)
                        {
                            playerRoles.Add(0);
                        }
                        break;
                    case 8:
                        playerRoles.Add(-1);
                        playerRoles.Add(-2);
                        playerRoles.Add(1);
                        for (int i = 0; i < 5; i++)
                        {
                            playerRoles.Add(0);
                        }
                        break;
                    case 7:
                        playerRoles.Add(-1);
                        playerRoles.Add(-2);
                        playerRoles.Add(1);
                        for (int i = 0; i < 4; i++)
                        {
                            playerRoles.Add(0);
                        }
                        break;
                    case 6:
                        playerRoles.Add(-2);
                        playerRoles.Add(1);
                        for (int i = 0; i < 4; i++)
                        {
                            playerRoles.Add(0);
                        }
                        break;
                    case 5:
                        playerRoles.Add(-2);
                        playerRoles.Add(1);
                        for (int i = 0; i < 3; i++)
                        {
                            playerRoles.Add(0);
                        }
                        break;
                    case 4:
                        playerRoles.Add(-2);
                        playerRoles.Add(1);
                        for (int i = 0; i < 2; i++)
                        {
                            playerRoles.Add(0);
                        }
                        break;
                    default:
                        Console.WriteLine("Неверное значение");
                        Thread.Sleep(10000);
                        return;
                }

                for (int i = 0; i < countPlayer; i++)
                {
                    playerNumbers.Add(i + 1);
                }

                Console.WriteLine("Для того чтобы получить значение введите 't', для того чтобы покинуть программу напишите 'exit'");
                bool isWork = true;
                string choice;
                bool isNumbers = true;
                bool isRoles = true;
                int playerNumberForRole = 0;
                while (isWork)
                {
                    choice = Console.ReadLine();
                    if (choice == "t")
                    {
                        if (isNumbers)
                        {
                            if (playerNumbers.Count > 0)
                            {
                                int rNumber = random.Next(playerNumbers.Count);
                                Console.WriteLine("Номер - " + playerNumbers[rNumber]);
                                playerNumbers.RemoveAt(rNumber);
                            }
                            else
                            {
                                Console.WriteLine("Все номера разобраны");
                                isNumbers = false;
                            }
                        }
                        else if (isRoles)
                        {
                            if (playerRoles.Count > 0)
                            {
                                playerNumberForRole++;
                                int rNumber = random.Next(playerRoles.Count);
                                Console.Write("Роль игрока под номером - " + playerNumberForRole + ": " + playerRoles[rNumber]);
                                if (playerRoles[rNumber] == 0)
                                {
                                    Console.WriteLine("(" + "мирный" + ")");
                                }
                                else if (playerRoles[rNumber] == 1)
                                {
                                    Console.WriteLine("(" + "шериф" + ")");
                                }
                                else if (playerRoles[rNumber] == -1)
                                {
                                    Console.WriteLine("(" + "мафия" + ")");
                                }
                                else if (playerRoles[rNumber] == -2)
                                {
                                    Console.WriteLine("(" + "дон" + ")");
                                }
                                playerRoles.RemoveAt(rNumber);
                            }
                            else
                            {
                                Console.WriteLine("Все роли разобраны");
                                isRoles = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Программа окончила работу");
                            isWork = false;
                        }
                    }
                    else if (choice == "exit")
                    {
                        isProgramWork = false;
                        isWork = false;
                    }
                }
            }
        }

        public static int GetCountPlayer()
        {
            try
            {
                Console.Write("Введите кол-во игроков: ");
                int count = int.Parse(Console.ReadLine());
                return count;
            }
            catch (Exception)
            {
                Console.WriteLine("Неверное значение");
                return GetCountPlayer();
            }
        }
    }
}
