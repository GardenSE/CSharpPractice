using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;
using CSharpPractice.Core.Models;
using Microsoft.Extensions.Configuration;
using MySqlConnector;


namespace CSharpPractice.Core.Services
{
    public class PracticeLinq
    {
        #region <GeneratePostCodeData : 郵便番号データを作成する>
        /// <summary>
        /// 郵便番号データを作成する
        /// </summary>
        /// <returns></returns>
        private IEnumerable<PostCodeModel> GeneratePostCodeData()
        {
            List<PostCodeModel> list = new List<PostCodeModel>();

            list.Add(new PostCodeModel
            {
                LocalGovernmentCode = "01219",
                PostCode = "0940031",
                PrefectureName = "北海道",
                CityName = "紋別市",
                TownAreaName = "海洋公園",
            });

            list.Add(new PostCodeModel
            {
                LocalGovernmentCode = "01559",
                PostCode = "0996325",
                PrefectureName = "北海道",
                CityName = "紋別郡湧別町",
                TownAreaName = "北兵村一区",
                IsPartOfTownArea = 1,
            });

            list.Add(new PostCodeModel
            {
                LocalGovernmentCode = "01219",
                PostCode = "0996325",
                PrefectureName = "北海道",
                CityName = "紋別市",
                TownAreaName = "新港町",
                HasChoume = 1,
            });

            list.Add(new PostCodeModel
            {
                LocalGovernmentCode = "01303",
                PostCode = "0613777",
                PrefectureName = "北海道",
                CityName = "石狩郡当別町",
                TownAreaName = "スウェーデンヒルズ",
                HasKoaza = 1,
            });

            list.Add(new PostCodeModel
            {
                LocalGovernmentCode = "01212",
                PostCode = "0770013",
                PrefectureName = "北海道",
                CityName = "留萌市",
                TownAreaName = "潮静",
                HasChoume = 1,
                HasMultipleTownArea = 1,
            });

            list.Add(new PostCodeModel
            {
                LocalGovernmentCode = "27213",
                PostCode = "5980077",
                PrefectureName = "大阪府",
                CityName = "泉佐野市",
                TownAreaName = "新家",
                HasChoume = 1,
                UpdateStatus = 1,
                UpdateReason = 2,
            });

            list.Add(new PostCodeModel
            {
                LocalGovernmentCode = "11217",
                PostCode = "3650006",
                PrefectureName = "埼玉県",
                CityName = "鴻巣市",
                TownAreaName = "広田中央",
                HasChoume = 1,
                UpdateStatus = 1,
                UpdateReason = 3,
            });

            list.Add(new PostCodeModel
            {
                LocalGovernmentCode = "14102",
                PostCode = "2210802",
                PrefectureName = "神奈川県",
                CityName = "横浜市神奈川区",
                TownAreaName = "六角橋",
                HasChoume = 1,
                UpdateStatus = 1,
                UpdateReason = 5,
            });

            list.Add(new PostCodeModel
            {
                LocalGovernmentCode = "01208",
                PostCode = "0930215",
                PrefectureName = "北海道",
                CityName = "北見市",
                TownAreaName = "常呂町岐阜",
            });

            list.Add(new PostCodeModel
            {
                LocalGovernmentCode = "01564",
                PostCode = "0993244",
                PrefectureName = "北海道",
                CityName = "網走郡大空町",
                TownAreaName = "東藻琴（その他）",
            });

            return list.AsEnumerable();
        }
        #endregion

        #region <GetPostDataHasChoumeByQuery : 郵便番号データから丁目を持つデータを抽出する（クエリ構文）>
        /// <summary>
        /// 郵便番号データから丁目を持つデータを抽出する（クエリ構文）
        /// </summary>
        public void GetPostDataHasChoumeByQuery()
        {
            IEnumerable<PostCodeModel> list = from p in GeneratePostCodeData()
                                              where p.HasChoume == 1
                                              orderby p.LocalGovernmentCode, p.PostCode
                                              select p;

            Console.WriteLine($"{Environment.NewLine}郵便番号データから丁目を持つデータを抽出する（クエリ構文）");
            foreach (var item in list)
            {
                Console.WriteLine($"{item.LocalGovernmentCode}, {item.PostCode}, " +
                    $"{item.PrefectureName}, {item.CityName}, {item.TownAreaName}, " +
                    $"{item.IsPartOfTownArea}, {item.HasKoaza}, {item.HasChoume}, {item.HasMultipleTownArea}");
            }
        }
        #endregion

        #region <GetPostDataHasChoumeByMethod : 郵便番号データから丁目を持つデータを抽出する（メソッド構文）>
        /// <summary>
        /// 郵便番号データから丁目を持つデータを抽出する（メソッド構文）
        /// </summary>
        public void GetPostDataHasChoumeByMethod()
        {
            IEnumerable<PostCodeModel> list = GeneratePostCodeData()
                                                .Where(p => p.HasChoume == 1)
                                                .OrderBy(p => p.LocalGovernmentCode)
                                                .ThenBy(p => p.PostCode)
                                                .Select(p => p);

            Console.WriteLine($"{Environment.NewLine}郵便番号データから丁目を持つデータを抽出する（メソッド構文）");
            foreach (var item in list)
            {
                Console.WriteLine($"{item.LocalGovernmentCode}, {item.PostCode}, " +
                    $"{item.PrefectureName}, {item.CityName}, {item.TownAreaName}, " +
                    $"{item.IsPartOfTownArea}, {item.HasKoaza}, {item.HasChoume}, {item.HasMultipleTownArea}");
            }
        }
        #endregion

        #region <CountGovernmentCodeFromPostData : 郵便番号データから地方自治体コードごとに件数をカウントする>
        public void CountGovernmentCodeFromPostData()
        {
            /* ラムダ式の引数名
             * p = 元データ（PostCodeModel
             * g = グループ
             * x = 集計結果
             */
            var result = GeneratePostCodeData()
                              .GroupBy(p => p.LocalGovernmentCode)
                              .Select(g => new
                              {
                                  LocalGovernmentCode = g.Key,
                                  PrefectureName = g.First().PrefectureName,
                                  CountNum = g.Count()
                              })
                              .OrderBy(x => x.LocalGovernmentCode);

            Console.WriteLine($"{Environment.NewLine}郵便番号データから地方自治体コードごとに件数をカウントする");

            foreach (var item in result)
            {
                Console.WriteLine($"{item.LocalGovernmentCode}, {item.PrefectureName}, {item.CountNum}");
            }
        }
        #endregion

        #region <CountGovernmentCodeFromPostDataByQuery : 郵便番号データから地方自治体コードごとに件数をカウントする（クエリ構文）>
        public void CountGovernmentCodeFromPostDataByQuery()
        {
            var result = from p in GeneratePostCodeData()
                         orderby p.LocalGovernmentCode
                         group p by p.LocalGovernmentCode into g
                         select new
                         {
                             LocalGovernmentCode = g.Key,
                             PrefectureName = g.First().PrefectureName,
                             CountNum = g.Count(),
                         }
                         ;

            Console.WriteLine($"{Environment.NewLine}郵便番号データから地方自治体コードごとに件数をカウントする（クエリ構文）");

            foreach (var item in result)
            {
                Console.WriteLine($"{item.LocalGovernmentCode}, {item.PrefectureName}, {item.CountNum}");
            }

        }
        #endregion
    }
}
