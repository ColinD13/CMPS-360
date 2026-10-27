public class StudentGradeCalculator {
    public static void main(String[] args) throws Exception {
        //student info
        String name = "Colin Downing";
        String major = "Computer Science";
        String course = "CMPS 360";
        
        //student grades
        double grade1 = 95;
        double grade2 = 90;
        double grade3 = 73;

        //calc the grade average
        double average = (grade1 + grade2 + grade3) / 3;

        //print student info
        System.out.println("Student: " + name);
        System.out.println("Major: " + major);
        System.out.println("Course: " + course);
        System.out.println("Average: " + average);

        //conditinoal to decide if student passed
        if(average >= 70){
            System.out.println("Passed");
        }
        else{
            System.out.println("Failed");
        }
    }

}