fn insertion_sort(mut unsorted_list: Vec<i32>) -> Vec<i32> {
    let mut current: usize;
    for i in 1..unsorted_list.len() {
        current = i;
        while current > 0 && unsorted_list[current] < unsorted_list[current - 1] {
            unsorted_list.swap(current, current - 1);
        }
    }
    unsorted_list
}
