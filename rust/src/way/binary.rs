use std::io;

fn binary_search(arr: &[i32], target: i32) -> i32 {
    let mut left = 0;
    let mut right = arr.len() as i32 - 1;
    while left <= right {
        let mid = (left + right) / 2;
        println!("compared {:?} and {:?}(mid)", target, mid);
        if arr[mid as usize] == target {
            println!("found");
            return mid;
        }
        if arr[mid as usize] < target {
            println!("target is bigger");
            left = mid + 1;
        } else {
            println!("target is smaller");
            right = mid - 1;
        }
    }
    -1
}

fn main() {
    let mut input = String::new();
    io::stdin()
        .read_line(&mut input)
        .expect("failed to read line");
    let arr: Vec<i32> = input
        .trim()
        .split_whitespace()
        .map(|x| x.parse().expect("Not a number"))
        .collect();
    println!("{:?}", arr);
    let mut input = String::new();
    io::stdin()
        .read_line(&mut input)
        .expect("failed to read line");
    let target: i32 = input.trim().parse().expect("not a number");
    let res = binary_search(&arr, target);
    println!("{}", res)
}
