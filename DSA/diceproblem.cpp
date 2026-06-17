#include<bits/stdc++.h>
using namespace std;
int oppositeFaceOfDice(int n){
    int ans;
    if(n == 1){
        ans = 6;
    }else if(n == 2){
        ans = 5;
    }else if(n == 3){
        ans = 4;
    }else if(n == 4){
        ans == 3;
    }else if(n ==5){
        ans = 2;
    }else{
        ans = 1;
    }
    return ans;
}
int sumofTwoSide(int n){
    int ans = 7 -n;
    return ans;
}
int main(){
    int n = 1;
    cout<< sumofTwoSide(n);
    return 0;
}