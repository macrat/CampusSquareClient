using System.Collections.Generic;


namespace CampusSquare {

/// <summary>
/// CampusSquareのクライアント。
/// </summary>
/// <example>
/// 以下のコードを実行すると、今までに受けた講義の名前を一覧表示します。
/// <code>
/// CampusSquare cs = new CampusSquare("your id", "your password");
/// foreach(IGrade x in cs) {
///     Console.WriteLine(x.Name);
/// }
/// </code>
/// </example>
class CampusSquare {
	private CampusSquareClient client;
	private GradeParser parser;


	/// <param name="userName">CampusSquareのユーザー名</param>
	/// <param name="password">CampusSquareにログインする時に使用するパスワード</param>
	public CampusSquare(string userName, string password) {
		client = new CampusSquareClient(userName, password);
		parser = new GradeParser();
	}

	/// <summary>
	/// 今までの全ての成績を取得する。
	/// </summary>
	IEnumerable<IGrade> GetGrades() {
		return parser.Parse(client.GetGradePage());
	}

	/// <summary>
	/// ある年度の成績だけを取得する。
	/// </summary>
	/// <param name="year">取得する年度</param>
	IEnumerable<IGrade> GetGrades(int year) {
		return parser.Parse(client.GetGradePage(year));
	}

	/// <summary>
	/// ある年度の前期だけもしくは後期だけの成績を取得する。
	/// </summary>
	/// <param name="year">取得する年度</param>
	/// <param name="firstHalf">trueなら前期、falseなら後期</param>
	IEnumerable<IGrade> GetGrades(int year, bool firstHalf) {
		return parser.Parse(client.GetGradePage(year, firstHalf));
	}
}

}
