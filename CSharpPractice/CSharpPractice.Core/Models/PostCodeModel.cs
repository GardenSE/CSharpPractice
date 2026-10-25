using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPractice.Core.Models
{
    /// <summary>
    /// 郵便番号情報
    /// </summary>
    public class PostCodeModel
    {
        /// <summary>
        /// 地方自治体コード
        /// </summary>
        public string LocalGovernmentCode { get; set; } = string.Empty;

        /// <summary>
        /// 郵便番号
        /// </summary>
        public string PostCode { get; set; } = string.Empty;

        /// <summary>
        /// 都道府県名
        /// </summary>
        public string PrefectureName {  get; set; } = string.Empty;

        /// <summary>
        /// 市区町村名
        /// </summary>
        public string CityName {  get; set; }  = string.Empty;

        /// <summary>
        /// 町域名
        /// </summary>
        public string TownAreaName {  get; set; } = string.Empty;

        /// <summary>
        /// 1つの町域が複数の郵便番号で構成されているか
        /// </summary>
        public int IsPartOfTownArea { get; set; } = 0;

        /// <summary>
        /// 小字が存在するか
        /// </summary>
        public int HasKoaza {  get; set; } = 0;

        /// <summary>
        /// 丁目が存在するか
        /// </summary>
        public int HasChoume { get; set; } = 0;

        /// <summary>
        /// 1つの郵便番号に複数の町域が存在するか
        /// </summary>
        public int HasMultipleTownArea { get; set; } = 0;

        /// <summary>
        /// 更新ステータス
        /// </summary>
        public int UpdateStatus {  get; set; } = 0;

        /// <summary>
        /// 更新理由
        /// </summary>
        public int UpdateReason {  get; set; } = 0;
    }
}
