using System.Collections.Generic;


namespace CampusSquare {

interface ICampusSquare {
	List<IGrade> GetGrades();
	List<IGrade> GetGrades(int year);
	List<IGrade> GetGrades(int year, bool firstHalf);
}

}
