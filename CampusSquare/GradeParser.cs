using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace CampusSquare {

/// <summary>
/// CampusSquareの成績ページをパースするクラス。
/// </summary>
class GradeParser : IGradeParser {
	/// <summary>
	/// CampusSquareの成績ページをパースする。
	/// </summary>
	/// <param name="gradePage">成績ページのHTMLデータ</param>
	public IEnumerable<IGrade> Parse(string gradePage) {
		var tbody = (new Regex("<tbody>.+?</tbody>", RegexOptions.Singleline)).Matches(gradePage)[1].Value;
		return XDocument.Parse(tbody).Descendants("tr").Select(TableLineToGrade);
	}

	/// <summary>
	/// S, A, B, Cなどの成績判定の文字をint型に変換する。
	/// </summary>
	/// <param name="grade">変換する成績判定</param>
	private static int GradeToInteger(string grade) {
		var dic = new Dictionary<string, int>(){
			{"S", 4},
			{"A", 3},
			{"B", 2},
			{"C", 1},
			{"D", 0},
			{"X", 0},
		};
		return dic[grade];
	}

	/// <summary>
	/// 一つの講義の成績情報が記されたHTMLのtrタグの中身をIGrade型にパースする。
	/// </summary>
	/// <param name="tr">trタグが入ったXElementのインスタンス。</param>
	private static IGrade TableLineToGrade(XElement tr) {
		var elms = tr.Elements();
		return new CreditGrade(
			elms.ElementAt(4).Value.Trim(),
			GradeToInteger(elms.ElementAt(8).Value.Trim()),
			(int)float.Parse(elms.ElementAt(5).Value.Trim())
		);
	}
}

}
