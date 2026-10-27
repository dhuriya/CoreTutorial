#include<iostream>
using namespace std;
int findSum(int n){
    int sum=0;
    for (int i = 1; i <= n; i++)
    {
        sum = sum + i;
    }
    return sum;
}
int findSumByRecursion(int n)
{
    if(n==1)
        return 1;
    return n + findSumByRecursion(n);
}
int findSumByFormula(int n){
    return n * (n+1)/2;
}
int main(){
    int n = 5;
    cout<<findSumByFormula(n);
    return 0;
}