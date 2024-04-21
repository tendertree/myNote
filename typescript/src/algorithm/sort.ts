function insertionSort(arr: number[]): number[] {
    for (let i = 1; i < arr.length; i++) {
        let current = i;
        while (current > 0 && arr[current] < arr[current - 1]) {
            [arr[current], arr[current - 1]] = [arr[current - 1], arr[current]];
            current--;
        }
    }
    return arr;
}

function merge(unsortedList: number[]): number[] {
    const n = unsortedList.length;
    if (n <= 1) {
        return unsortedList;
    }

    const mid = Math.floor(n / 2);
    const left = unsortedList.slice(0, mid);
    const right = unsortedList.slice(mid);

    const mergedLeft = merge(left);
    const mergedRight = merge(right);

    return mergeLists(mergedLeft, mergedRight);
}

function mergeLists(left: number[], right: number[]): number[] {
    const result: number[] = [];
    let leftIndex = 0;
    let rightIndex = 0;

    while (leftIndex < left.length && rightIndex < right.length) {
        if (left[leftIndex] < right[rightIndex]) {
            result.push(left[leftIndex]);
            leftIndex++;
        } else {
            result.push(right[rightIndex]);
            rightIndex++;
        }
    }

    return result.concat(left.slice(leftIndex), right.slice(rightIndex));
}
