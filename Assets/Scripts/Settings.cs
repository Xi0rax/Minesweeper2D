using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

public class Settings
{
    private static string path = Application.dataPath + "/config.ini";
    public static int width = int.Parse(GetParameter("Field", "Width"));
    public static int height = int.Parse(GetParameter("Field", "Height"));

    [DllImport("kernel32")]
    private static extern long WritePrivateProfileString(string section,
        string key, string val, string filePath);
    [DllImport("kernel32")]
    private static extern int GetPrivateProfileString(string section,
            string key, string def, StringBuilder retVal,
       int size, string filePath);

    public static void WriteParameter(string Section, string Key, string Value)
    {
        WritePrivateProfileString(Section, Key, Value, path);
    }

    public static string GetParameter(string Section, string Key)
    {
        StringBuilder temp = new StringBuilder(255);
        GetPrivateProfileString(Section, Key, "" ,temp, 255, path);
        return temp.ToString();
    }

    public static void InitSettings()
    {
        WriteParameter("Field", "Width", "10");
        WriteParameter("Field", "Height", "13");
    }
}
