#include<iostream>
#include<cmath>
using namespace std;
bool isPower(int x, int y){
    if(x ==1)
        return (y==1);
    int pow = 1;
    while(pow < y){
        pow = pow * x;
    }
    return (pow ==y);
}
bool usingExponentiaionandBinary(int x, int y){
    if(x ==1)
        return (y==1);
    if(y==1)
        return true;
    int pow = x, i =1;
    while (pow<y)
    {
        pow *=pow;
        i *=2;
    }
    if(pow ==y)
        return true;
    int low =x, high = pow;
    while(low<=high){
        int mid = low + (high - low)/2;
        int exponent = (int)(log(mid)/log(x));
        int result = (int)powl(x,exponent);
        if(result ==y)
            return true;
        if(result < y)
            low = mid+1;
        else
            high = mid - 1;
    }
    return false;
    
}
bool usingLogarithmic(int x, int y){
    if(x ==1)
        return y ==1;
    if(y ==1)
        return true;
    double res = log(y) / log(x);

    return fabs(res - round(res)) < 1e-10;
}
int main(){
    cout<<boolalpha;
    cout<<usingLogarithmic(10,1)<<endl;
    cout<<usingLogarithmic(1,20)<<endl;
    cout<<usingLogarithmic(2,128)<<endl;
    cout<<usingLogarithmic(2,30)<<endl;
    return 0;
}