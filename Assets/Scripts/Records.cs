using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public static class Records
{
    public static int HighScore = 0;
    public static string nickname = "Null";
    public static string scores = "";


    public static void LoadData()
    {
        if (File.Exists(Application.dataPath + "/HiScore.dat"))
        {
            HighScore = GetParameter("Record", "HiScore");
            nickname = GetStringParameter("Record", "Nickname");
        }
        else
        {
            File.Create(Application.dataPath + "/HiScore.dat").Dispose();
            WriteParameter("Record", "HiScore", "0");
            WriteParameter("Record", "Nickname", "Null");
        }

        if(File.Exists(Application.dataPath + "/scores.dat"))
        {

            LinkedList<string> buff = new LinkedList<string>();
            StringBuilder buffer = new StringBuilder();
            StreamReader reader = new StreamReader(Application.dataPath + "/scores.dat");
            while (!reader.EndOfStream)
            {
                buff.AddFirst(reader.ReadLine());
            }
            foreach (var line in buff)
            {
                buffer.AppendLine(line);
            }
            reader.Close();
            scores = buffer.ToString();
        }
        else
        {
            File.Create(Application.dataPath + "/scores.dat").Dispose();
            StreamWriter writer = new StreamWriter(Application.dataPath + "/scores.dat", true);
            writer.Write("");
            writer.Close();
        }
    }

    public static void UpdateData(int hiscore, string nick, string records)
    {

        LinkedList<string> buff = new LinkedList<string>();

        WriteParameter("Record", "HiScore", hiscore.ToString());
            WriteParameter("Record", "Nickname", nick);
            StringBuilder appender = new StringBuilder();
            StreamReader reader = new StreamReader(Application.dataPath + "/scores.dat");
        while (!reader.EndOfStream)
            buff.AddLast(reader.ReadLine());
            reader.Close();

        while (buff.Count >= 5)
            buff.RemoveFirst();

            StreamWriter writer = new StreamWriter(Application.dataPath + "/scores.dat", false);
            buff.AddLast(records);
        foreach (var line in buff)
        {
            appender.AppendLine(line);
        }
        writer.Write(appender.ToString());
        writer.Close();
        LoadData();

    }

    public static void WriteParameter(string Section, string Key, string Value)
    {
        INIParser ini = new INIParser();
        ini.Open(Application.dataPath + "/HiScore.dat");
        ini.WriteValue(Section, Key, Value);
        ini.Close();
    }

    public static int GetParameter(string Section, string Key)
    {
        int temp = 0;
        INIParser ini = new INIParser();
        ini.Open(Application.dataPath + "/HiScore.dat");
        temp = ini.ReadValue(Section, Key, 0);
        ini.Close();
        return temp;
    }
    public static string GetStringParameter(string Section, string Key)
    {
        StringBuilder temp = new StringBuilder();
        INIParser ini = new INIParser();
        ini.Open(Application.dataPath + "/HiScore.dat");
        temp.Append(ini.ReadValue(Section, Key, "Null"));
        ini.Close();
        return temp.ToString();
    }
}
