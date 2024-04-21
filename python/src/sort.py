from typing import List
def insertion(unsorted_list:List[int])->List[int]:
    for i, entry in enumerate(unsorted_list):
        current = i
        while current > 0 and unsorted_list[current] < unsorted_list[current-1]:
            unsorted_list[current], unsorted_list[current-1] = unsorted_list[current-1], unsorted_list[current]
            current -= 1
        return unsorted_list

def merge(unsorted_list:List[int])->List[int]:
    n = len(unsorted_list)
    if n<=1:
        return unsorted_list
    mid = n//2
    left = unsorted_list[:mid]
    right = unsorted_list[mid:]
    merge(left)
    merge(right)
    i = j = k = 0
    while i < len(left) and j < len(right):
        if left[i] < right[j]:
            unsorted_list[k] = left[i]
            i += 1
        else:
            unsorted_list[k] = right[j]
            j += 1
        k += 1
    while i < len(left):
        unsorted_list[k] = left[i]
        i += 1
        k += 1

if __name__ == '__main__':
    unsorted_list = [3, 1, 4, 1, 5, 9, 2, 6]  # Example unsorted list
    sorted_list = insertion(unsorted_list)
    print("Sorted list:", sorted_list)

    
