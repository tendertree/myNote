function combinations<T>(array: T[], n: number): T[][] {
  const result: T[][] = [];

  function combine(index: number, current: T[]) {
    if (current.length === n) {
      result.push(current.slice());
      return;
    }
    if (index >= array.length) {
      return;
    }
    current.push(array[index]);
    combine(index + 1, current);
    current.pop();
    combine(index + 1, current);
  }

  combine(0, []);

  return result;
}

function getEvenNUmberSomeBelowN(n: number) {
  return Array
    .from({ length: n / 2 }, (_, i) => (i + 1) * 2)
    .reduce(
      (acc, curr) => acc + curr ** 2,
      0,
    );
}
