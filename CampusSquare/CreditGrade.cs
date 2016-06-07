namespace CampusSquare {

/// <summary>
/// 一つの講義の成績の情報。
/// </summary>
class CreditGrade : IGrade {
	private int grade, creditNum;
	private string name;

	public CreditGrade(string name, int grade, int creditNum) {
		this.grade = grade;
		this.creditNum = creditNum;
		this.name = name;
	}

	public int Grade {
		get { return grade; }
	}

	public int CreditNum {
		get { return creditNum; }
	}

	public string Name {
		get { return name; }
	}
}

}
