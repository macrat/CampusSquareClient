using System.IO;


namespace CampusSquare {

/// <summary>
/// ファイルから読み込んだHTMLを返すクラス。
/// デバッグ用や、成績データにアクセス出来ないときに使用する。
/// </summary>
class FileCampusSquareClient : ICampusSquareClient {
	private string html;

	/// <param name="fileName">読み込むHTMLのファイル名</param>
	public FileCampusSquareClient(string fileName) {
		html = new StreamReader(fileName).ReadToEnd();
	}

	public string GetGradePage() {
		return html;
	}

	public string GetGradePage(int year) {
		return html;
	}

	public string GetGradePage(int year, bool firstHalf) {
		return html;
	}
}

}
