using System.Collections.Generic;


namespace CampusSquare {

/// <summary>
/// CampusSquareから成績情報を取得するクラスのインターフェース。
/// </summary>
interface ICampusSquare {
	/// <summary>
	/// 今までの全ての成績を取得する。
	/// </summary>
	IEnumerable<IGrade> GetGrades();

	/// <summary>
	/// ある年度の成績だけを取得する。
	/// </summary>
	/// <param name="year">取得する年度</param>
	IEnumerable<IGrade> GetGrades(int year);

	/// <summary>
	/// ある年度の前期だけもしくは後期だけの成績を取得する。
	/// </summary>
	/// <param name="year">取得する年度</param>
	/// <param name="firstHalf">trueなら前期、falseなら後期</param>
	IEnumerable<IGrade> GetGrades(int year, bool firstHalf);
}

}
