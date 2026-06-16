#include<iostream>
using namespace std;
int summation(int n){
    int sum=0;
    for (int i = 1; i <=n; i++)
    {
        sum +=(i*i);
    }
    return sum;
}
int summationUsingFormula(int n){
    //return (n * (n+1) * (2 * n + 1)) / 6;
    //to avoid overflow
    // n * (n + 1) * (2 * n + 1) / 6 = (n * (n + 1)/2) * (2 * n + 1) / 3;
    return (n * (n + 1)/2) * (2 * n + 1) / 3;
}
int main()
{
    int n=10;
    cout<<summationUsingFormula(n);
    return 0;
}