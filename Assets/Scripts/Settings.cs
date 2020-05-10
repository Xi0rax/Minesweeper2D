using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using System.IO;

public class Settings
{
    public static int width;
    public static int height;

    public static int difficulty;

    public static int SoundFX;

    public static int Markers;

    public static float volume;


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

    public static float remapVolume(float value, float low1, float high1, float low2, float high2)
    {
        float temp = (float)(value - low1) / (float)(high1 - low1);
        float result = (float)low2 + (float)(high2 - low2) * temp;
        return result;
    }
        

    public static void InitSettings()
    {
        if (File.Exists(Application.dataPath + "/config.ini"))
        {
            difficulty = GetParameter("Game", "Difficulty");

            switch (difficulty)
            {
                case 0:
                    {
                        width = 10;
                        height = 13;
                        break;
                    }
                case 1:
                    {
                        width = 30;
                        height = 20;
                        break;
                    }
                case 2:
                    {
                        width = 40;
                        height = 30;
                        break;
                    }
            }

            SoundFX = GetParameter("FX", "SoundFX");
            Markers = GetParameter("Game", "Markers");
            volume = remapVolume(GetParameter("FX", "Volume"), 0, 10, 0, 1);

        }
        else
            CreateSettings();
    }

    public static void CreateSettings()
    {
        WriteParameter("Game", "Difficulty", "0");
        WriteParameter("Game", "Markers", "10");
        WriteParameter("FX", "SoundFX", "1");
        WriteParameter("FX", "Volume", "10");
    }

    public static void UpdateSettings(int diff, int markers, int fxOn, int volume)
    {
        WriteParameter("Game", "Difficulty", diff.ToString());
        WriteParameter("Game", "Markers", markers.ToString());
        WriteParameter("FX", "SoundFX", fxOn.ToString());
        WriteParameter("FX", "Volume", volume.ToString());
        InitSettings();
    }
}
