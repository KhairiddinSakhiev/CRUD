#include <iostream>
#include <cmath>
using namespace std;

int
main ()
{
  int a,b,c,d,n, result;
  cin>>n;
  a = n/1000;
  b = n/100%10;
  c = n/10%10;
  d = n%10;
  
  result = abs(a-d)+abs(b-c)+1;
    cout<<result;
  return 0;
}
