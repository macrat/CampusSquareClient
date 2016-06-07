using System.Collections.Generic;


namespace CampusSquare {

/// <summary>
/// 成績ページをパースするクラスのインターフェース。
/// </summary>
interface IGradeParser {
	/// <summary>
	/// 成績ページをパースする。
	/// </summary>
	/// <param name="gradePage">成績ページのHTMLデータ</param>
	IEnumerable<IGrade> Parse(string gradePage);
}

}
