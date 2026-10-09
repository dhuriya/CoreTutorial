
// class Calculator {
//     public int add(int a, int b) {
//         return a + b;
//     }
// }
class Computer {
    public void playMusic() {
        System.out.println("Computer is playing music...");
    }
    public String getMeAPen(int cost) {
        if(cost >= 10) {
            return "Here is a pen for you!";
        } else {
            return "Sorry, the pen costs more than " + cost;
        }
    }
}
class Student {
    int rollno;
    String name;
    int marks ;
}
class Human{
    private int age = 26;
    private String name = "Deepu";

    public int getAge(){
        return  age;
    }
    public void setAge(int a){
        age = a;
    }
    public String getName(){
        return  name;
    }
    public void setName(String s){
        name = s;
    }
}
public class Demo {
    public static void main(String[] args) {
        //--------------------------------------------------
        // Computer computer = new Computer();
        // computer.playMusic();
        // String pen = computer.getMeAPen(5);
        // System.out.println(pen);
        //--------------------------------------------------
        // int num1 = 4;
        // int num2 = 5;
        // Calculator calc = new Calculator();
        // int result = calc.add(num1, num2);
        // System.out.println(result);
        //--------------------------------------------------
        // int nums[] = {1, 2, 3, 4, 5};
        // int nums2[] = new int[5];
        // System.out.println(nums[0]);
        //int multiDimArray[][] = {{1, 2, 3}, {4, 5, 6}, {7, 8, 9}};
        //int multiDimArray2[][] = new int[3][4];
        //--------------------------------------------------
        // Student s1 = new Student();
        // s1.rollno = 101;
        // s1.name = "Navin";
        // s1.marks = 67;

        // Student s2 = new Student();
        // s2.rollno = 102;
        // s2.name = "Harsh";
        // s2.marks = 88;

        // Student s3 = new Student();
        // s3.rollno = 103;
        // s3.name ="Kiran";
        // s3.marks = 97;

        // Student students[] = new Student[3];
        // students[0] = s1;
        // students[1] = s2;
        // students[2] = s3;

        // for(int i =0; i< students.length; i++){
        //     System.out.println(students[i].name +" : "+ students[i].marks);
        // }
        // for(Student stud: students){
        //     System.out.println(stud.name +" : "+ stud.marks);
        // }
        //----------------------------------------------------------------------
        // String name = new String("Navim");
        // //System.out.println(name);
        // //System.out.println(name.hashCode());
        // System.out.println("Hello "+ name);
        // System.out.println(name.concat(" ready"));
        //====================================================
        // Stirng Buffer
        // StringBuffer sb = new StringBuffer("Navin");
        // System.out.println(sb.length());
        //----------------------------------------
        Human obj = new  Human();
        //obj.age = 26;
        //obj.name = "Deepu";
        obj.setAge(30);
        obj.setName("Rahul");
        System.out.println(obj.getName() + " " + obj.getAge());

    }
    // Q what is Primitive data types in Java?
    // A: Primitive data types in Java are the most basic data types that are built into
    // the language. They include int, float, double, char, boolean, byte, short, and long.
    // Q what is JDK?
    // A: JDK (Java Development Kit) is a software development kit that contains the
    // tools needed to develop Java applications, including the JRE and the compiler.
    //Q what is JVM?
    // A: JVM (Java Virtual Machine) is a program that executes Java bytecode.
    //Q what is JRE?
    // A: JRE (Java Runtime Environment) is a software package that contains the JVM
    // and the libraries needed to run Java programs.

    // Q what is need to Array in Java?
    // A: Arrays in Java are used to store multiple values of the same type in a single variable. 
    // They provide a way to organize and manipulate data efficiently.

    // Q what is drawback of Array in Java?
    // A: The main drawback of arrays in Java is that they have a fixed size,
    // which means that once an array is created, its size cannot be changed.
    // This can lead to wasted memory if the array is not fully utilized, or to errors if the array is too 
    // small to hold all the required data.
    // B: Searching

    // Q Why are we need foreach loop?
    // Q Encapsulation
    // Q Method Overloading
    // Q Method Overriding
    // Q Inheritaince
    // Q super();
    // Q packages
    // Q Access Modifiers
    // Q Polymorphism
    // Q Dynamic Method Dispatch
    // Q final keyword - > variable,method,class
    // Q object class

    
}
