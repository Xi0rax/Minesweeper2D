using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnField : MonoBehaviour
{
    
    public GameObject obj = null;
    
    // Start is called before the first frame update

    void Start()
    {
        for (int i = 0; i < GameField.width * 10; i += 10)
        {
            for (int j = 0; j < GameField.height * 10; j += 10)
            {
                int offsetX = 400 - (GameField.width * 10) / 2;
                int offsetY = 160 - (GameField.height * 10) / 2;

                Vector3 pos = new Vector3(i + offsetX, j + offsetY, 1);

                Instantiate(obj, pos, Quaternion.identity);
            }
        }
    }

}
