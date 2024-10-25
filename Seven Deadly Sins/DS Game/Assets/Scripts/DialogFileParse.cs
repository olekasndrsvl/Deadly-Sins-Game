using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

//public static class DialogFileParse
//{
//    public static DialogData GetDialog(TextAsset dialogTextAsset)
//    {
//        return ParseDialog(dialogTextAsset.text);

//    }


//    static DialogData ParseDialog(string s)
//    {
//        var d = Regex.Matches(s, @"(?<=<dialog>)([\s\S]*)(?=</dialog>)")[0].Value;
//        if (d.Length == 0)
//        {
//            return null;
//        }

//        string question, answer1, answer2;
//        question = Regex.Match(d, @"(?<=<question>)([\s\S]*?)(?=</question>)").Groups[1].Value.Trim();
//        answer1 = Regex.Match(d, @"(?<=<Answer1>)([\s\S]*?)(?=</Answer1>)").Groups[1].Value.Trim();
//        answer2 = Regex.Match(d, @"(?<=<Answer2>)([\s\S]*?)(?=</Answer2)").Groups[1].Value.Trim();

//        var result = new DialogData(question, answer1, answer2);
//        result.ReactToAnswer1 = ParseDialog(Regex.Match(d, @"(?<=<ReactToAnswer1>)([\s\S]*?)(?=</ReactToAnswer1>)").Groups[1].Value);
//        result.ReactToAnswer2 = ParseDialog(Regex.Match(d, @"(?<=<ReactToAnswer2>)([\s\S]*?)(?=</ReactToAnswer2>)").Groups[1].Value);
//        return result;
//    }



//}
