using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnField : MonoBehaviour
{
    
    public GameObject obj = null;
    public GameObject menu;
    public GameObject rec;
    public GameObject info;
    public Text Score;
    public Text Markers;
   
    
    // Start is called before the first frame update

    void Start()
    {
        GameField.InitField(Settings.width, Settings.height);
        menu.SetActive(false);
        rec.SetActive(false);
        StartGame();
    }
    
    public void updateScore(int value)
    {
        Score.text = value.ToString();
    }

    public void updateMarkers(int value)
    {
        Markers.text = value.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void ClearField()
    {
        for (var i = 0; i < GameField.width; i++)
        {
            for (var j = 0; j < GameField.height; j++)
            {
                Destroy(GameField.SpawnableObjects[i, j]);
                Destroy(GameField.cells[i, j]);
            }
        }
    }

    public void ShowRecDialog()
    {
        rec.SetActive(true);
    }
    public void StartGame()
    {
       

        GameObject info = GameObject.Find("Info");
        Text buffer = info.GetComponent<Text>();
        buffer.text = "";

        GameField.score = 0;
        GameField.markers = Settings.Markers;
        updateScore(GameField.score);
        updateMarkers(GameField.markers);

        for (int i = 0; i < GameField.width * 10; i += 10)
        {
            for (int j = 0; j < GameField.height * 10; j += 10)
            {
                int offsetX = 400 - (GameField.width * 10) / 2;
                int offsetY = 160 - (GameField.height * 10) / 2;

                Vector3 pos = new Vector3(i + offsetX, j + offsetY, 1);

                GameField.SpawnableObjects[i / 10, j / 10] = Instantiate(obj, pos, Quaternion.identity);
            }
        }
    }

    public void again()
    {
        ClearField();
        StartGame();
    }
    public void Pause()
    {
        if (!rec.activeSelf)
        {
            GameField.togglePause();
            menu.SetActive((!menu.activeSelf) ? true : false);
            info.SetActive((!info.activeSelf) ? true : false);
        }
    }
        
          
     
}
