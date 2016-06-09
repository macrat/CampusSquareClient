namespace CampusSquare {

/// <summary>
/// ダミーのCampusSquareクライアント。
/// 成績ページを保存したHTMLファイルを読み取り、パースした結果を返却する。
///
/// 期間指定に関するオプションが動かないので注意。
/// </summary>
public class DummyCampusSquare : AbcCampusSquare {
	/// <param name="fileName">読み込むHTMLファイルのパス</param>
	public DummyCampusSquare(string fileName) {
		client = new FileCampusSquareClient(fileName);
		parser = new GradeParser();
	}
}

}
