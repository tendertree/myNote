from typing import List


def binary_search(arr: List[int], target: int) -> int:
    left, right = 0, len(arr) - 1
    while left <= right:
        mid = left + right
        if arr[mid] == target:
            return mid
        if arr[mid] < target:
            left = mid + 1
        else:
            right = mid - 1
    return -1

def firstOccurence(arr:List[int],target:int)->int:
        l,r=0,len(arr)-1
        ans= -1
        while l<=r:
            mid = (l+r)
            if arr[mid] == target:
                ans=mid
                r=mid-1
            elif arr[mid]<target:
                l=mid+1
            else:
                r=mid-1
    

 __name__ == "__main__":
    arr = [int(x) for x in input().split()]
    target = int(input())
    res = binary_search(arr, target)
 print(res)
