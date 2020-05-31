using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using UnityEngine.SceneManagement;

public class MakeRec : MonoBehaviour
{
  
    public Text NickName;
   public void ApplyPressed()
    {
        StringBuilder buffer = new StringBuilder();
        buffer.Append(NickName.text);
        buffer.Append("\t\t\t");
        buffer.Append(GameField.score.ToString());

        Records.UpdateData(GameField.score, NickName.text, buffer.ToString());

        GameObject recMenu = GameObject.Find("RecContainer");
        recMenu.SetActive(false);
        NickName.text = "";

        SceneManager.LoadScene("Records", LoadSceneMode.Single);
    }

    // Update is called once per frame
    public void CancelPressed()
    {
        GameObject recMenu = GameObject.Find("RecContainer");
        recMenu.SetActive(false);

        GameField.ShowInfo();
       
    }
}
