from typing import List
def insertion(unsorted_list:List[int])->List[int]:
    for i, entry in enumerate(unsorted_list):
        current = i
        while current > 0 and unsorted_list[current] < unsorted_list[current-1]:
            unsorted_list[current], unsorted_list[current-1] = unsorted_list[current-1], unsorted_list[current]
            current -= 1
        return unsorted_list


if __name__ == '__main__':
    
