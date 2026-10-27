#include<iostream>
#include<climits>
using namespace std;
int closeetNumber(int n, int m)
{
    int closest =0;
    int minDifference = INT_MAX;
    
    for (int i = n-abs(m); i < n+abs(m); ++i)
    {
        if(i%m == 0){
            int difference = abs(n - i);

            if(difference < minDifference || (difference == minDifference && abs(i) > abs(closest)))
            {
                closest = i;
                minDifference = difference;
            }
        }
    }
    return closest;
    
}
int closetNumberByFindingQuotient(int n, int m){
    int q = n/m;
    // 1st possible closest number
    int n1 = m * q;
    // 2nd possible closet number
    int n2 = (n * m) > 0 ? (m * (q + 1)) : (m * (q-1));
    // if true, then n1 is the required closet number
    if(abs(n - n1) < abs(n - n2))
        return n1;
    
    return n2;
}
int main()
{
    int n = 13, m = 4;
    cout<<closetNumberByFindingQuotient(n,m)<<endl;
    return 0;
}