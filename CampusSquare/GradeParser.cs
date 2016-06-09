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
	/// 一つの講義の成績情報が記されたHTMLのtrタグの中身をIGrade型にパースする。
	/// </summary>
	/// <param name="tr">trタグが入ったXElementのインスタンス。</param>
	private static IGrade TableLineToGrade(XElement tr) {
		var elms = tr.Elements();
		return new CreditGrade(
			elms.ElementAt(4).Value.Trim(),
			elms.ElementAt(8).Value.Trim(),
			(int)float.Parse(elms.ElementAt(5).Value.Trim())
		);
	}
}

}
