//********************************
// Pointers
//******************************** */
// A pointer is a special variable that holds the memory address of another variable, rather than storing a direct valur itself.

#include<iostream>
using namespace std;
int main(){
    int var = 10;
    //decalre pointer and store address of var
    int* ptr = &var;
    cout<<"Value of var: "<<var<<endl;
    cout<<"Address of var: "<<&var<<endl;

    cout<<"Value stored in pointer ptr: "<<ptr<<endl;
    cout<<"Value pointed to by ptr: "<<*ptr<<endl;
    return 0;
}