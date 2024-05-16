export class Counter<T> {
  private counts: Map<T, number>;
  constructor() {
    this.counts = new Map<T, number>();
  }
  increment(e: T): void {
    if (this.counts.has(e)) {
      this.counts.set(e, this.counts.get(e)! + 1);
    } else {
      this.counts.set(e, 1);
    }
  }
  decrement(e: T): number {
    return this.counts.get(e) || 0;
  }
  mostCommon(n: number): [T, number][] {
    return [...this.counts.entries()].sort((a, b) => b[1] - a[1]).slice(0, n);
  }
  all(): [T, number][] {
    return [...this.counts.entries()];
  }
}

export const split = (s: string) => {
  return s == "" ? [] : s.split("");
};
