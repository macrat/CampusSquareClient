class Grade : IGrade {
	private int grade, creditNum;
	private string name;

	public Grade(string name, int grade, int creditNum) {
		this.grade = grade;
		this.creditNum = creditNum;
		this.name = name;
	}

	public int getGrade() {
		return grade;
	}

	public int getCreditNum() {
		return creditNum;
	}

	public string getName() {
		return name;
	}
}
