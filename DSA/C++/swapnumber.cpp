#include<iostream>
using namespace std;
void usingThirdVariable(int a, int b){
    cout<<"before swap a or  b value : "<< a << " and " << b <<endl;
    int temp = a;
    a = b;
    b = temp;
    cout<<"after swap a or b value : " << a <<" and "<<b<<endl;
}
void withoutThirdVariable(int a, int b){
    cout<<"before swap a or  b value : "<< a << " and " << b <<endl;
    a = a + b; // 70
    b = a-b;// 30;
    a = a-b;// 40
    cout<<"after swap a or b value : " << a <<" and "<<b<<endl;
}
void usingBitWiseXOR(int a,int b){
    cout<<"before swap a or  b value : "<< a << " and " << b <<endl;
    a = a ^ b;
    b = a ^ b;
    a = a ^ b;
    cout<<"after swap a or b value : " << a <<" and "<<b<<endl;
}
int main(){
    
    int a = 20, b = 30;
    //usingThirdVariable(a,b);
    //withoutThirdVariable(a,b);
    // using Buit-in-swap method
    cout<<"before swap a or  b value : "<< a << " and " << b <<endl;
    swap(a,b);
    cout<<"after swap a or b value : " << a <<" and "<<b<<endl;
    usingBitWiseXOR(a,b);
    return 0;
}