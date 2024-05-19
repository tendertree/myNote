function binarySearch(arr: number[], target: number): number {
    let left = 0;
    let right = arr.length - 1;
    while (left <= right) {
        let mid = Math.floor((left + right) / 2);
        if (arr[mid] == target) {
            return mid;
        }
        if (arr[mid] < target) {
            left = mid + 1;
        } else {
            right = mid - 1;
        }
    }
    return -1;
}

function finsFirstTrue(arr: boolean[]): number {
    let left = 0;
    let right = arr.length - 1;
    let bondaryIndex = -1;
    while (left <= right) {
        let mid = Math.floor((left + right) / 2);
        if (arr[mid]) {
            bondaryIndex = mid;
            right = mid - 1;
        } else {
            left = mid + 1;
        }
    }
    return bondaryIndex;
}

const arr: number[] = [1, 2, 3, 4, 5, 6, 7];
const target: number = 3;
const res: number = binarySearch(arr, target);
