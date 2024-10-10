void arrsum(int n, int arr[], int *sump) {
    int sum;
    sum = 0;
    while (n > 0) { 
        sum=sum+arr[n-1]; 
        n=n-1; 
    }
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