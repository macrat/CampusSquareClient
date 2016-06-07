namespace CampusSquare {

interface ICampusSquareClient {
   string GetGradePage();
   string GetGradePage(int year);
   string GetGradePage(int year, bool firstHalf);
}

}
