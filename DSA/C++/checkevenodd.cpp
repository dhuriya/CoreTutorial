#include<iostream>
using namespace std;
bool isEven(int n)
{
    //finding remainder of n
    int rem = n%2;
    if(rem =0){
        return true;
    }else{
        return false;
    }
}
bool isEvenfromBit(int n)
{
    if((n&1)==0)
        return true;
    else
        return false;
}
int main()
{
    int n = 16;
    if(isEvenfromBit(n)){
        cout<<"Ture";
    }else{
        cout<<"false";
    }
}