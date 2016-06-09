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

	/// <summary>
	/// この講義の成績評価。
	/// Sなら4、Aなら3、Bなら2、Cなら1、DかXなら0。
	/// </summary>
	public int Grade {
		get { return grade; }
	}

	/// <summary>
	/// この講義で取得出来る単位数。
	/// <summary>
	public int CreditNum {
		get { return creditNum; }
	}

	/// <summary>
	/// この講義の名前。
	/// </summary>
	public string Name {
		get { return name; }
	}
}

}
