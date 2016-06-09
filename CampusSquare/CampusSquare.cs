using System.Collections.Generic;


namespace CampusSquare {

/// <summary>
/// CampusSquareのクライアント。
/// </summary>
/// <example>
/// 以下のコードを実行すると、今までに受けた講義の名前を一覧表示します。
/// <code>
/// CampusSquare cs = new CampusSquare("your id", "your password");
/// foreach(IGrade x in cs.GetGrades()) {
///     Console.WriteLine(x.Name);
/// }
/// </code>
/// </example>
public class CampusSquare : AbcCampusSquare {
	/// <param name="userName">CampusSquareのユーザー名</param>
	/// <param name="password">CampusSquareにログインする時に使用するパスワード</param>
	/// <exception cref="System.Security.Authentication.AuthenticationException">認証に失敗した場合に送出されます。</exception>
	public CampusSquare(string userName, string password) {
		client = new CampusSquareClient(userName, password);
		parser = new GradeParser();
	}
}

}
