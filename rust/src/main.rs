struct Node<T> {
    val: T,
    next: Option<Box<Node<T>>>,
}

fn split_word(s: &str) -> Vec<&str> {
    s.split_whitespace().collect()
}

fn main() {
    let _input = String::new();
    let _a = 3;

    println!("Hello, world!");
}
