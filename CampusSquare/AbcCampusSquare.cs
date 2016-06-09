using System.Collections.Generic;


namespace CampusSquare {

/// <summary>
/// ICampusSquareを実装するための共通っぽい仕様をまとめたもの。
/// </summary>
public abstract class AbcCampusSquare : ICampusSquare {
	protected ICampusSquareClient client;
	protected IGradeParser parser;


	/// <summary>
	/// 今までの全ての成績を取得する。
	/// </summary>
	public IEnumerable<IGrade> GetGrades() {
		return parser.Parse(client.GetGradePage());
	}

	/// <summary>
	/// ある年度の前期だけもしくは後期だけの成績を取得する。
	/// </summary>
	/// <param name="year">取得する年度</param>
	/// <param name="firstHalf">trueなら前期、falseなら後期</param>
	public IEnumerable<IGrade> GetGrades(int year, bool firstHalf) {
		return parser.Parse(client.GetGradePage(year, firstHalf));
	}
}

}
