from typing import List
def insertion(unsorted_list:List[int])->List[int]:
    for i, entry in enumerate(unsorted_list):
        current = i
        while current > 0 and unsorted_list[current] < unsorted_list[current-1]:
            unsorted_list[current], unsorted_list[current-1] = unsorted_list[current-1], unsorted_list[current]
            current -= 1
        return unsorted_list

if __name__ == '__main__':
    unsorted_list = [3, 1, 4, 1, 5, 9, 2, 6]  # Example unsorted list
    sorted_list = insertion(unsorted_list)
    print("Sorted list:", sorted_list)

    
