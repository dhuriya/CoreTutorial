#include<iostream>
#include<string>
using namespace std;
int sumOfDigits(int n){
    int sum = 0;
    while(n != 0){
        int last = n % 10;
        sum +=last;
        n = n/10;
    }
    return sum;
}
int usingRecursion(int n){
    if(n == 0)
        return 0;
    return (n % 10) + usingRecursion(n/10);
}
int usingConversion(int n){
    string s = to_string(n);
    int sum = 0;
    for(char ch : s){
        sum += ch - '0';
    }
    return sum;
}
int main(){

    int n = 12345;
    cout<<usingConversion(n)<<endl;
    return 0;
}