using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameField
{
    //Параметры игрового поля
    public static int width = Settings.width;
    public static int height = Settings.height;

    public static FieldCell[,] cells = new FieldCell[width, height]; // Двумерный массив для хранения клеток поля

    public static void ShowAllMines()
    {
        foreach(var cell in cells)
        {
            if (cell.mine)
                cell.setTexture(0);
        }
    }

    public static bool isMine(int x, int y) // Проверка на наличие мины в заданной клетке
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
            return cells[x, y].mine;
        else
            return false;
    }

    public static int incidentMines(int x, int y) // Подсчет количества примыкающих мин
    {
       int count = 0;

        // Проверка всех клеток в радиусе заданной клетки
        /*
         * Проверка проходит:
         * 
         * Верхней клетки
         * Нижней клетки
         * Левой клетки
         * Правой клетки
         * Левой верхней клетки
         * Правой верхней клетки
         * Левой нижней клетки
         * Правой нижней клетки
         * 
         */

       for (int i = x - 1; i <= x + 1; i++)
        {
            for (int j = y - 1; y <= y + 1; j++)
            {
                if (i != x || j != y)
                {
                    if (isMine(i, j))
                        count++;
                }
            }
        }

        return count;
    }
}
