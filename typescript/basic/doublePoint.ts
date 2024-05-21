import { Node } from "../basic/node.ts";
import { IsValidCharacter } from "../basic/string.ts";
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

function moveZerotoRight(nums: number[]) {
  let slow = 0;
  for (let fast = 0; fast < nums.length; fast++) {
    if (nums[fast] != 0) {
      nums[fast], nums[slow] = nums[slow], nums[fast];
      slow++;
    }
  }
}

function twoSumSortedAry(nums: number[], target: number) {
  let l = 0;
  let r = nums.length - 1;
  while (l < r) {
    const sum = nums[l] + nums[r];
    if (sum == target) {
      return [l, r];
    } else if (sum < target) {
      l++;
    } else {
      r--;
    }
  }
}

function isPalindrome(s) {
  let l = 0;
  let r = s.length - 1;
  while (l < r) {
    while (l < r && !IsValidCharacter(s.charAt(l))) {
      l++;
    }
    while (l < r && !IsValidCharacter(s.charAt(r))) {
      r--;
    }
    if (s.charAt(l).toLowerCase() != s.charAt(r).toLowerCase()) {
      return false;
    }
    l++;
    r--;
  }
  return true;
}
