using System.IO;


namespace CampusSquare {

/// <summary>
/// ファイルから読み込んだHTMLを返すクラス。
/// デバッグ用や、成績データにアクセス出来ないときに使用する。
///
/// 期間の指定は機能しないので注意が必要。
/// </summary>
class FileCampusSquareClient : ICampusSquareClient {
	private string html;

	/// <param name="fileName">読み込むHTMLのファイルパス</param>
	public FileCampusSquareClient(string fileName) {
		html = new StreamReader(fileName).ReadToEnd();
	}

	/// <summary>
	/// 成績データが記録されたHTMLを返却する。
	/// 単純に読み込んだファイルの内容が返るだけ。
	/// </summary>
	public string GetGradePage() {
		return html;
	}

	/// <summary>
	/// 成績データを取得する。
	/// データの期間は読み込んだファイルに依存するため、引数は機能しない。
	/// </summary>
	/// <param name="year">データが欲しい年度。機能しないので注意。</param>
	public string GetGradePage(int year) {
		return html;
	}

	/// <summary>
	/// 成績データを取得する。
	/// データの期間は読み込んだファイルに依存するため、引数は機能しない。
	/// </summary>
	/// <param name="year">年度。機能しないので注意。</param>
	/// <param name="firstHalf">前期か後期か。機能しないので注意。</param>
	public string GetGradePage(int year, bool firstHalf) {
		return html;
	}
}

}
