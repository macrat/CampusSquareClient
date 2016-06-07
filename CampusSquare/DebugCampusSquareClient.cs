using System.IO;


class DebugCampusSquareClient : ICampusSquareClient {
	private string html;


	public DebugCampusSquareClient(string fname) {
		html = new StreamReader(fname).ReadToEnd();
	}

	public string getGradePage() {
		return html;
	}

	public string getGradePage(int year) {
		return html;
	}

	public string getGradePage(int year, bool first_half) {
		return html;
	}
}
