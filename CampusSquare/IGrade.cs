namespace CampusSquare {

/// <summary>
/// 一つの講義の成績の情報を示すクラスのインターフェース。
/// </summary>
public interface IGrade {
	/// <summary>
	/// この講義の成績評価。
	/// </summary>
	string Grade { get; }

	/// <summary>
	/// この講義の成績評価を数値で表したもの。
	/// Sなら4、Aなら3、Bなら2、Cなら1、DかXなら0。
	/// </summary>
	int GradeNum { get; }

	/// <summary>
	/// この講義で取得出来る単位数。
	/// </summary>
	int CreditNum { get; }

	/// <summary>
	/// この講義の名前。
	/// </summary>
	string Name { get; }

	/// <summary>
	/// 講義の大区分。
	/// </summary>
	string LargeGenre { get; }

	/// <summary>
	/// 講義の中区分。
	/// </summary>
	string MediumGenre { get; }

	/// <summary>
	/// 講義の小区分。
	/// </summary>
	string SmallGenre { get; }
}

}
