using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldCell : MonoBehaviour
{

    // Находится ли в данной клетке мина
    public bool mine;

    // Данные от текстурах клетки
    public Sprite[] incidentTextures;
    public Sprite mineTexture;

    // Позиция клетки на поле
    private int PosX;
    private int PosY;
    void Start()
    {
        // Инициализация клетки случайным образом
        mine = Random.value < 0.15;

        // Смещения на координатной плоскости
        int offsetX = 400 - (GameField.width * 10) / 2;
        int offsetY = 160 - (GameField.height * 10) / 2;

        PosX = (int)(transform.position.x - offsetX) / 10;
        PosY = (int)(transform.position.y - offsetY) / 10;


        GameField.cells[PosX, PosY] = this;
    }

    // Загрузка текстуры для клетки


    void OnMouseUpAsButton()
    {

       if(this.mine)
        {
            GameField.ShowAllMines();
            print("Loooooooooser!");
        }
        else
        {
            this.setTexture(GameField.incidentMines(PosX, PosY));
            GameField.FloodFill(PosX, PosY, new bool[GameField.width, GameField.height]);


        }
         setTexture(GameField.incidentMines(PosX, PosY));
        
    }

    public void setTexture(int incident)
    {
        if (mine)
            GetComponent<SpriteRenderer>().sprite = mineTexture;
        else
            GetComponent<SpriteRenderer>().sprite = incidentTextures[incident];
    }

 
}
