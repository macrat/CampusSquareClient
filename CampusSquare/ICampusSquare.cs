using System.Collections.Generic;

interface ICampusSquare {
   List<IGrade> getGrades();
   List<IGrade> getGrades(int year);
   List<IGrade> getGrades(int year, bool first_half);
}
