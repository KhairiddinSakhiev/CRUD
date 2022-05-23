#include <iostream>
#include <cmath>
using namespace std;

int
main ()
{
 int n,m;
 bool res;
 cin>>n>>m;
 res = n%m==0 || m%n==0;
 cout<<res;
  return 0;
}
