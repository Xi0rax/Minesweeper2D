using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldCell : MonoBehaviour
{

    // Находится ли в данной клетке мина
    public bool mine;
    public bool flagged;
    public bool uncovered;

    public AudioClip explosion;
    public AudioClip Uncover;
    public AudioClip Victory;
    AudioSource fx;

    // Данные от текстурах клетки
    public Sprite[] incidentTextures;
    public Sprite mineTexture;
    public Sprite flagTexture;
    public Sprite initTexture;
    
    // Позиция клетки на поле
    private int PosX;
    private int PosY;
    void Start()
    {
        // Инициализация клетки случайным образом
        mine = Random.value < 0.15;
        this.uncovered = false;
        this.flagged = false;

        fx = GetComponent<AudioSource>();

        // Смещения на координатной плоскости
        int offsetX = 400 - (GameField.width * 10) / 2;
        int offsetY = 160 - (GameField.height * 10) / 2;

        PosX = (int)(transform.position.x - offsetX) / 10;
        PosY = (int)(transform.position.y - offsetY) / 10;

        GameField.cells[PosX, PosY] = this;
    }

    // Загрузка текстуры для клетки


    void OnMouseOver()
    {

            if (Input.GetMouseButtonUp(0))
            {
                if (!this.uncovered && !this.flagged){

                if (this.mine)
                {
                   
                    GameField.ShowAllMines();
                    if (Settings.SoundFX == 1)
                        fx.PlayOneShot(explosion, Settings.volume);
                }
                else
                {
                    this.setTexture(GameField.incidentMines(PosX, PosY));
                    GameField.FloodFill(PosX, PosY, new bool[GameField.width, GameField.height]);
                    if (Settings.SoundFX == 1)
                        fx.PlayOneShot(Uncover, Settings.volume);
                    if (GameField.isFinished())
                    {
                        GameField.EndGame("Вы выиграли");
                        if (Settings.SoundFX == 1)
                            fx.PlayOneShot(Victory, Settings.volume);
                    }
                }
                setTexture(GameField.incidentMines(PosX, PosY));
               }
            }
            else if (Input.GetMouseButtonUp(1))
            {
            if (!this.uncovered)
            {
                this.toggleFlag();
                if (Settings.SoundFX == 1)
                    fx.PlayOneShot(Uncover, Settings.volume);
            }
            }
        
        
    }
    public void toggleActive()
    {
        var collider = GetComponent<BoxCollider2D>();

        collider.enabled = (collider.enabled)?false:true;
    }

    public void setTexture(int incident)
    {
        if (mine)
            GetComponent<SpriteRenderer>().sprite = mineTexture;
        else
            GetComponent<SpriteRenderer>().sprite = incidentTextures[incident];
    }

    public void toggleFlag()
    {
        if (!this.flagged && GameField.markers > 0)
        {
            GetComponent<SpriteRenderer>().sprite = flagTexture;
            this.flagged = true;
            GameField.markers--;
            GameObject obj = GameObject.Find("GameManager");
            SpawnField script = obj.GetComponent<SpawnField>();
            script.updateMarkers(GameField.markers);
        }
        else if (this.flagged)
        {
            GetComponent<SpriteRenderer>().sprite = initTexture;
            this.flagged = false;
            GameField.markers++;
            GameObject obj = GameObject.Find("GameManager");
            SpawnField script = obj.GetComponent<SpawnField>();
            script.updateMarkers(GameField.markers);
        }
    }

   
}
