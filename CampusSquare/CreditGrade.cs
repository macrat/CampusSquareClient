using System.Collections.Generic;


namespace CampusSquare {

/// <summary>
/// 一つの講義の成績の情報。
/// </summary>
class CreditGrade : IGrade {
	private int creditNum;
	private string grade, name;

	/// <param name="name">講義の名前。</param>
	/// <param name="grade">成績評価。SとかAとかBとか。</param>
	/// <param name="creditNum">単位数。</param>
	public CreditGrade(string name, string grade, int creditNum) {
		this.grade = grade;
		this.creditNum = creditNum;
		this.name = name;
	}

	/// <summary>
	/// この講義の成績評価。
	/// </summary>
	public string Grade {
		get { return grade; }
	}

	/// <summary>
	/// この講義の成績評価を数値で表したもの。
	/// Sなら4、Aなら3、Bなら2、Cなら1、DかXなら0。
	/// </summary>
	public int GradeNum {
		get {
			var dic = new Dictionary<string, int>(){
				{"S", 4},
				{"A", 3},
				{"B", 2},
				{"C", 1},
				{"D", 0},
				{"X", 0},
			};
			return dic[grade];
		}
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
