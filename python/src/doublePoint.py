from typing import List
# fast가 slow아 다르면 (중복구간을 벗어나면)slow 를 진행시킨다
def remove_duplicates(arr:List[int])->int:
    slow =0
    for fast in range(len(arr)):
        if arr[fast]!= arr[slow]:
            slow+=1
            arr[slow]=arr[fast]
    return slow +1
