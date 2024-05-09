class MinHeap<T> {
    private heap: T[] = [];
    constructor(private compareFn?: (a: T, b: T) => number) {
    }
    get size(): number {
        return this.heap.length;
    }
    peek(): T | null {
        return this.heap[0] || null;
    }
    isEmpty(): boolean {
        return this.size === 0;
    }
    private getParentIndex(index: number): number {
        return Math.floor((index - 1) / 2);
    }
    private getLeftIndex(index: number): number {
        return index * 2 + 1;
    }
    private getRightIndex(index: number): number {
        return index * 2 + 2;
    }
    private shouldSwap(l: number, r: number): boolean {
        const compareFn = this.compareFn ||
            ((a: T, b: T) => (a < b ? -1 : a > b ? 1 : 0));
        return compareFn(this.heap[l], this.heap[r]) > 0;
    }
    private swap(l: number, r: number) {
        [this.heap[l], this.heap[r]] = [this.heap[r], this.heap[l]];
    }
    private heapifyUp(idx: number): void {
        const parentIdx = this.getParentIndex(idx);
        if (parentIdx >= 0 && this.shouldSwap(parentIdx, idx)) {
            this.swap(parentIdx, idx);
            this.heapifyUp(parentIdx);
        }
    }
    private heapifyDown(idx: number): void {
        const l = this.getLeftIndex(idx);
        const r = this.getRightIndex(idx);
        let swapIdx: number | null = null;
        if (l < this.size && this.shouldSwap(l, idx)) {
            swapIdx = l;
        }
        if (
            r < this.size && this.shouldSwap(r, idx) &&
            (!swapIdx || this.shouldSwap(r, idx))
        ) {
            swapIdx = r;
        }
        if (swapIdx !== null) {
            this.swap(idx, swapIdx);
            this.heapifyDown(swapIdx);
        }
    }
    pop(): T | null {
        if (this.isEmpty()) return null;
        const root = this.heap[0];
        this.heap[0] = this.heap.pop()!;
        this.heapifyDown(0);
        return root;
    }
}
