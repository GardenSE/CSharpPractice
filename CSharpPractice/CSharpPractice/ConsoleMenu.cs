using System;
using CSharpPractice.Core.Services;

namespace CSharpPractice.ConsoleUI
{
    public static class ConsoleMenu
    {
        public static void DisplayConsoleMenu()
        {
            bool isEnd = false;

            while (!isEnd)
            {
                Console.WriteLine(@"
[メニュー番号]:[メニュー内容]
---------------------------------------------------------
1-1:LINQ（１）クエリ構文
1-2:LINQ（２）メソッド構文
1-3:LINQ（３）集計（メソッド構文）
1-4:LINQ（４）集計（クエリ構文）
1-5:LINQ（５）集計と並び替え（メソッド構文）
1-6:LINQ（６）集計・並び替え・抽出条件（メソッド構文）
---------------------------------------------------------
※終了する場合は、メニュー番号以外のキーを押してください
");
                Console.WriteLine("実行するメニュー番号を入力してください。");
                string? menuNo = Console.ReadLine();

                switch (menuNo)
                {
                    case "1-1":
                        PracticeLinq serviceLinq1 = new PracticeLinq();
                        serviceLinq1.GetPostDataHasChoumeByQuery();
                        break;

                    case "1-2":
                        PracticeLinq serviceLinq2 = new PracticeLinq();
                        serviceLinq2.GetPostDataHasChoumeByMethod();
                        break;

                    case "1-3":
                        PracticeLinq serviceLinq3 = new PracticeLinq();
                        serviceLinq3.CountGovernmentCodeFromPostData();
                        break;

                    case "1-4":
                        PracticeLinq serviceLinq4 = new PracticeLinq();
                        serviceLinq4.CountGovernmentCodeFromPostDataByQuery();
                        break;

                    case "1-5":
                        PracticeLinq serviceLinq5 = new PracticeLinq();
                        serviceLinq5.CountPostCodeFromPrefectures();
                        break;

                    case "1-6":
                        PracticeLinq serviceLinq6 = new PracticeLinq();
                        serviceLinq6.CountPostCodeFromPrefecturesOverFive();
                        break;

                    default:
                        // プログラムを終了する
                        isEnd = true;
                        break;
                }
            }
        }
    }
}
