using System.Collections.Generic;


namespace CampusSquare {

interface ICampusSquare {
	IEnumerable<IGrade> GetGrades();
	IEnumerable<IGrade> GetGrades(int year);
	IEnumerable<IGrade> GetGrades(int year, bool firstHalf);
}

}
