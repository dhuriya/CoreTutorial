#include<iostream>
using namespace std;
void printTable(int n)
{
    for(int i =1; i<=10;++i)
    {
        cout<< n <<" * " << i << "= "<<n*1<<endl;
    }
}
void printTableByRecursion(int n , int i =1){
    if(i ==11)
        return;
    cout<<n << " * "<<i <<" = "<<n*i<<endl;
    i++;
    printTableByRecursion(n,i);
}
int main()
{
 int n = 5;
 printTableByRecursion(n);
 return 0;
}