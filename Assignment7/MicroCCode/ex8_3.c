void populate(int n, int arr[])
{
    int i;
    i=0;
    while (i<n)
    {
        //print i;
        arr[i] = i;
        ++i;
    }
}

void increment(int n, int arr[])
{
    int i;
    i=-1;
    --n;
    while (i<n)
    {
        //print ++i;
        ++arr[++i];
    }
}

void printarr(int n, int arr[])
{
    int i;
    i=0;
    while (i<n)
    {
        print arr[i];
        ++i;
    }
}

void main()
{
    int n;
    n = 7;
    int arr[7];
    populate(n, arr);
    increment(n, arr);
    printarr(n, arr);
}