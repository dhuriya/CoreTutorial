
namespace DSAWithC_
{
    public static class BinarySearch
    {
        //------------------------------------
        //Program for Square Root of Integer
        //------------------------------------
        public static int floorsqurt(int n)
        {
            int low =1, hi = n;
            int res = 1;
            while(low<=hi)
            {
                int mid = low + (hi - low)/2;
                if(mid * mid <= n)
                {
                    res = mid;
                    low = mid+1;
                }
                else
                {
                    hi = mid-1;
                }
            }
            return res;
        }
        public static int findFloor(int[] arr, int x)
        {
            int low = 0, high = arr.Length - 1;
            int res = -1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (arr[mid] <= x)
                {
                    low = mid + 1;
                    res = mid;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return res;
        }
    }
}