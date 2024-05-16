import { Node } from "../basic/node.ts";

function removeDuplication<T>(arr: T[]) {
  let slow = 0;
  for (let fast = 0; fast < arr.length; fast++) {
    if (arr[fast] != arr[slow]) {
      slow++;
      arr[slow] = arr[fast];
    }
  }
}

function middleOfList<T>(head: Node<T>) {
  let slow: Node<T> | null = head;
  let fast: Node<T> | null = head;
  while (fast && fast.next) {
    fast = fast!.next.next;
    slow = slow!.next;
  }
  return slow?.val;
}
