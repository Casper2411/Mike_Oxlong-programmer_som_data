void arrsum(int n, int arr[], int *sump) {
    int sum;
    sum = 0;
    while (n > 0) { 
        sum=sum+arr[n-1]; 
        n=n-1; 
    }
    *sump = sum;
}

void squares(int n, int arr[])
{
    while (n > 0) { 
        arr[n-1]=(n-1)*(n-1);
        n=n-1; 
    }
}

void main(int n)
{
    int arr[20];
    squares(n, arr);

    int sum;
    sum=0;
    arrsum(n, arr, &sum);
    print sum;
}