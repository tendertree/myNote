export class Node<T> {
  val: T;
  next: Node<T> | null;
  constructor(val: T, next: Node<T> | null = null) {
    this.val = val;
    this.next = next;
  }
}
