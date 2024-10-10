void arrsum(int n, int arr[], int *sump) {
    int sum;
    sum = 0;
    
    int i;
    for(i=n; i>0; i=i-1)
        sum=sum+arr[i-1]; 
    
    *sump = sum;
}

void squares(int n, int arr[])
{
    int i;
    for(i=n; i>0; i=i-1)
    {
        arr[i-1]=(i-1)*(i-1);
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