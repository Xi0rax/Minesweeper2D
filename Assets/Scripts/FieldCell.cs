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

    void Start()
    {
        // Инициализация клетки случайным образом
        mine = Random.value < 0.15;

        // Установка клетки на поле
        int PosX = (int)transform.position.x;
        int PosY = (int)transform.position.y;

    //    GameField.cells[PosX, PosY] = this;

    }
        
       // Загрузка текстуры для клетки

    public void setTexture(int incident)
    {
        if (mine)
            GetComponent<SpriteRenderer>().sprite = mineTexture;
        else
            GetComponent<SpriteRenderer>().sprite = incidentTextures[incident];
    }

    private void OnMouseUpAsButton()
    {
        if (this.mine)
            GameField.ShowAllMines();
        else
        {
            int PosX = (int)transform.position.x;
            int PosY = (int)transform.position.y;
            this.setTexture(GameField.incidentMines(PosX,PosY)); // Количество окрестных мин
        }


    }
}
