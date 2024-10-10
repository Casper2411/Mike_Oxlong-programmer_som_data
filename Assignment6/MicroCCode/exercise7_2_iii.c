void histogram(int n, int ns[], int max, int freq[])
{
    while (n > 0) { 
        int val;
        val = ns[n-1];
        freq[val] = freq[val]+1;
        n=n-1; 
    }
}

void main()
{
    int arr[7];
    arr[0]=1;
    arr[1]=2;
    arr[2]=1;
    arr[3]=1;
    arr[4]=1;
    arr[5]=2;
    arr[6]=0;
    
    int freq[4];
    freq[0]=0;
    freq[1]=0;
    freq[2]=0;
    freq[3]=0;
    
    histogram(7,arr,3,freq);
    print freq[0];
    print freq[1];
    print freq[2];
    print freq[3];
}