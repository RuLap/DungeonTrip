using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;
using System.Linq;

public static class Coder
{
    public static ushort key = 0x0088;
    public static string EncodeDecrypt(string str)
    {
        var ch = str.ToArray(); //преобразуем строку в символы
        string newStr = "";      //переменная которая будет содержать зашифрованную строку
        foreach (var c in ch)  //выбираем каждый элемент из массива символов нашей строки
            newStr += TopSecret(c);  //производим шифрование каждого отдельного элемента и сохраняем его в строку
        return newStr;
    }

    public static char TopSecret(char character)
    {
        character = (char)(character ^ key); //Производим XOR операцию
        return character;
    }
}
