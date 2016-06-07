namespace CampusSquare {

/// <summary>
/// CampusSquareの成績ページのHTMLを取得するためのクラスのインターフェース。
/// </summary>
interface ICampusSquareClient {
	/// <summary>
	/// 全ての成績が記された成績ページのHTMLデータを取得する。
	/// </summary>
	string GetGradePage();

	/// <summary>
	/// 特定の年度の成績が記された成績ページのHTMLデータを取得する。
	/// </summary>
	/// <param name="year">取得する年度</param>
	string GetGradePage(int year);

	/// <summary>
	/// 特定の年度の前期のみもしくは後期のみの成績が記された成績ページのHTMLデータを取得する。
	/// </summary>
	/// <param name="year">取得する年度</param>
	/// <param name="firstHalf">trueなら前期、falseなら後期</param>
	string GetGradePage(int year, bool firstHalf);
}

}
