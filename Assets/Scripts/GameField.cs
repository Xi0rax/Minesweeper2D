using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameField
{
    //Параметры игрового поля
    public static int width = Settings.width;
    public static int height = Settings.height;
    public static int score;
    public static int markers;

    public static FieldCell[,] cells; // Двумерный массив для хранения данных о клетках поля
    public static GameObject[,] SpawnableObjects; // Двумерный массив для хранения объектов
    public Text ScoreCounter;

    public static void InitField(int w, int h)
    {
        width = w;
        height = h;
        cells = new FieldCell[w, h];
        SpawnableObjects = new GameObject[w, h];
    }
    
    public static void ShowAllMines()
    {
        EndGame("Вы проиграли");
        foreach (var cell in cells)
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

            if (!cells[x, y].uncovered && !cells[x, y].flagged)
            {
                cells[x, y].setTexture(incidentMines(x, y));
                cells[x, y].uncovered = true;

                score += 10;

                GameObject manager = GameObject.Find("GameManager");
                SpawnField buffer = manager.GetComponent<SpawnField>();

                buffer.updateMarkers(markers);
                buffer.updateScore(score);

            }
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

    public static bool isFinished() // Проверка на раскрытие всех незаминированных клеток
    {
        foreach(var cell in cells)
        {
            if (!cell.uncovered && !cell.mine)
                return false;
           
        }
        return true;
    }

   public static void togglePause() // Включить/выключить взаимодействие между клетками
    {
        foreach(var cell in cells)
        {
            cell.toggleActive();
        }
    }

    public static void ShowInfo()
    {
        GameObject rec = GameObject.Find("GameManager");
        SpawnField script = rec.GetComponent<SpawnField>();

        script.info.SetActive(true);
    }

    public static void EndGame(string message) // Завершение игры
    {
        GameObject info = GameObject.Find("Info");
        Text buffer = info.GetComponent<Text>();
        buffer.text = message;
        foreach (var cell in cells)
        {
            cell.uncovered = true;
        }


        GameObject rec = GameObject.Find("GameManager");
        SpawnField script = rec.GetComponent<SpawnField>();

        if (score > Records.HighScore)
        {
            script.info.SetActive(false);
            script.ShowRecDialog();
        }
    }
}
