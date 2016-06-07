using System.IO;


namespace CampusSquare {

class DebugCampusSquareClient : ICampusSquareClient {
	private string html;


	public DebugCampusSquareClient(string fileName) {
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
