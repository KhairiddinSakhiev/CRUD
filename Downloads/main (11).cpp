#include <iostream>
#include <cmath>
using namespace std;

int main()
{
    int x,d,cnt=0;
    cin>>x>>d;
    
    while(x>0){
        if(x%10==d){
            cnt++;
        }
        x/=10;
    }
    cout<<cnt;
    return 0;
}
