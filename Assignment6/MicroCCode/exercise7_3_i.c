void arrsum(int n, int arr[], int *sump) {
    int sum;
    sum = 0;
    
    int i;
    for(i=n; i>0; i=i-1)
        sum=sum+arr[i-1]; 
    
    *sump = sum;
}

void main(int n)
{
    int arr[4];
    arr[0]=7;
    arr[1]=13;
    arr[2]=9;
    arr[3]=8;
    int sum;
    
    arrsum(n, arr, &sum);
    print sum;
}