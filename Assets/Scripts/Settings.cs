using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;

public class Settings
{   
    public static int width = GetParameter("Field","Width");
    public static int height = GetParameter("Field", "Height");

    public static void WriteParameter(string Section, string Key, string Value)
    {
        INIParser ini = new INIParser();
        ini.Open(Application.dataPath + "/config.ini");
        ini.WriteValue(Section, Key, Value);
        ini.Close();

    }

    public static int GetParameter(string Section, string Key)
    {
        int temp = 0;
        INIParser ini = new INIParser();
        ini.Open(Application.dataPath + "/config.ini");
        temp = ini.ReadValue(Section, Key, 0);
        ini.Close();
        return temp;
    }

    public static void InitSettings()
    {
        WriteParameter("Field", "Width", "10");
        WriteParameter("Field", "Height", "13");
    }
}
