namespace CampusSquare {

/// <summary>
/// 一つの講義の成績の情報を示すクラスのインターフェース。
/// </summary>
interface IGrade {
	/// <summary>
	/// 成績評価。
	/// 4ならS、3ならA、2ならB、1ならC、0ならDもしくはXを示す。
	/// </summary>
	int Grade { get; }

	/// <summary>
	/// この講義で取得出来る単位数。
	/// </summary>
	int CreditNum { get; }


	/// <summary>
	/// 講義の名前。
	/// </summary>
	string Name { get; }
}

}
