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

    public static void FloodFill(int x, int y, bool[,] visited) // Раскрытие пустых клеток
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            if (visited[x, y]) // Остановка в случае проверки данной клетки
                return;

            cells[x, y].setTexture(incidentMines(x, y));

            if (incidentMines(x, y) > 0)
                return;

            visited[x, y] = true;

            // Просмотр соседних клеток с рекурсией

            FloodFill(x - 1, y, visited);
            FloodFill(x + 1, y, visited);
            FloodFill(x, y - 1, visited);
            FloodFill(x, y + 1, visited);
        }
    }

    public static int incidentMines(int x, int y) // Подсчет количества примыкающих мин
    {
       int count = 0;

        // Проверка всех клеток в радиусе заданной клетки
      
        if (isMine(x, y + 1)) ++count;      // Верхняя клетка
        if (isMine(x + 1, y + 1)) ++count;  // Правая верхняя клетка
        if (isMine(x + 1, y)) ++count;      //  Правая клетка
        if (isMine(x + 1, y - 1)) ++count;  // Правая нижняя клетка
        if (isMine(x, y - 1)) ++count;      // Нижняя клетка
        if (isMine(x - 1, y - 1)) ++count;  // Левая нижняя клетка
        if (isMine(x - 1, y)) ++count;      // Левая клетка
        if (isMine(x - 1, y + 1)) ++count;  // Левая верхняя клетка

        return count;
    }
}
