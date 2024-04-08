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
